using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeGUI
{
    class GeneticAlgorithm
    {
        GA_Settings settings;
        bool hasMetalGrid;
        Material matrixMaterial;
        Material fiberMaterial;
        Limits limits;
        (double, double) frequency;
        double mutationProbability;

        int currentGeneration = 0;
        (double, double) mutationRange = (-0.3, 0.3);
        List<Composite> population;
        Random rnd = new Random();

        void GeneratePopulation()
        {
            this.population = new List<Composite>(settings.PopulationSize);
            for(int i=0; i < settings.PopulationSize; i++) { 
                Composite c = new Composite();
                c.LayerCount = RandomValue.RandomInt(rnd, limits.LayerCount.Item1, limits.LayerCount.Item2);
                c.FiberWidth = RandomValue.RandomDouble(rnd, limits.FiberWidth.Item1, limits.FiberWidth.Item2);
                c.FiberThickness = RandomValue.RandomDouble(rnd, limits.FiberThickness.Item1, limits.FiberThickness.Item2);
                c.FiberSpaceBetween = RandomValue.RandomDouble(rnd, limits.FiberSpaceBetween.Item1, limits.FiberSpaceBetween.Item2);

                this.population.Add(c);
            }
        }

        void GetFitnessValues()
        {
            foreach (Composite c in population)
            {
                c.ShieldingEfficiency = RandomValue.RandomDouble(rnd, 30, 40);
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
                    Cmin = Cmin - alphaDeltaC >= limits.FiberWidth.Item1 ? Cmin - alphaDeltaC : limits.FiberWidth.Item1;
                    Cmax = Cmax + alphaDeltaC <= limits.FiberWidth.Item2 ? Cmax + alphaDeltaC : limits.FiberWidth.Item2;
                    
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
                    Cmin = Cmin - alphaDeltaC >= limits.FiberThickness.Item1 ? Cmin - alphaDeltaC : limits.FiberThickness.Item1;
                    Cmax = Cmax + alphaDeltaC <= limits.FiberThickness.Item2 ? Cmax + alphaDeltaC : limits.FiberThickness.Item2;

                    // BLX-alpha crossingover
                    newOffspring.FiberThickness = RandomValue.RandomDouble(rnd, Cmin, Cmax);

                    //////////////////
                    // Расстояние между волокнами
                    Cmin = Math.Min(population[i].FiberSpaceBetween, population[j].FiberSpaceBetween);
                    Cmax = Math.Max(population[i].FiberSpaceBetween, population[j].FiberSpaceBetween);
                    alphaDeltaC = settings.CrossingoverAlphaParam * (Cmax - Cmin);

                    // Определяем границы изменения значения хромосомы
                    Cmin = Cmin - alphaDeltaC >= limits.FiberSpaceBetween.Item1 ? Cmin - alphaDeltaC : limits.FiberSpaceBetween.Item1;
                    Cmax = Cmax + alphaDeltaC <= limits.FiberSpaceBetween.Item2 ? Cmax + alphaDeltaC : limits.FiberSpaceBetween.Item2;

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
                    if (c.FiberWidth > limits.FiberWidth.Item2) c.FiberWidth = limits.FiberWidth.Item2;
                    else if (c.FiberWidth < limits.FiberWidth.Item1) c.FiberWidth = limits.FiberWidth.Item1;

                    // Толщина
                    c.FiberThickness += RandomValue.RandomDouble(rnd, mutationRange.Item1, mutationRange.Item2);
                    if (c.FiberThickness > limits.FiberThickness.Item2) c.FiberThickness = limits.FiberThickness.Item2;
                    else if (c.FiberThickness < limits.FiberThickness.Item1) c.FiberThickness = limits.FiberThickness.Item1;

                    // Расстояние между волокнами
                    c.FiberSpaceBetween += RandomValue.RandomDouble(rnd, mutationRange.Item1, mutationRange.Item2);
                    if (c.FiberSpaceBetween > limits.FiberSpaceBetween.Item2) c.FiberSpaceBetween = limits.FiberSpaceBetween.Item2;
                    else if (c.FiberSpaceBetween < limits.FiberSpaceBetween.Item1) c.FiberSpaceBetween = limits.FiberSpaceBetween.Item1;
                }
            }
        }

        public void Start()
        {
            GeneratePopulation();

            while (currentGeneration < settings.MaxGenerations)
            {
                GetFitnessValues();
                TourneySelection();

                if (currentGeneration + 1 < settings.MaxGenerations) // если текущее поколение не последнее
                {
                    Crossingover();
                    Mutation();
                }
                currentGeneration++;
            }
        }

        public GeneticAlgorithm(
            GA_Settings settings,
            bool hasMetalGrid,
            Material matrixMaterial,
            Material fiberMaterial,
            Limits limits,
            (double, double) frequency
        )
        {
            this.settings = settings;
            this.hasMetalGrid = hasMetalGrid;
            this.matrixMaterial = matrixMaterial;
            this.fiberMaterial = fiberMaterial;
            this.limits = limits;
            this.frequency = frequency;

            this.mutationProbability = 1 / (2 * settings.PopulationSize);
        }
    }
}
