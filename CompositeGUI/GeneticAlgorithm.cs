using CompositeGUI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static CompositeGUI.MainForm;

namespace CompositeGUI
{
    class GeneticAlgorithm
    {
        UpdateStatusForThreadDelegate UpdateStatus;
        int projectId;
        GA_Settings settings;
        bool hasMetalGrid;
        Material matrixMaterial;
        Material fiberMaterial;
        Limits limits;
        (double, double) frequency;
        double mutationProbability;

        int currentGeneration = 1;
        (double, double) mutationRange = (-0.3, 0.3);
        List<Composite> population;
        Random rnd = new Random();

        void GeneratePopulation()
        {
            population = new List<Composite>(settings.PopulationSize);
            for(int i=0; i < settings.PopulationSize; i++) { 
                Composite c = new Composite();
                c.ProjectId = projectId;
                c.NumberInProject = i + 1;
                c.Generation = currentGeneration;
                c.LayerCount = RandomValue.RandomInt(rnd, limits.MinLayerCount, limits.MaxLayerCount);
                c.FiberWidth = RandomValue.RandomDouble(rnd, limits.MinFiberWidth, limits.MaxFiberWidth);
                c.FiberThickness = RandomValue.RandomDouble(rnd, limits.MinFiberThickness, limits.MaxFiberThickness);
                c.FiberSpaceBetween = RandomValue.RandomDouble(rnd, limits.MinFiberSpaceBetween, limits.MaxFiberSpaceBetween);

                population.Add(c);
            }
        }

        void GetFitnessValues()
        {
            CST cst;
            Composite c;
            for (int i=0; i<population.Count; i++)
            {
                c = population[i];
                cst = new CST();

                c.ProjectId = projectId;
                c.NumberInProject = (i + 1) + settings.PopulationSize * (currentGeneration - 1);
                c.Generation = currentGeneration;

                UpdateStatus(new SimulationStatus()
                {
                    InProcess = true,
                    CurrentGeneration = currentGeneration,
                    CurrentIndividualInGeneration = i + 1
                });

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //c.CstResults = cst.GetResults(c, matrixMaterial, fiberMaterial, hasMetalGrid, frequency);
                ////////////////////////////////////////////////////////////////////////////////////////////////////
                c.CstResults = cst.GetTestResults(c, matrixMaterial, fiberMaterial, hasMetalGrid, frequency);

                if (c.CstResults.Count > 0)
                {
                    decimal totalSE = 0;
                    foreach (var res in c.CstResults) totalSE += (decimal)res.SE;
                    c.ShieldingEfficiency = (double)(totalSE / c.CstResults.Count);
                }
                else c.ShieldingEfficiency = 0;
            }
        }

        void TourneySelection()
        {
            int indexOfMax;
            List<Composite> newP = new List<Composite>();
            
            while(population.Count >= settings.SelectionTourneySize)
            {
                indexOfMax = 0;
                for (int i = 0; i < settings.SelectionTourneySize; i++)
                {
                    if (population[i].ShieldingEfficiency > population[indexOfMax].ShieldingEfficiency)
                    {
                        indexOfMax = i;
                    }
                }
                newP.Add(population[indexOfMax]);
                population.RemoveAt(indexOfMax);
            }
            population = newP;
            population.OrderBy(i => i.ShieldingEfficiency);
        }

        void Crossingover()
        {
            double Cmin, Cmax, alphaDeltaC;
            List<Composite> newP = new List<Composite>();
            for (int i = 0; i < settings.PopulationSize && newP.Count+1 < settings.PopulationSize; i++)
            {
                for (int j = i+1; j < settings.PopulationSize-1; j++)
                {
                    if (newP.Count+1 >= settings.PopulationSize) break;

                    Composite newOffspring = new Composite();

                    //////////////////
                    // Ширина волокна
                    Cmin = Math.Min(population[i].FiberWidth, population[j].FiberWidth);
                    Cmax = Math.Max(population[i].FiberWidth, population[j].FiberWidth);
                    alphaDeltaC = settings.CrossingoverAlphaParam * (Cmax - Cmin);

                    // Определяем границы изменения значения хромосомы
                    Cmin = Cmin - alphaDeltaC >= limits.MinFiberWidth ? Cmin - alphaDeltaC : limits.MinFiberWidth;
                    Cmax = Cmax + alphaDeltaC <= limits.MaxFiberWidth ? Cmax + alphaDeltaC : limits.MaxFiberWidth;
                    
                    // BLX-alpha crossingover
                    newOffspring.FiberWidth = RandomValue.RandomDouble(rnd, Cmin, Cmax);

                    //////////////////
                    // Количество слоев
                    newOffspring.LayerCount = Math.Max(population[i].LayerCount, population[j].LayerCount);

                    //////////////////
                    // Толщина волокна
                    Cmin = Math.Min(population[i].FiberThickness, population[j].FiberThickness);
                    Cmax = Math.Max(population[i].FiberThickness, population[j].FiberThickness);
                    alphaDeltaC = settings.CrossingoverAlphaParam * (Cmax - Cmin);

                    // Определяем границы изменения значения хромосомы
                    Cmin = Cmin - alphaDeltaC >= limits.MinFiberThickness ? Cmin - alphaDeltaC : limits.MinFiberThickness;
                    Cmax = Cmax + alphaDeltaC <= limits.MaxFiberThickness ? Cmax + alphaDeltaC : limits.MaxFiberThickness;

                    // BLX-alpha crossingover
                    newOffspring.FiberThickness = RandomValue.RandomDouble(rnd, Cmin, Cmax);

                    //////////////////
                    // Расстояние между волокнами
                    Cmin = Math.Min(population[i].FiberSpaceBetween, population[j].FiberSpaceBetween);
                    Cmax = Math.Max(population[i].FiberSpaceBetween, population[j].FiberSpaceBetween);
                    alphaDeltaC = settings.CrossingoverAlphaParam * (Cmax - Cmin);

                    // Определяем границы изменения значения хромосомы
                    Cmin = Cmin - alphaDeltaC >= limits.MinFiberSpaceBetween ? Cmin - alphaDeltaC : limits.MinFiberSpaceBetween;
                    Cmax = Cmax + alphaDeltaC <= limits.MaxFiberSpaceBetween ? Cmax + alphaDeltaC : limits.MaxFiberSpaceBetween;

                    // BLX-alpha crossingover
                    newOffspring.FiberSpaceBetween = RandomValue.RandomDouble(rnd, Cmin, Cmax);

                    // добавляем потомка
                    newP.Add(newOffspring);
                }
            }
            newP.Add(population[0]); // добавляем особь с наилучшей приспособленностью из предыдущего поколения
            population = newP;
        }

        void Mutation()
        {
            double p;
            foreach (Composite c in population)
            {
                p = RandomValue.RandomDouble(rnd, 0, 1);
                if(p < mutationProbability) // мутация
                { 
                    // Ширина
                    c.FiberWidth += RandomValue.RandomDouble(rnd, mutationRange.Item1, mutationRange.Item2);
                    if (c.FiberWidth > limits.MaxFiberWidth) c.FiberWidth = limits.MaxFiberWidth;
                    else if (c.FiberWidth < limits.MinFiberWidth) c.FiberWidth = limits.MinFiberWidth;

                    // Толщина
                    c.FiberThickness += RandomValue.RandomDouble(rnd, mutationRange.Item1, mutationRange.Item2);
                    if (c.FiberThickness > limits.MaxFiberThickness) c.FiberThickness = limits.MaxFiberThickness;
                    else if (c.FiberThickness < limits.MinFiberThickness) c.FiberThickness = limits.MinFiberThickness;

                    // Расстояние между волокнами
                    c.FiberSpaceBetween += RandomValue.RandomDouble(rnd, mutationRange.Item1, mutationRange.Item2);
                    if (c.FiberSpaceBetween > limits.MaxFiberSpaceBetween) c.FiberSpaceBetween = limits.MaxFiberSpaceBetween;
                    else if (c.FiberSpaceBetween < limits.MinFiberSpaceBetween) c.FiberSpaceBetween = limits.MinFiberSpaceBetween;
                }
            }
        }

        void SaveCurrentPopulation()
        {
            DB.SaveComposites(population);
        }

        public void Start()
        {
            currentGeneration = 1;
            UpdateStatus(new SimulationStatus()
            {
                InProcess = true,
                CurrentGeneration = currentGeneration,
                CurrentIndividualInGeneration = 1
            });
            GeneratePopulation();
            while (currentGeneration <= settings.MaxGenerations)
            {
                GetFitnessValues();
                SaveCurrentPopulation();
                TourneySelection();
                if (currentGeneration + 1 <= settings.MaxGenerations) // если текущее поколение не последнее
                {
                    Crossingover();
                    Mutation();
                }
                currentGeneration++;
            }
            UpdateStatus(new SimulationStatus()
            {
                InProcess = false,
                CurrentGeneration = 1,
                CurrentIndividualInGeneration = 1
            });
        }

        public GeneticAlgorithm(Project p, UpdateStatusForThreadDelegate UpdateStatus)
        {
            this.UpdateStatus = UpdateStatus;
            projectId = p.ProjectId;
            settings = p.GA_Settings;
            hasMetalGrid = p.HasMetalGrid;
            matrixMaterial = p.MatrixMaterial;
            fiberMaterial = p.FiberMaterial;
            limits = p.Limits;
            frequency = (p.MinFrequency, p.MaxFrequency);

            mutationProbability = 1 / (2 * settings.PopulationSize);
        }
    }
}
