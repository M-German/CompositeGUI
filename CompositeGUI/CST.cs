using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CompositeGUI.Data;
using System.Globalization;
using System.Threading;

namespace CompositeGUI
{
    class CST
    {
        Type cstAppType;
        object cstApp;
        static string exportsFolder = Environment.CurrentDirectory + @"\CST_exports";
        public bool Connected = false;
        object cstDocument = null;

        Composite c;
        Material matrixMaterial;
        Material fiberMaterial;
        bool with_grid;
        (double, double) frequency;

        private DialogResult CSTConnectionError()
        {
            return MessageBox.Show(
                "Ошибка подключения к CST. Попробовать еще раз?",
                "Ошибка",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
             );
        }

        private DialogResult MainProcedureError(Exception ex)
        {
            MessageBox.Show(ex.Message);
            return MessageBox.Show(
                "Ошибка синтеза. Перезапустить проектную процедуру?",
                "Ошибка",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
             );
        }

        private DialogResult FileOpenError(Exception ex, string filepath)
        {
            //MessageBox.Show(ex.Message);
            return MessageBox.Show(
                $"Ошибка открытия файла по пути: {filepath}",
                "Ошибка",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
             );
        }

        private void ConnectToCST()
        {
            if (Connected) return;
            try
            {
                cstAppType = Type.GetTypeFromProgID("CSTStudio.Application.2018");
            }
            catch
            {
                DialogResult tryAgain = CSTConnectionError();
                if (tryAgain == DialogResult.Yes)
                {
                    ConnectToCST();
                }
                else
                {
                    Connected = false;
                }
            }
            finally
            {
                cstApp = Activator.CreateInstance(cstAppType);
                Connected = true;
            }
        }

        public CST()
        {
            ConnectToCST();
        }

        private decimal DecimalParse(string str)
        {
            decimal val = decimal.Parse(str, new NumberFormatInfo() { NumberDecimalSeparator = "." });
            return decimal.Round(val, 3, MidpointRounding.AwayFromZero);
        }

        private List<CstResult> ReadExportFile(string fileName)
        {
            string filepath = $@"{exportsFolder}\{fileName}";
            string str, valueStr;
            StreamReader f = null;
            int i = 0;
            bool prevNumber;
            List<CstResult> results = new List<CstResult>();
            try
            {
                f = new StreamReader(filepath);
                while ((str = f.ReadLine()) != null)
                {
                    if(i >= 2 && (i - 2) % 10 == 0) // с третьей строки, каждую 10-ю строку
                    {
                        CstResult res = new CstResult();
                        prevNumber = false;
                        valueStr = "";
                        foreach (char c in str)
                        {
                            if (char.IsDigit(c) || c == '.' || c == '-')
                            {
                                prevNumber = true;
                                valueStr += c;
                            }
                            else if(prevNumber)
                            {
                                prevNumber = false;
                                if (res.Frequency == null) res.Frequency = DecimalParse(valueStr);
                                else if(res.S21 == null) res.S21 = DecimalParse(valueStr);
                            }
                        }
                        res.SE = (decimal)Math.Round((20 * Math.Log10(Math.Abs((double)res.S21))), 3);
                        results.Add(res);
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                FileOpenError(ex, filepath);
            }
            finally
            {
                f?.Close();
            }
            return results;
        }

        // no params
        object InvokeCST(object parent, string command)
        {
            return cstAppType.InvokeMember(command, BindingFlags.InvokeMethod, null, parent, new object[] { });
        }

        // string type params
        object InvokeCST(object parent, string command, string attr)
        {
            return cstAppType.InvokeMember(command, BindingFlags.InvokeMethod, null, parent, new object[] { attr });
        }
        object InvokeCST(object parent, string command, string attr, string attr2)
        {
            return cstAppType.InvokeMember(command, BindingFlags.InvokeMethod, null, parent, new object[] { attr, attr2 });
        }
        object InvokeCST(object parent, string command, string attr, string attr2, string attr3)
        {
            return cstAppType.InvokeMember(command, BindingFlags.InvokeMethod, null, parent, new object[] { attr, attr2, attr3 });
        }

        // double type params
        object InvokeCST(object parent, string command, double dattr)
        {
            string attr = doubleVBA(dattr);
            return InvokeCST(parent, command, attr);
        }
        object InvokeCST(object parent, string command, double dattr, double dattr2)
        {
            string attr = doubleVBA(dattr), attr2 = doubleVBA(dattr2);
            return InvokeCST(parent, command, attr, attr2);
        }
        object InvokeCST(object parent, string command, double dattr, double dattr2, double dattr3)
        {
            string attr = doubleVBA(dattr), attr2 = doubleVBA(dattr2), attr3 = doubleVBA(dattr3);
            return InvokeCST(parent, command, attr, attr2, attr3);
        }

        string BoolVBA(bool val)
        {
            return val ? "True" : "False";
        }

        string doubleVBA(double val)
        {
            return val.ToString("G", System.Globalization.CultureInfo.InvariantCulture);
        }

        public List<CstResult> GetResults(
            Composite c,
            Material matrixMaterial,
            Material fiberMaterial,
            bool with_grid,
            (double, double) frequency
        )
        {
            this.c = c;
            this.matrixMaterial = matrixMaterial;
            this.fiberMaterial = fiberMaterial;
            this.with_grid = with_grid;
            this.frequency = frequency;

            Simulation();

            return ReadExportFile(ExportToFile());
        }

        private string ExportToFile()
        {
            string FileName = $"proj{c.ProjectId}_gen{c.Generation}_ind{c.NumberInProject}_S21.txt";
            InvokeCST(cstDocument, "SelectTreeItem", @"1D Results\S-Parameters\S2,1");
            object ASCIIExport = InvokeCST(cstDocument, "ASCIIExport");
            InvokeCST(ASCIIExport, "Reset");
            InvokeCST(ASCIIExport, "FileName", exportsFolder + $@"\\{FileName}");
            InvokeCST(ASCIIExport, "Mode", "FixedNumber");
            InvokeCST(ASCIIExport, "Step", "1001");
            InvokeCST(ASCIIExport, "Execute");
            Thread.Sleep(3000);

            return FileName;
        }

        private void Simulation()
        {
            bool use_solver = true;

            try
            {
                int fiber_count = 15;
                double  fiber_to_grid_space = 0.3, // Rasstoyanie mezhdu voloknom i setkoi
                        grid_thickness = 1,
                        grid_width = 1,
                        space_between_grid = 1,
                        top_compound_thickness = 0.1; // tolshina sloya matricy sverhu

                double fiber_length = (c.FiberWidth + c.FiberSpaceBetween) * (fiber_count + 1);
                double raw_thickness = c.FiberThickness * c.LayerCount;

                //summarnaya tolshina composita
                double total_height = with_grid 
                    ? raw_thickness + fiber_to_grid_space + grid_thickness + top_compound_thickness 
                    : raw_thickness + top_compound_thickness;

                int grid_repetitions = ((int)(fiber_length / (grid_width + space_between_grid))) - 1;
                double ports_distance = 20;
                double ports_size_diff = 0;
                string bound_x = "open";
                string bound_y = "open";
                string bound_z = "expanded open";

                cstDocument = InvokeCST(cstApp, "NewMWS");
                object Solver = InvokeCST(cstDocument, "Solver");
                InvokeCST(Solver, "FrequencyRange", frequency.Item1, frequency.Item2);

                // Stavim Normal vmesto PEC
                object Background = InvokeCST(cstDocument, "Background");
                InvokeCST(Background, "ResetBackground");
                InvokeCST(Background, "XminSpace", "0.0");
                InvokeCST(Background, "XmaxSpace", "0.0");
                InvokeCST(Background, "YminSpace", "0.0");
                InvokeCST(Background, "YmaxSpace", "0.0");
                InvokeCST(Background, "ZminSpace", "0.0");
                InvokeCST(Background, "ZmaxSpace", "0.0");
                InvokeCST(Background, "ApplyInAllDirections", "False");

                object Material = InvokeCST(cstDocument, "Material");
                InvokeCST(Material, "Reset");
                InvokeCST(Material, "Rho", "0.0");
                InvokeCST(Material, "ThermalType", "Normal");
                InvokeCST(Material, "ThermalConductivity", "0");
                InvokeCST(Material, "HeatCapacity", "0");
                InvokeCST(Material, "DynamicViscosity", "0");
                InvokeCST(Material, "Emissivity", "0");
                InvokeCST(Material, "MetabolicRate", "0.0");
                InvokeCST(Material, "VoxelConvection", "0.0");
                InvokeCST(Material, "BloodFlow", "0");
                InvokeCST(Material, "MechanicsType", "Unused");
                InvokeCST(Material, "FrqType", "all");
                InvokeCST(Material, "Type", "Normal");
                InvokeCST(Material, "MaterialUnit", "Frequency", "Hz");
                InvokeCST(Material, "MaterialUnit", "Geometry", "m");
                InvokeCST(Material, "MaterialUnit", "Time", "s");
                InvokeCST(Material, "MaterialUnit", "Temperature", "Kelvin");
                InvokeCST(Material, "Epsilon", "1");
                InvokeCST(Material, "Mu", "1");
                InvokeCST(Material, "Sigma", "0.0");
                InvokeCST(Material, "TanD", "0.0");
                InvokeCST(Material, "TanDFreq", "0.0");
                InvokeCST(Material, "TanDGiven", "False");
                InvokeCST(Material, "TanDModel", "ConstSigma");
                InvokeCST(Material, "EnableUserConstTanDModelOrderEps", "False");
                InvokeCST(Material, "ConstTanDModelOrderEps", "1");
                InvokeCST(Material, "SetElParametricConductivity", "False");
                InvokeCST(Material, "ReferenceCoordSystem", "Global");
                InvokeCST(Material, "CoordSystemType", "Cartesian");
                InvokeCST(Material, "SigmaM", "0");
                InvokeCST(Material, "TanDM", "0.0");
                InvokeCST(Material, "TanDMFreq", "0.0");
                InvokeCST(Material, "TanDMGiven", "False");
                InvokeCST(Material, "TanDMModel", "ConstSigma");
                InvokeCST(Material, "EnableUserConstTanDModelOrderMu", "False");
                InvokeCST(Material, "ConstTanDModelOrderMu", "1");
                InvokeCST(Material, "SetMagParametricConductivity", "False");
                InvokeCST(Material, "DispModelEps", "None");
                InvokeCST(Material, "DispModelMu", "None");
                InvokeCST(Material, "DispersiveFittingSchemeEps", "Nth Order");
                InvokeCST(Material, "MaximalOrderNthModelFitEps", "10");
                InvokeCST(Material, "ErrorLimitNthModelFitEps", "0.1");
                InvokeCST(Material, "UseOnlyDataInSimFreqRangeNthModelEps", "False");
                InvokeCST(Material, "DispersiveFittingSchemeMu", "Nth Order");
                InvokeCST(Material, "MaximalOrderNthModelFitMu", "10");
                InvokeCST(Material, "ErrorLimitNthModelFitMu", "0.1");
                InvokeCST(Material, "UseOnlyDataInSimFreqRangeNthModelMu", "False");
                InvokeCST(Material, "UseGeneralDispersionEps", "False");
                InvokeCST(Material, "UseGeneralDispersionMu", "False");
                InvokeCST(Material, "NonlinearMeasurementError", "1e-1");
                InvokeCST(Material, "NLAnisotropy", "False");
                InvokeCST(Material, "NLAStackingFactor", "1");
                InvokeCST(Material, "NLADirectionX", "1");
                InvokeCST(Material, "NLADirectionY", "0");
                InvokeCST(Material, "NLADirectionZ", "0");
                InvokeCST(Material, "Colour", "0.6", "0.6", "0.6");
                InvokeCST(Material, "Wireframe", "False");
                InvokeCST(Material, "Reflection", "False");
                InvokeCST(Material, "Allowoutline", "True");
                InvokeCST(Material, "Transparentoutline", "False");
                InvokeCST(Material, "Transparency", "0");
                InvokeCST(Material, "ChangeBackgroundMaterial");

                object Units = InvokeCST(cstDocument, "Units");
                InvokeCST(Units, "Geometry", "mm");
                InvokeCST(Units, "Frequency", "GHz");
                InvokeCST(Units, "Time", "ns");
                InvokeCST(Units, "TemperatureUnit", "Celsius");
                InvokeCST(Units, "Voltage", "V");
                InvokeCST(Units, "Current", "A");
                InvokeCST(Units, "Resistance", "Ohm");
                InvokeCST(Units, "Conductance", "Siemens");
                InvokeCST(Units, "Capacitance", "PikoF");
                InvokeCST(Units, "Inductance", "NanoH");

                object Boundary = InvokeCST(cstDocument, "Boundary");
                InvokeCST(Boundary, "ReflectionLevel", "0.0001");
                InvokeCST(Boundary, "MinimumDistanceType", "Absolute");
                InvokeCST(Boundary, "MinimumDistancePerWavelengthNewMeshEngine", "20");
                InvokeCST(Boundary, "MinimumDistanceReferenceFrequencyType", "Center");
                InvokeCST(Boundary, "FrequencyForMinimumDistance", "0.5");
                InvokeCST(Boundary, "SetAbsoluteDistance", "10.0");

                // Материал волокна
                InvokeCST(Material, "Reset");
                InvokeCST(Material, "Name", fiberMaterial.Name);
                InvokeCST(Material, "Folder", "");
                InvokeCST(Material, "FrqType", "all");
                InvokeCST(Material, "Type", "Normal");
                InvokeCST(Material, "SetMaterialUnit", "GHz", "mm");
                InvokeCST(Material, "Epsilon", fiberMaterial.ElecCond);
                InvokeCST(Material, "Mu", fiberMaterial.MagCond);
                InvokeCST(Material, "Kappa", "1.0e005");
                InvokeCST(Material, "TanD", "0.0");
                InvokeCST(Material, "TanDFreq", "0.0");
                InvokeCST(Material, "TanDGiven", "False");
                InvokeCST(Material, "TanDModel", "ConstTanD");
                InvokeCST(Material, "KappaM", "0");
                InvokeCST(Material, "TanDM", "0.0");
                InvokeCST(Material, "TanDMFreq", "0.0");
                InvokeCST(Material, "TanDMGiven", "False");
                InvokeCST(Material, "TanDMModel", "ConstTanD");
                InvokeCST(Material, "DispModelEps", "None");
                InvokeCST(Material, "DispModelMu", "None");
                InvokeCST(Material, "DispersiveFittingSchemeEps", "General 1st");
                InvokeCST(Material, "DispersiveFittingSchemeMu", "General 1st");
                InvokeCST(Material, "UseGeneralDispersionEps", "False");
                InvokeCST(Material, "UseGeneralDispersionMu", "False");
                InvokeCST(Material, "Rho", fiberMaterial.Density);
                InvokeCST(Material, "ThermalType", "Normal");
                InvokeCST(Material, "ThermalConductivity", "24");
                InvokeCST(Material, "HeatCapacity", "0.71");
                InvokeCST(Material, "MechanicsType", "Isotropic");
                InvokeCST(Material, "YoungsModulus", "4.8");
                InvokeCST(Material, "PoissonsRatio", "0.2");
                InvokeCST(Material, "ThermalExpansionRate", "7.9");
                InvokeCST(Material, "Colour", "0", "0.25098", "0.25098");
                InvokeCST(Material, "Wireframe", "False");
                InvokeCST(Material, "Transparency", "0");
                InvokeCST(Material, "Create");

                // Материал матрицы
                InvokeCST(Material, "Reset");
                InvokeCST(Material, "Name", matrixMaterial.Name);
                InvokeCST(Material, "Folder", "");
                InvokeCST(Material, "FrqType", "all");
                InvokeCST(Material, "Type", "Normal");
                InvokeCST(Material, "SetMaterialUnit", "GHz", "mm");
                InvokeCST(Material, "Epsilon", matrixMaterial.ElecCond);
                InvokeCST(Material, "Mu", matrixMaterial.MagCond);
                InvokeCST(Material, "Kappa", "1.0e005");
                InvokeCST(Material, "TanD", "0.0");
                InvokeCST(Material, "TanDFreq", "0.0");
                InvokeCST(Material, "TanDGiven", "False");
                InvokeCST(Material, "TanDModel", "ConstTanD");
                InvokeCST(Material, "KappaM", "0");
                InvokeCST(Material, "TanDM", "0.0");
                InvokeCST(Material, "TanDMFreq", "0.0");
                InvokeCST(Material, "TanDMGiven", "False");
                InvokeCST(Material, "TanDMModel", "ConstTanD");
                InvokeCST(Material, "DispModelEps", "None");
                InvokeCST(Material, "DispModelMu", "None");
                InvokeCST(Material, "DispersiveFittingSchemeEps", "General 1st");
                InvokeCST(Material, "DispersiveFittingSchemeMu", "General 1st");
                InvokeCST(Material, "UseGeneralDispersionEps", "False");
                InvokeCST(Material, "UseGeneralDispersionMu", "False");
                InvokeCST(Material, "Rho", matrixMaterial.Density);
                InvokeCST(Material, "ThermalType", "Normal");
                InvokeCST(Material, "ThermalConductivity", "24");
                InvokeCST(Material, "HeatCapacity", "0.71");
                InvokeCST(Material, "MechanicsType", "Isotropic");
                InvokeCST(Material, "YoungsModulus", "4.8");
                InvokeCST(Material, "PoissonsRatio", "0.2");
                InvokeCST(Material, "ThermalExpansionRate", "7.9");
                InvokeCST(Material, "Colour", "0.501961", "0.501961", "0");
                InvokeCST(Material, "Wireframe", "False");
                InvokeCST(Material, "Transparency", "0");
                InvokeCST(Material, "Create");

                // '@ new component: Composite
                object Component = InvokeCST(cstDocument, "Component");
                InvokeCST(Component, "New", "Composite");

                // '@ define brick: Composite:Fiber
                object Brick = InvokeCST(cstDocument, "Brick");
                InvokeCST(Brick, "Reset");
                InvokeCST(Brick, "Name", "Fiber");
                InvokeCST(Brick, "Component", "Composite");
                InvokeCST(Brick, "Material", fiberMaterial.Name);
                InvokeCST(Brick, "Xrange", 0, c.FiberWidth);
                InvokeCST(Brick, "Yrange", 0, fiber_length);
                InvokeCST(Brick, "Zrange", 0, c.FiberThickness);
                InvokeCST(Brick, "Create");

                // '@ transform: translate Composite
                object Transform = InvokeCST(cstDocument, "Transform");
                InvokeCST(Transform, "Reset");
                InvokeCST(Transform, "Name", "Composite");
                InvokeCST(Transform, "Vector", c.FiberWidth + c.FiberSpaceBetween, 0, 0);
                InvokeCST(Transform, "UsePickedPoints", "False");
                InvokeCST(Transform, "InvertPickedPoints", "False");
                InvokeCST(Transform, "MultipleObjects", "True");
                InvokeCST(Transform, "GroupObjects", "False");
                InvokeCST(Transform, "Repetitions", fiber_count);
                InvokeCST(Transform, "MultipleSelection", "False");
                InvokeCST(Transform, "Destination", "");
                InvokeCST(Transform, "Material", "");
                InvokeCST(Transform, "Transform", "Shape", "Translate");

                //'@ Objedinenie volokon v odin object
                object Solid = InvokeCST(cstDocument, "Solid");
                for (int i=1; i <= fiber_count; i++)
                {
                    InvokeCST(Solid, "Add", "Composite:Fiber", "Composite:Fiber_" + i);
                }

                // '@ Sozdanie sloev
                if (c.LayerCount > 1)
                {
                    InvokeCST(Transform, "Reset");
                    InvokeCST(Transform, "Name", "Composite");
                    InvokeCST(Transform, "Origin", "Free");
                    InvokeCST(Transform, "Center", "0", "0", "0");
                    InvokeCST(Transform, "Angle", "0", "0", "90");
                    InvokeCST(Transform, "MultipleObjects", "True");
                    InvokeCST(Transform, "GroupObjects", "False");
                    InvokeCST(Transform, "Repetitions", "1");
                    InvokeCST(Transform, "MultipleSelection", "False");
                    InvokeCST(Transform, "Destination", "");
                    InvokeCST(Transform, "Material", "");
                    InvokeCST(Transform, "Transform", "Shape", "Rotate");

                    double vectorX;
                    string fiberName;
                    for (int i = 1; i < c.LayerCount; i++)
                    {
                        if (i % 2 != 0)
                        {
                            vectorX = fiber_length;
                            fiberName = "Composite:Fiber_1";
                        }
                        else
                        {
                            vectorX = 0;
                            fiberName = "Composite:Fiber";
                        }

                        // '@ transform: translate (fiberName)
                        InvokeCST(Transform, "Reset");
                        InvokeCST(Transform, "Name", fiberName);
                        InvokeCST(Transform, "Vector", vectorX, 0, c.FiberThickness * i);
                        InvokeCST(Transform, "UsePickedPoints", "False");
                        InvokeCST(Transform, "InvertPickedPoints", "False");
                        InvokeCST(Transform, "MultipleObjects", i == 1 ? "False" : "True");
                        InvokeCST(Transform, "GroupObjects", "False");
                        InvokeCST(Transform, "Repetitions", "1");
                        InvokeCST(Transform, "MultipleSelection", "False");
                        InvokeCST(Transform, "Transform", "Shape", "Translate");
                    }
                }

                //'@ define brick: Composite:Compound
                InvokeCST(Brick, "Reset");
                InvokeCST(Brick, "Name", "Compound");
                InvokeCST(Brick, "Component", "Composite");
                InvokeCST(Brick, "Material", matrixMaterial.Name);
                InvokeCST(Brick, "Xrange", 0, fiber_length);
                InvokeCST(Brick, "Yrange", 0, fiber_length);
                InvokeCST(Brick, "Zrange", 0, with_grid ? raw_thickness : raw_thickness + top_compound_thickness);
                InvokeCST(Brick, "Create");

                   
                //'@ Objedinenie sloev
                for (int i=1; i<c.LayerCount; i++)
                {
                    InvokeCST(Solid, "Add", "Composite:Fiber", "Composite:Fiber_" + i);
                }

                //'@ boolean insert shapes: Composite:Compound, Composite:Fiber
                InvokeCST(Solid, "Insert", "Composite:Compound", "Composite:Fiber");


                //'@ define material: Aluminum
                InvokeCST(Material, "Reset");
                InvokeCST(Material, "Name", "Aluminum");
                InvokeCST(Material, "Folder", "");
                InvokeCST(Material, "FrqType", "static");
                InvokeCST(Material, "Type", "Normal");
                InvokeCST(Material, "SetMaterialUnit", "Hz", "mm");
                InvokeCST(Material, "Epsilon", "1");
                InvokeCST(Material, "Mu", "1.0");
                InvokeCST(Material, "Kappa", "3.56e+007");
                InvokeCST(Material, "TanD", "0.0");
                InvokeCST(Material, "TanDFreq", "0.0");
                InvokeCST(Material, "TanDGiven", "False");
                InvokeCST(Material, "TanDModel", "ConstTanD");
                InvokeCST(Material, "KappaM", "0");
                InvokeCST(Material, "TanDM", "0.0");
                InvokeCST(Material, "TanDMFreq", "0.0");
                InvokeCST(Material, "TanDMGiven", "False");
                InvokeCST(Material, "TanDMModel", "ConstTanD");
                InvokeCST(Material, "DispModelEps", "None");
                InvokeCST(Material, "DispModelMu", "None");
                InvokeCST(Material, "DispersiveFittingSchemeEps", "General 1st");
                InvokeCST(Material, "DispersiveFittingSchemeMu", "General 1st");
                InvokeCST(Material, "UseGeneralDispersionEps", "False");
                InvokeCST(Material, "UseGeneralDispersionMu", "False");
                InvokeCST(Material, "FrqType", "all");
                InvokeCST(Material, "Type", "Lossy metal");
                InvokeCST(Material, "MaterialUnit", "Frequency", "GHz");
                InvokeCST(Material, "MaterialUnit", "Geometry", "mm");
                InvokeCST(Material, "MaterialUnit", "Time", "s");
                InvokeCST(Material, "MaterialUnit", "Temperature", "Kelvin");
                InvokeCST(Material, "Mu", "1.0");
                InvokeCST(Material, "Sigma", "3.56e+007");
                InvokeCST(Material, "Rho", "2700.0");
                InvokeCST(Material, "ThermalType", "Normal");
                InvokeCST(Material, "ThermalConductivity", "237.0");
                InvokeCST(Material, "HeatCapacity", "0.9");
                InvokeCST(Material, "MetabolicRate", "0");
                InvokeCST(Material, "BloodFlow", "0");
                InvokeCST(Material, "VoxelConvection", "0");
                InvokeCST(Material, "MechanicsType", "Isotropic");
                InvokeCST(Material, "YoungsModulus", "69");
                InvokeCST(Material, "PoissonsRatio", "0.33");
                InvokeCST(Material, "ThermalExpansionRate", "23");
                InvokeCST(Material, "ReferenceCoordSystem", "Global");
                InvokeCST(Material, "CoordSystemType", "Cartesian");
                InvokeCST(Material, "NLAnisotropy", "False");
                InvokeCST(Material, "NLAStackingFactor", "1");
                InvokeCST(Material, "NLADirectionX", "1");
                InvokeCST(Material, "NLADirectionY", "0");
                InvokeCST(Material, "NLADirectionZ", "0");
                InvokeCST(Material, "Colour", "1", "1", "0");
                InvokeCST(Material, "Wireframe", "False");
                InvokeCST(Material, "Reflection", "False");
                InvokeCST(Material, "Allowoutline", "True");
                InvokeCST(Material, "Transparentoutline", "False");
                InvokeCST(Material, "Transparency", "0");
                InvokeCST(Material, "Create");

                if(with_grid)
                {
                    //'@ define brick: Composite:MetalGrid
                    InvokeCST(Brick, "Reset");
                    InvokeCST(Brick, "Name", "MetalGrid");
                    InvokeCST(Brick, "Component", "Composite");
                    InvokeCST(Brick, "Material", "Aluminum");
                    InvokeCST(Brick, "Xrange", 0, fiber_length);
                    InvokeCST(Brick, "Yrange", 0, grid_width);
                    InvokeCST(Brick, "Zrange", raw_thickness + fiber_to_grid_space, raw_thickness + fiber_to_grid_space + grid_thickness);
                    InvokeCST(Brick, "Create");

                    //'@ transform: translate Composite:MetalGrid
                    InvokeCST(Transform, "Reset");
                    InvokeCST(Transform, "Name", "Composite:MetalGrid");
                    InvokeCST(Transform, "Vector", 0, grid_width + space_between_grid, 0);
                    InvokeCST(Transform, "UsePickedPoints", "False");
                    InvokeCST(Transform, "InvertPickedPoints", "False");
                    InvokeCST(Transform, "MultipleObjects", "True");
                    InvokeCST(Transform, "GroupObjects", "False");
                    InvokeCST(Transform, "Repetitions", grid_repetitions);
                    InvokeCST(Transform, "MultipleSelection", "False");
                    InvokeCST(Transform, "Destination", "");
                    InvokeCST(Transform, "Material", "");
                    InvokeCST(Transform, "Transform", "Shape", "Translate");

                    for(int i=1; i <= grid_repetitions; i++)
                    {
                        InvokeCST(Solid, "Add", "Composite:MetalGrid", "Composite:MetalGrid_" + i);
                    }

                    //'@ transform: rotate Composite:MetalGrid
                    InvokeCST(Transform, "Reset");
                    InvokeCST(Transform, "Name", "Composite:MetalGrid");
                    InvokeCST(Transform, "Origin", "Free");
                    InvokeCST(Transform, "Center", "0", "0", "0");
                    InvokeCST(Transform, "Angle", "0", "0", "90");
                    InvokeCST(Transform, "MultipleObjects", "True");
                    InvokeCST(Transform, "GroupObjects", "False");
                    InvokeCST(Transform, "Repetitions", "1");
                    InvokeCST(Transform, "MultipleSelection", "False");
                    InvokeCST(Transform, "Destination", "");
                    InvokeCST(Transform, "Material", "");
                    InvokeCST(Transform, "Transform", "Shape", "Rotate");

                    // '@ transform: translate Composite:MetalGrid_1
                    InvokeCST(Transform, "Reset");
                    InvokeCST(Transform, "Name", "Composite:MetalGrid_1");
                    InvokeCST(Transform, "Vector", fiber_length, 0, 0);
                    InvokeCST(Transform, "UsePickedPoints", "False");
                    InvokeCST(Transform, "InvertPickedPoints", "False");
                    InvokeCST(Transform, "MultipleObjects", "False");
                    InvokeCST(Transform, "GroupObjects", "False");
                    InvokeCST(Transform, "Repetitions", "1");
                    InvokeCST(Transform, "MultipleSelection", "False");
                    InvokeCST(Transform, "Transform", "Shape", "Translate");

                    //'@ boolean add shapes: Composite:MetalGrid, Composite:MetalGrid_1
                    InvokeCST(Solid, "Add", "Composite:MetalGrid", "Composite:MetalGrid_1");

                    //'@ define brick: Composite:Compound_2
                    InvokeCST(Brick, "Reset");
                    InvokeCST(Brick, "Name", "Compound_2");
                    InvokeCST(Brick, "Component", "Composite");
                    InvokeCST(Brick, "Material", matrixMaterial.Name);
                    InvokeCST(Brick, "Xrange", 0, fiber_length);
                    InvokeCST(Brick, "Yrange", 0, fiber_length);
                    InvokeCST(Brick, "Zrange", raw_thickness, raw_thickness + fiber_to_grid_space + grid_thickness + top_compound_thickness);
                    InvokeCST(Brick, "Create");

                    //'@ boolean insert shapes: Composite:Compound, Composite:MetalGrid
                    InvokeCST(Solid, "Insert", "Composite:Compound", "Composite:MetalGrid");
                }

                //'@ define pml specials
                InvokeCST(Boundary, "ReflectionLevel", "0.0001");
                InvokeCST(Boundary, "MinimumDistanceType", "Absolute");
                InvokeCST(Boundary, "MinimumDistancePerWavelengthNewMeshEngine", "4");
                InvokeCST(Boundary, "MinimumDistanceReferenceFrequencyType", "Center");
                InvokeCST(Boundary, "FrequencyForMinimumDistance", "0.05");
                InvokeCST(Boundary, "SetAbsoluteDistance", "10");

                //'@ define boundaries
                InvokeCST(Boundary, "Xmin", bound_x);
                InvokeCST(Boundary, "Xmax", bound_x);
                InvokeCST(Boundary, "Ymin", bound_y);
                InvokeCST(Boundary, "Ymax", bound_y);
                InvokeCST(Boundary, "Zmin", bound_z);
                InvokeCST(Boundary, "Zmax", bound_z);
                InvokeCST(Boundary, "Xsymmetry", "none");
                InvokeCST(Boundary, "Ysymmetry", "none");
                InvokeCST(Boundary, "Zsymmetry", "none");
                InvokeCST(Boundary, "ApplyInAllDirections", "True");

                //'@ define solver s-parameter symmetries
                InvokeCST(Solver, "ResetSParaSymm");


                object Port = InvokeCST(cstDocument, "Port");
                //'@ define port: 1
                InvokeCST(Port, "Reset");
                InvokeCST(Port, "PortNumber", "1");
                InvokeCST(Port, "Label", "");
                InvokeCST(Port, "Folder", "");
                InvokeCST(Port, "NumberOfModes", "1");
                InvokeCST(Port, "AdjustPolarization", "False");
                InvokeCST(Port, "PolarizationAngle", "0.0");
                InvokeCST(Port, "ReferencePlaneDistance", "0");
                InvokeCST(Port, "TextSize", "50");
                InvokeCST(Port, "TextMaxLimit", "1");
                InvokeCST(Port, "Coordinates", "Free");
                InvokeCST(Port, "Orientation", "zmax");
                InvokeCST(Port, "PortOnBound", "False");
                InvokeCST(Port, "ClipPickedPortToBound", "False");
                InvokeCST(Port, "Xrange", ports_size_diff, fiber_length - ports_size_diff);
                InvokeCST(Port, "Yrange", ports_size_diff, fiber_length - ports_size_diff);
                InvokeCST(Port, "Zrange", total_height + ports_distance, total_height + ports_distance);
                InvokeCST(Port, "XrangeAdd", "0.0", "0.0");
                InvokeCST(Port, "YrangeAdd", "0.0", "0.0");
                InvokeCST(Port, "ZrangeAdd", "0.0", "0.0");
                InvokeCST(Port, "SingleEnded", "False");
                InvokeCST(Port, "WaveguideMonitor", "False");
                InvokeCST(Port, "Create");

                //'@ define port: 2
                InvokeCST(Port, "Reset");
                InvokeCST(Port, "PortNumber", "2");
                InvokeCST(Port, "Label", "");
                InvokeCST(Port, "Folder", "");
                InvokeCST(Port, "NumberOfModes", "1");
                InvokeCST(Port, "AdjustPolarization", "False");
                InvokeCST(Port, "PolarizationAngle", "0.0");
                InvokeCST(Port, "ReferencePlaneDistance", "0");
                InvokeCST(Port, "TextSize", "50");
                InvokeCST(Port, "TextMaxLimit", "1");
                InvokeCST(Port, "Coordinates", "Free");
                InvokeCST(Port, "Orientation", "zmin");
                InvokeCST(Port, "PortOnBound", "False");
                InvokeCST(Port, "ClipPickedPortToBound", "False");
                InvokeCST(Port, "Xrange", ports_size_diff, fiber_length - ports_size_diff);
                InvokeCST(Port, "Yrange", ports_size_diff, fiber_length - ports_size_diff);
                InvokeCST(Port, "Zrange", 0 - ports_distance, 0 - ports_distance);
                InvokeCST(Port, "XrangeAdd", "0.0", "0.0");
                InvokeCST(Port, "YrangeAdd", "0.0", "0.0");
                InvokeCST(Port, "ZrangeAdd", "0.0", "0.0");
                InvokeCST(Port, "SingleEnded", "False");
                InvokeCST(Port, "WaveguideMonitor", "False");
                InvokeCST(Port, "Create");


                // solver params
                InvokeCST(Solver, "Method", "Hexahedral");
                InvokeCST(Solver, "CalculationType", "TD-S");
                InvokeCST(Solver, "StimulationPort", "All");
                InvokeCST(Solver, "StimulationMode", "All");
                InvokeCST(Solver, "SteadyStateLimit", "-40");
                InvokeCST(Solver, "MeshAdaption", "False");
                InvokeCST(Solver, "AutoNormImpedance", "True");
                InvokeCST(Solver, "NormingImpedance", "50");
                InvokeCST(Solver, "CalculateModesOnly", "False");
                InvokeCST(Solver, "SParaSymmetry", "True");
                InvokeCST(Solver, "StoreTDResultsInCache", "False");
                InvokeCST(Solver, "FullDeembedding", "False");
                InvokeCST(Solver, "SuperimposePLWExcitation", "False");
                InvokeCST(Solver, "UseSensitivityAnalysis", "False");
                
                //конец моделирования 
            }
            catch (Exception ex)
            {
                DialogResult tryAgain = MainProcedureError(ex);
                if(tryAgain == DialogResult.Yes)
                {
                    Simulation();
                }
            }
            finally
            {
                if(use_solver)
                {
                    try
                    {
                        object Solver = InvokeCST(cstDocument, "Solver");
                        // запуск анализа
                        InvokeCST(Solver, "Start");
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
        }

        public List<CstResult> GetTestResults(
            Composite c,
            Material matrixMaterial,
            Material fiberMaterial,
            bool with_grid,
            (double, double) frequency)
        {
            Thread.Sleep(500);
            return new List<CstResult>()
            {
                new CstResult() {Frequency = 0.1m, SE = 33},
                new CstResult() {Frequency = 0.2m, SE = 40},
                new CstResult() {Frequency = 0.3m, SE = 45},
                new CstResult() {Frequency = 0.4m, SE = 44},
                new CstResult() {Frequency = 0.5m, SE = 36},
                new CstResult() {Frequency = 0.6m, SE = 29},
                new CstResult() {Frequency = 0.7m, SE = 51},
                new CstResult() {Frequency = 0.8m, SE = 60},
                new CstResult() {Frequency = 0.9m, SE = 48},
                new CstResult() {Frequency = 1m, SE = 31},
                new CstResult() {Frequency = 1.1m, SE = 37},
                new CstResult() {Frequency = 1.2m, SE = 42},
                new CstResult() {Frequency = 1.3m, SE = 46},
                new CstResult() {Frequency = 1.4m, SE = 52},
                new CstResult() {Frequency = 1.5m, SE = 60},
                new CstResult() {Frequency = 1.6m, SE = 61},
                new CstResult() {Frequency = 1.7m, SE = 59},
                new CstResult() {Frequency = 1.8m, SE = 58},
                new CstResult() {Frequency = 1.9m, SE = 64},
            };
        }
    }
}
