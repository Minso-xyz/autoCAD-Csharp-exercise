using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;

namespace AU.MySoftware
{
    public class Initialization : IExtensionApplication
    {
        #region Commands

        [CommandMethod("MyFirstCommand")]
        public void cmdMyFirst()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("\nI have created my first command.");
        }

        #endregion


        #region Initialization

        void IExtensionApplication.Initialize()
        {

        }

        void IExtensionApplication.Terminate()
        {

        }
        #endregion

    }
}