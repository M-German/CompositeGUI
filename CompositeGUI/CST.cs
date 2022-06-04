using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeGUI
{
    class CST
    {
        Type cstAppType;
        object cstApp;

        object InvokeCST(object parent, string command, string attr)
        {
            return cstAppType.InvokeMember(command, BindingFlags.InvokeMethod, null, parent, new object[] { attr });
        }

        public CST()
        {
            cstAppType = Type.GetTypeFromProgID("CSTStudio.Application.2018");
            cstApp = Activator.CreateInstance(cstAppType);
        }

        public void Test()
        {
            object cstProject = InvokeCST(cstApp, "OpenFile", @"C:\Users\German\Desktop\Учеба\ЭМС лабы\latest_Лаба 4\lab4.cst");
        }
    }
}
