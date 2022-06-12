using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeGUI
{
    public static class Main
    {
        //Описание делегата - обработчика события
        public delegate void ProjectChangedEventHandler();

        public delegate void SimulationStatusChangedEventHandler();

        //Событие 
        public static event ProjectChangedEventHandler ProjectChanged;

        public static event SimulationStatusChangedEventHandler SimulationStatusChanged;


        private static Project currentProject;

        private static SimulationStatus status = new SimulationStatus();

        public static List<Project> ProjectList = new List<Project>();

        public static Project CurrentProject
        {
            get
            {
                return currentProject;
            }
            set
            {
                currentProject = value;
                //При изменении данных свойства
                ProjectChanged();
            }
        }

        public static SimulationStatus Status()
        {
            return status;
        }

        public static bool InProcess()
        {
            return status.InProcess;
        }

        public static int CurrentGeneration()
        {
            return status.CurrentGeneration;
        }

        public static int CurrentIndividual()
        {
            return status.CurrentIndividualInGeneration;
        }

        public static SimulationStatus SetStatus(SimulationStatus s)
        {
            status = s;
            SimulationStatusChanged();
            return status;
        }
        public static bool SetInProcess(bool val)
        {
            status.InProcess = val;
            SimulationStatusChanged();
            return status.InProcess;
        }
        public static int SetCurrentGeneration(int val)
        {
            status.CurrentGeneration = val;
            SimulationStatusChanged();
            return status.CurrentGeneration;
        }
        public static int SetCurrentIndividual(int val)
        {
            status.CurrentIndividualInGeneration = val;
            SimulationStatusChanged();
            return status.CurrentIndividualInGeneration;
        }

    }
}
