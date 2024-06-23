﻿using Itjp.Ijcad.ApplicationServices;
using Itjp.Ijcad.DatabaseServices;
using Itjp.Ijcad.EditorInput;
using Itjp.Ijcad.Runtime;

namespace addcircle
{
    public class Class1
    {
        [CommandMethod("CSADDCIRCLE")]
        public void cmdAddCircle()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            PromptPointResult re1 = ed.GetPoint("円の中心を指定: ");
            if (re1.Status != PromptStatus.OK)
                return;
            PromptDistanceOptions opt = new PromptDistanceOptions("半径を指定");
            opt.DefaultValue = System.Convert.ToDouble(Application.GetSystemVariable("CIRCLERAD"));
            opt.UseDefaultValue = true;
            opt.BasePoint = re1.Value;
            opt.UseBasePoint = true;
            opt.AllowNegative = false;
            opt.AllowZero = false;
            PromptDoubleResult re2 = ed.GetDistance(opt);
            if(re2.Status != PromptStatus.OK)
                return;
            using(Transaction tr = doc.TransactionManager.StartTransaction())
            {
                try
                {
                    Database db = doc.Database;
                    BlockTableRecord space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                    Circle ent = new Circle();
                    ent.SetDatabaseDefaults(db);
                    ent.Center = re1.Value;
                    ent.Radius = re2.Value;
                    space.AppendEntity(ent);
                    tr.AddNewlyCreatedDBObject(ent, true);
                    tr.Commit();
                    Application.SetSystemVariable("CIRCLERAD", re2.Value);
                }
                catch (Exception ex)
                {
                    ed.WriteMessage(ex.Message);
                }
            }
        }
    }
}
