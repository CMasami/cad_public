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
            //3DFACE[3D 面](DXF)
            //3DSOLID[3D ソリッド](DXF)
            //ACAD_PROXY_ENTITY(DXF)
            //ARC(DXF)
            //ATTDEF[属性定義](DXF)
            //ATTRIB[属性](DXF)
            //BODY(DXF)
            //CIRCLE[円](DXF)
            //COORDINATION MODEL(DXF)
            //DIMENSION[寸法](DXF)
            //ELLIPSE[楕円](DXF)
            //HATCH[ハッチング](DXF)
            //HELIX[らせん](DXF)
            //IMAGE[イメージ](DXF)
            //INSERT[ブロック挿入](DXF)
            //LEADER[引出線](DXF)
            //LIGHT[光源](DXF)
            //LINE[線分](DXF)
            //LWPOLYLINE(DXF)
            //MESH(DXF)
            //MLEADER[マルチ引出線](DXF)
            //MLEADERSTYLE(DXF)
            //MLINE[マルチライン](DXF)
            //MTEXT[マルチ テキスト](DXF)
            //OLEFRAME[OLE フレーム](DXF)
            //OLE2FRAME(DXF)
            //POINT[点](DXF)
            //POLYLINE[ポリライン](DXF)
            //RAY[放射線](DXF)
            //REGION[リージョン](DXF)
            //SECTION[断面](DXF)
            //SEQEND[シーケンス終了](DXF)
            //SHAPE(DXF)
            //SOLID(DXF)
            //SPLINE[スプライン](DXF)
            //SUN(DXF)
            //SURFACE[サーフェス](DXF)
            //TABLE(DXF)
            //TEXT[文字記入](DXF)
            //TOLERANCE[幾何公差](DXF)
            //TRACE[太線](DXF)
            //UNDERLAY[アンダーレイ](DXF)
            //VERTEX(DXF)
            //VIEWPORT(DXF)
            //WIPEOUT[ワイプアウト](DXF)
            //XLINE(DXF)
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
