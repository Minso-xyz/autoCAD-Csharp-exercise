using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace AU.MySoftware
{
    public class Initialization : IExtensionApplication
    {
        #region Commands

        [CommandMethod("MyFirstLine")]
        public void cmdMyFirst()
        {
            //Enter code below this line


            //Enter code above this line

            Database db = HostApplicationServices.WorkingDatabase;
            Transaction trans = db.TransactionManager.StartTransaction();

            BlockTable blkTbl = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
            BlockTableRecord msBlkRec = trans.GetObject(blkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

           
            Line lineObj = new Line(pnt1, pnt2);
            msBlkRec.AppendEntity(lineObj);
            trans.AddNewlyCreatedDBObject(lineObj, true);

            trans.Commit();
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
