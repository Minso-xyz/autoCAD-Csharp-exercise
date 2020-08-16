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

        [CommandMethod("MyFirstLayer")]
        public void cmdMyFirst()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            Database db = HostApplicationServices.WorkingDatabase;
            ObjectId lyrTblId = db.LayerTableId;
            Transaction trans = db.TransactionManager.StartTransaction();

            try
            {
                //Write code below here
                LayerTable lyrTbl = trans.GetObject(lyrTblId, OpenMode.ForWrite) as LayerTable;
                string lyrName = "MyNewLayer";
                if (IsLayerExists(trans, lyrTbl, lyrName) == false)
                {
                    LayerTableRecord lyrTblRec = new LayerTableRecord();
                    lyrTblRec.Name = lyrName;
                    lyrTbl.Add(lyrTblRec);
                    trans.AddNewlyCreatedDBObject(lyrTblRec, true);
                }
                else
                {
                    ed.WriteMessage("Layer " + lyrName + " already exists in the drawing");
                }

            }
            catch (Autodesk.AutoCAD.Runtime.Exception ex)
            {
                Application.ShowAlertDialog("Error in creating layer\n" + ex.Message);
            }

            trans.Commit();
        }

        #endregion

        #region Support Functions

        private Boolean IsLayerExists(Transaction CurrentTransaction, LayerTable Layers, String LayerName)
        {
            LayerTableRecord lyrObj;
            foreach (ObjectId lyrId in Layers)
            {
                lyrObj = CurrentTransaction.GetObject(lyrId, OpenMode.ForRead) as LayerTableRecord;
                if (lyrObj.Name == LayerName) return true;
            }
            return false;
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
