using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompositeGUI
{
    class CST
    {
        Type cstAppType;
        object cstApp;

        public bool Connected = false;

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

        private void ConnectToCST()
        {
            
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

        public CST()
        {
            ConnectToCST();
        }

        public void Test()
        {
            object cstProject = InvokeCST(cstApp, "OpenFile", @"C:\Users\German\Desktop\Учеба\ЭМС лабы\latest_Лаба 4\lab4.cst");
        }

        public void Simulation(
            Composite c,
            Material matrixMaterial,
            Material fiberMaterial,
            bool with_grid,
            (double, double) frequency
           )
        {
            if (!Connected) return;

            try
            {
                bool use_solver = true;
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

                object Solver = InvokeCST(cstApp, "Solver");
                InvokeCST(Solver, "FrequencyRange", frequency.Item1, frequency.Item2);

                // Stavim Normal vmesto PEC
                object Background = InvokeCST(cstApp, "Background");
                InvokeCST(Background, "ResetBackground");
                InvokeCST(Background, "XminSpace", "0.0");
                InvokeCST(Background, "XmaxSpace", "0.0");
                InvokeCST(Background, "YminSpace", "0.0");
                InvokeCST(Background, "YmaxSpace", "0.0");
                InvokeCST(Background, "ZminSpace", "0.0");
                InvokeCST(Background, "ZmaxSpace", "0.0");
                InvokeCST(Background, "ApplyInAllDirections", "False");

                object Material = InvokeCST(cstApp, "Material");
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
                InvokeCST(Material, "DispModelEps ", "None");
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

                object Units = InvokeCST(cstApp, "Units");
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

                object Boundary = InvokeCST(cstApp, "Boundary");
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
                InvokeCST(Material, "Rho", "2250");
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
            }
            catch(Exception ex)
            {
                DialogResult tryAgain = MainProcedureError(ex);
                if(tryAgain == DialogResult.Yes)
                {
                    Simulation(c, matrixMaterial, fiberMaterial, with_grid, frequency);
                }
            }
        }
    }
}
