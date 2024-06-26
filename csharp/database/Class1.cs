using Itjp.Ijcad.ApplicationServices;
using Itjp.Ijcad.DatabaseServices;
using Itjp.Ijcad.EditorInput;
using Itjp.Ijcad.Geometry;
using Itjp.Ijcad.GraphicsInterface;
using Itjp.Ijcad.Runtime;
using System;

namespace hellocs
{
    public class Class1
    {
        [CommandMethod("CSADDRECORDS")]
        public void cmdAddTableRecords()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;

            //APPID[アプリケーション ID](DXF)
            using(Transaction tr = doc.TransactionManager.StartTransaction()) {
                RegAppTable tbl = tr.GetObject(db.RegAppTableId, OpenMode.ForWrite) as RegAppTable;
                if(!tbl.Has("TEST"))
                {
                    RegAppTableRecord rec = new RegAppTableRecord();
                    rec.Name = "TEST";
                    tbl.Add(rec);
                    tr.AddNewlyCreatedDBObject(rec,true);
                    ed.WriteMessage("\nAdd {0} {1}[{2}]",rec.GetRXClass().Name, rec.Name,rec.Handle);
                }
                tr.Commit();
            }

            //BLOCK_RECORD[ブロック レコード](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                BlockTable tbl = tr.GetObject(db.BlockTableId, OpenMode.ForWrite) as BlockTable;
                if (!tbl.Has("TEST"))
                {
                    BlockTableRecord rec = new BlockTableRecord();
                    rec.Name = "TEST";
                    tbl.Add(rec);
                    tr.AddNewlyCreatedDBObject(rec, true);
                    ed.WriteMessage("\nAdd {0} {1}[{2}]", rec.GetRXClass().Name, rec.Name, rec.Handle);
                    Line ent = new Line();
                    ent.SetDatabaseDefaults(db);
                    ent.StartPoint = new Point3d(0,0,0);
                    ent.EndPoint = new Point3d(10, 10, 0);
                    rec.AppendEntity(ent);
                    tr.AddNewlyCreatedDBObject(ent, true);
                    ed.WriteMessage("\nAdd {0}[{1}]", ent.GetRXClass().Name, ent.Handle);
                }
                tr.Commit();
            }

            //DIMSTYLE[寸法スタイル](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                DimStyleTable tbl = tr.GetObject(db.DimStyleTableId, OpenMode.ForWrite) as DimStyleTable;
                if (!tbl.Has("TEST"))
                {
                    DimStyleTableRecord rec = new DimStyleTableRecord();
                    rec.CopyFrom(db.GetDimstyleData());
                    rec.Name = "TEST";
                    tbl.Add(rec);
                    tr.AddNewlyCreatedDBObject(rec, true);
                    ed.WriteMessage("\nAdd {0} {1}[{2}]", rec.GetRXClass().Name, rec.Name, rec.Handle);
                }
                tr.Commit();
            }

            //LAYER[画層](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                LayerTable tbl = tr.GetObject(db.LayerTableId, OpenMode.ForWrite) as LayerTable;
                if (!tbl.Has("TEST"))
                {
                    LayerTableRecord rec = new LayerTableRecord();
                    rec.Name = "TEST";
                    tbl.Add(rec);
                    tr.AddNewlyCreatedDBObject(rec, true);
                    ed.WriteMessage("\nAdd {0} {1}[{2}]", rec.GetRXClass().Name, rec.Name, rec.Handle);
                }
                tr.Commit();
            }

            //LTYPE[線種](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                LinetypeTable tbl = tr.GetObject(db.LinetypeTableId, OpenMode.ForWrite) as LinetypeTable;
                if (!tbl.Has("TEST"))
                {
                    LinetypeTableRecord rec = new LinetypeTableRecord();
                    rec.Name = "TEST";
                    rec.NumDashes = 2;
                    rec.SetDashLengthAt(0, 12.0);
                    rec.SetDashLengthAt(1, -6.0);
                    tbl.Add(rec);
                    tr.AddNewlyCreatedDBObject(rec, true);
                    ed.WriteMessage("\nAdd {0} {1}[{2}]", rec.GetRXClass().Name, rec.Name, rec.Handle);
                }
                tr.Commit();
            }

            //STYLE[文字スタイル](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                TextStyleTable tbl = tr.GetObject(db.TextStyleTableId, OpenMode.ForWrite) as TextStyleTable;
                if (!tbl.Has("TEST"))
                {
                    TextStyleTableRecord rec = new TextStyleTableRecord();
                    rec.Name = "TEST";
                    rec.Font = new FontDescriptor("MS UI Gothic", false, false, 128, 0);
                    tbl.Add(rec);
                    tr.AddNewlyCreatedDBObject(rec, true);
                    ed.WriteMessage("\nAdd {0} {1}[{2}]", rec.GetRXClass().Name, rec.Name, rec.Handle);
                }
                tr.Commit();
            }

            //UCS[ユーザ座標系](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                UcsTable tbl = tr.GetObject(db.UcsTableId, OpenMode.ForWrite) as UcsTable;
                if (!tbl.Has("TEST"))
                {
                    UcsTableRecord rec = new UcsTableRecord();
                    rec.Name = "TEST";
                    rec.Origin = new Point3d(10, 10, 0);
                    rec.XAxis = Vector3d.XAxis.RotateBy(Math.PI / 45, Vector3d.ZAxis);
                    rec.YAxis = Vector3d.YAxis.RotateBy(Math.PI / 45, Vector3d.ZAxis);
                    tbl.Add(rec);
                    tr.AddNewlyCreatedDBObject(rec, true);
                    ed.WriteMessage("\nAdd {0} {1}[{2}]", rec.GetRXClass().Name, rec.Name, rec.Handle);
                }
                tr.Commit();
            }

            //VIEW[ビュー](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                ViewTable tbl = tr.GetObject(db.ViewTableId, OpenMode.ForWrite) as ViewTable;
                if (!tbl.Has("TEST"))
                {
                    ViewTableRecord rec = new ViewTableRecord();
                    rec.Name = "TEST";
                    tbl.Add(rec);
                    tr.AddNewlyCreatedDBObject(rec, true);
                    ed.WriteMessage("\nAdd {0} {1}[{2}]", rec.GetRXClass().Name, rec.Name, rec.Handle);
                }
                tr.Commit();
            }

            //VPORT[ビューポート](DXF)
            //VPORTはVPORTコマンドで作成したほうがよい
            //using (Transaction tr = doc.TransactionManager.StartTransaction())
            //{
            //    ViewportTable tbl = tr.GetObject(db.ViewportTableId, OpenMode.ForWrite) as ViewportTable;
            //    if (!tbl.Has("TEST"))
            //    {
            //        ViewportTableRecord rec = new ViewportTableRecord();
            //        tbl.Add(rec);
            //        tr.AddNewlyCreatedDBObject(rec, true);
            //        ed.WriteMessage("\nAdd {0} {1}[{2}]", rec.GetRXClass().Name, rec.Name, rec.Handle);
            //    }
            //    tr.Commit();
            //}

        }

        [CommandMethod("CSADDENTS")]
        public void cmdAddEntities()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;

            //3DFACE[3D 面](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new Face();
                ent.SetDatabaseDefaults(db);
                ent.SetVertexAt(0, new Point3d(0, 0, 0));
                ent.SetVertexAt(1, new Point3d(10, 0, 0));
                ent.SetVertexAt(2, new Point3d(10,10, 0));
                ent.SetVertexAt(3, new Point3d(0, 10, 0));
                var space = tr.GetObject(db.CurrentSpaceId,OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }

            //3DSOLID[3D ソリッド](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new Solid3d();
                ent.SetDatabaseDefaults(db);
                ent.CreateBox(10,10,10);
                var tfm = Matrix3d.Displacement(new Vector3d(25, 5, 5));
                ent.TransformBy(tfm);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }

            //ACAD_PROXY_ENTITY(DXF)
            //ARC(DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new Arc();
                ent.SetDatabaseDefaults(db);
                ent.Center = new Point3d(30,0,0);
                ent.Radius = 5;
                ent.StartAngle = 0;
                ent.EndAngle = Math.PI;
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //ATTDEF[属性定義](DXF)
            //ATTRIB[属性](DXF)
            //BODY(DXF)
            //CIRCLE[円](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new Circle();
                ent.SetDatabaseDefaults(db);
                ent.Center = new Point3d(40, 0, 0);
                ent.Radius = 5;
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //COORDINATION MODEL(DXF)
            //DIMENSION[寸法](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55,8,0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //ELLIPSE[楕円](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new Ellipse();
                ent.SetDatabaseDefaults(db);
                ent.Set(new Point3d(65, 0, 0), Vector3d.ZAxis, new Vector3d(5,5,0), 0.8, 0, 2 * Math.PI);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //HATCH[ハッチング](DXF)
            //HELIX[らせん](DXF)
            //IMAGE[イメージ](DXF)
            //INSERT[ブロック挿入](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var tbl = tr.GetObject(db.BlockTableId,OpenMode.ForRead) as BlockTable;
                if(tbl.Has("TEST"))
                {
                    var recId = tbl["TEST"];
                    var ent = new BlockReference(new Point3d(0, 30, 0), recId);
                    ent.SetDatabaseDefaults(db);
                    var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                    space.AppendEntity(ent);
                    tr.AddNewlyCreatedDBObject(ent, true);
                    ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                }
                tr.Commit();
            }
            //LEADER[引出線](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new Leader();
                ent.SetDatabaseDefaults(db);
                ent.SetVertexAt(0,new Point3d(10, 30, 0));
                ent.SetVertexAt(1,new Point3d(15, 35, 0));
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            /*
            //LIGHT[光源](DXF)
            //LINE[線分](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //LWPOLYLINE(DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //MESH(DXF)
            //MLEADER[マルチ引出線](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //MLEADERSTYLE(DXF)
            //MLINE[マルチライン](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //MTEXT[マルチ テキスト](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //OLEFRAME[OLE フレーム](DXF)
            //OLE2FRAME(DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //POINT[点](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //POLYLINE[ポリライン](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //RAY[放射線](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //REGION[リージョン](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //SECTION[断面](DXF)
            //SEQEND[シーケンス終了](DXF)
            //SHAPE(DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //SOLID(DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //SPLINE[スプライン](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //SUN(DXF)
            //SURFACE[サーフェス](DXF)
            //TABLE(DXF)
            //TEXT[文字記入](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //TOLERANCE[幾何公差](DXF)
            //TRACE[太線](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //UNDERLAY[アンダーレイ](DXF)
            //VERTEX(DXF)
            //VIEWPORT(DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //WIPEOUT[ワイプアウト](DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            //XLINE(DXF)
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var ent = new RotatedDimension();
                ent.SetDatabaseDefaults(db);
                ent.XLine1Point = new Point3d(50, 0, 0);
                ent.XLine2Point = new Point3d(60, 0, 0);
                ent.DimLinePoint = new Point3d(55, 8, 0);
                var space = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                space.AppendEntity(ent);
                tr.AddNewlyCreatedDBObject(ent, true);
                ed.WriteMessage("\nAdd {0}[{1}]", ent.GetType().Name, ent.Handle);
                tr.Commit();
            }
            */
        }

        [CommandMethod("CSADDOBJS")]
        void cmdAddDatabaseObjects()
        {
            //ACAD_PROXY_OBJECT[ACAD プロキシ オブジェクト](DXF)
            //ACDBDICTIONARYWDFLT(DXF)
            //ACDBPLACEHOLDER(DXF)
            //ACDBNAVISWORKSMODELDEF(DXF)
            //DATATABLE[データ テーブル](DXF)
            //DICTIONARY[ディクショナリ](DXF)
            //DICTIONARYVAR[ディクショナリ変数](DXF)
            //DIMASSOC[自動調整管理](DXF)
            //FIELD[フィールド](DXF)
            //GEODATA(DXF)
            //GROUP[グループ](DXF)
            //IDBUFFER[ID バッファ](DXF)
            //IMAGEDEF[イメージ定義](DXF)
            //IMAGEDEF_REACTOR[イメージ定義リアクタ](DXF)
            //LAYER_FILTER[画層フィルタ](DXF)
            //LAYER_INDEX[画層インデックス](DXF)
            //LAYOUT[レイアウト](DXF)
            //LIGHTLIST[光源一覧](DXF)
            //MATERIAL[マテリアル](DXF)
            //MLINESTYLE[マルチライン スタイル](DXF)
            //OBJECT_PTR[オブジェクト プリンタ](DXF)
            //PLOTSETTINGS[印刷設定](DXF)
            //RASTERVARIABLES[ラスター変数](DXF)
            //RENDER(DXF)
            //SECTION[断面](DXF)
            //SORTENTSTABLE[SORTENTS テーブル](DXF)
            //SPATIAL_FILTER[空間フィルタ](DXF)
            //SPATIAL_INDEX[空間インデックス](DXF)
            //SUNSTUDY[日照シミュレーション](DXF)
            //TABLESTYLE[表スタイル](DXF)
            //UNDERLAYDEFINITION[アンダーレイ定義](DXF)
            //VBA_PROJECT[VBA プロジェクト](DXF)
            //VISUALSTYLE[表示スタイル](DXF)
            //WIPEOUTVARIABLES(DXF)
            //XRECORD[拡張レコード](DXF)
        }
    }
}
