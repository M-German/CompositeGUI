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

        //Событие 
        public static event ProjectChangedEventHandler ProjectChanged;

        private static Project currentProject;

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
    }
}
