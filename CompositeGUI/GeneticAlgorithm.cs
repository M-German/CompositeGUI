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
        Project p;
        UpdateStatusForThreadDelegate UpdateStatus;
        List<Composite> initialGeneration;
        List<Composite> population;
        Random rnd = new Random();

        int currentGeneration = 1, numberInProject = 1;
        double mutationProbability;
        (double, double) mutationRange = (-0.3, 0.3);
        bool STOP = false;

        void GeneratePopulation()
        {
            population = new List<Composite>(p.GA_Settings.PopulationSize);
            for(int i=0; i < p.GA_Settings.PopulationSize; i++) {
                Composite c = new Composite();
                c.ProjectId = p.ProjectId;
                c.NumberInProject = ++numberInProject;
                c.Generation = currentGeneration;
                c.LayerCount = RandomValue.RandomInt(rnd, p.Limits.MinLayerCount, p.Limits.MaxLayerCount);
                c.FiberWidth = RandomValue.RandomDouble(rnd, p.Limits.MinFiberWidth, p.Limits.MaxFiberWidth);
                c.FiberThickness = RandomValue.RandomDouble(rnd, p.Limits.MinFiberThickness, p.Limits.MaxFiberThickness);
                c.FiberSpaceBetween = RandomValue.RandomDouble(rnd, p.Limits.MinFiberSpaceBetween, p.Limits.MaxFiberSpaceBetween);

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

                c.ProjectId = p.ProjectId;
                c.NumberInProject = ++numberInProject;
                c.Generation = currentGeneration;

                UpdateStatus(new SimulationStatus()
                {
                    InProcess = true,
                    CurrentGeneration = currentGeneration,
                    CurrentIndividualInGeneration = i + 1
                });

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                c.CstResults = cst.GetResults(c, p);
                ////////////////////////////////////////////////////////////////////////////////////////////////////
                //c.CstResults = cst.GetTestResults(c, matrixMaterial, fiberMaterial, hasMetalGrid, frequency);

                if (c.CstResults.Count > 0)
                {
                    decimal totalSE = 0;
                    foreach (var res in c.CstResults) totalSE += (decimal)res.SE;
                    c.ShieldingEfficiency = Math.Round((double)(totalSE / c.CstResults.Count), 3);
                }
                else
                {
                    //STOP = true;
                    c.ShieldingEfficiency = 0;
                }
            }
        }

        void TourneySelection()
        {
            int indexOfMax;
            List<Composite> newP = new List<Composite>();
            
            while(population.Count >= p.GA_Settings.SelectionTourneySize)
            {
                indexOfMax = 0;
                for (int i = 0; i < p.GA_Settings.SelectionTourneySize; i++)
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
            for (int i = 0; i < p.GA_Settings.PopulationSize && newP.Count+1 < p.GA_Settings.PopulationSize; i++)
            {
                for (int j = i+1; j < p.GA_Settings.PopulationSize-1; j++)
                {
                    if (newP.Count+1 >= p.GA_Settings.PopulationSize) break;

                    Composite newOffspring = new Composite();

                    //////////////////
                    // Ширина волокна
                    Cmin = Math.Min(population[i].FiberWidth, population[j].FiberWidth);
                    Cmax = Math.Max(population[i].FiberWidth, population[j].FiberWidth);
                    alphaDeltaC = p.GA_Settings.CrossingoverAlphaParam * (Cmax - Cmin);

                    // Определяем границы изменения значения хромосомы
                    Cmin = Cmin - alphaDeltaC >= p.Limits.MinFiberWidth ? Cmin - alphaDeltaC : p.Limits.MinFiberWidth;
                    Cmax = Cmax + alphaDeltaC <= p.Limits.MaxFiberWidth ? Cmax + alphaDeltaC : p.Limits.MaxFiberWidth;
                    
                    // BLX-alpha crossingover
                    newOffspring.FiberWidth = RandomValue.RandomDouble(rnd, Cmin, Cmax);

                    //////////////////
                    // Количество слоев
                    newOffspring.LayerCount = Math.Max(population[i].LayerCount, population[j].LayerCount);

                    //////////////////
                    // Толщина волокна
                    Cmin = Math.Min(population[i].FiberThickness, population[j].FiberThickness);
                    Cmax = Math.Max(population[i].FiberThickness, population[j].FiberThickness);
                    alphaDeltaC = p.GA_Settings.CrossingoverAlphaParam * (Cmax - Cmin);

                    // Определяем границы изменения значения хромосомы
                    Cmin = Cmin - alphaDeltaC >= p.Limits.MinFiberThickness ? Cmin - alphaDeltaC : p.Limits.MinFiberThickness;
                    Cmax = Cmax + alphaDeltaC <= p.Limits.MaxFiberThickness ? Cmax + alphaDeltaC : p.Limits.MaxFiberThickness;

                    // BLX-alpha crossingover
                    newOffspring.FiberThickness = RandomValue.RandomDouble(rnd, Cmin, Cmax);

                    //////////////////
                    // Расстояние между волокнами
                    Cmin = Math.Min(population[i].FiberSpaceBetween, population[j].FiberSpaceBetween);
                    Cmax = Math.Max(population[i].FiberSpaceBetween, population[j].FiberSpaceBetween);
                    alphaDeltaC = p.GA_Settings.CrossingoverAlphaParam * (Cmax - Cmin);

                    // Определяем границы изменения значения хромосомы
                    Cmin = Cmin - alphaDeltaC >= p.Limits.MinFiberSpaceBetween ? Cmin - alphaDeltaC : p.Limits.MinFiberSpaceBetween;
                    Cmax = Cmax + alphaDeltaC <= p.Limits.MaxFiberSpaceBetween ? Cmax + alphaDeltaC : p.Limits.MaxFiberSpaceBetween;

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
            double prob;
            foreach (Composite c in population)
            {
                prob = RandomValue.RandomDouble(rnd, 0, 1);
                if(prob < mutationProbability) // мутация
                { 
                    // Ширина
                    c.FiberWidth += RandomValue.RandomDouble(rnd, mutationRange.Item1, mutationRange.Item2);
                    if (c.FiberWidth > p.Limits.MaxFiberWidth) c.FiberWidth = p.Limits.MaxFiberWidth;
                    else if (c.FiberWidth < p.Limits.MinFiberWidth) c.FiberWidth = p.Limits.MinFiberWidth;

                    // Толщина
                    c.FiberThickness += RandomValue.RandomDouble(rnd, mutationRange.Item1, mutationRange.Item2);
                    if (c.FiberThickness > p.Limits.MaxFiberThickness) c.FiberThickness = p.Limits.MaxFiberThickness;
                    else if (c.FiberThickness < p.Limits.MinFiberThickness) c.FiberThickness = p.Limits.MinFiberThickness;

                    // Расстояние между волокнами
                    c.FiberSpaceBetween += RandomValue.RandomDouble(rnd, mutationRange.Item1, mutationRange.Item2);
                    if (c.FiberSpaceBetween > p.Limits.MaxFiberSpaceBetween) c.FiberSpaceBetween = p.Limits.MaxFiberSpaceBetween;
                    else if (c.FiberSpaceBetween < p.Limits.MinFiberSpaceBetween) c.FiberSpaceBetween = p.Limits.MinFiberSpaceBetween;
                }
            }
        }

        void SaveCurrentPopulation()
        {
            DB.SaveComposites(population);
        }

        public void Start()
        {
            if(initialGeneration.Count > 0)
            {
                currentGeneration = initialGeneration[0].Generation;
                UpdateStatus(new SimulationStatus()
                {
                    InProcess = true,
                    CurrentGeneration = currentGeneration,
                    CurrentIndividualInGeneration = 1
                });
                population = initialGeneration;
            }
            else
            {
                currentGeneration = 1;
                UpdateStatus(new SimulationStatus()
                {
                    InProcess = true,
                    CurrentGeneration = currentGeneration,
                    CurrentIndividualInGeneration = 1
                });
                GeneratePopulation();
                GetFitnessValues();
                SaveCurrentPopulation();
            }

            while (currentGeneration < p.GA_Settings.MaxGenerations && !STOP)
            {
                currentGeneration++;
                TourneySelection();
                Crossingover();
                Mutation();
                GetFitnessValues();
                SaveCurrentPopulation();
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
            this.p = p;
            STOP = false;
            mutationProbability = 1 / (2 * p.GA_Settings.PopulationSize);

            initialGeneration = p.Composites
                .OrderByDescending(c => c.Generation)
                .Take(p.GA_Settings.PopulationSize)
                .ToList();

            numberInProject = p.Composites.Count;
        }
    }
}
