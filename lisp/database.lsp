;;; (C) 2024 CAD Khan all rights reserved.
;;;
;;; hello.lsp
;;;

(defun C:LSPAddRecs()
	;;APPID[アプリケーション ID](DXF)
  ;; アプリケーションID登録のための regapp 関数を使う
  ;; 追加できたときは名前を、既にあるときは nil を返す
  (if (not (tblsearch "APPID" "TEST"))
    (regapp "TEST")
  )
	;;BLOCK_RECORD[ブロック レコード](DXF)
  ;; BLOCK ブロック内の図形 ENDBLK を続けて entmake する
  ;; ブロックの置き換えも同じ方法で行う
  (if (not (tblsearch "BLOCK" "TEST"))
    (progn
      (entmake '((0 . "BLOCK")(2 . "TEST") (10 0.0 0.0 0.0)))
      (entmake '((0 . "LINE")(8 . "0")(6 . "ByBlock")(62 . 0)(10 -5 -5 0)(11 5 5 0)))
      (entmake '((0 . "LINE")(8 . "0")(6 . "ByBlock")(62 . 0)(10 -5 5 0)(11 5 -5 0)))
      (entmake '((0 . "ENDBLK")))
    )
  )
	;;DIMSTYLE[寸法スタイル](DXF)
  ;; IJCADでは Standard 寸法スタイルと同じものが作られる
  (if (not (tblsearch "DIMSTYLE" "TEST"))
    (entmake '((0 . "DIMSTYLE")(2 . "TEST")))
  )
	;;LAYER[画層](DXF)
  (if (not (tblsearch "LAYER" "TEST"))
    (entmake '((0 . "LAYER")(2 . "TEST")))
  )
	;;LTYPE[線種](DXF)
  ;;線種パターンを指定しないと実線ができる
  (if (not (tblsearch "LTYPE" "TEST"))
    (entmake '((0 . "LTYPE")(2 . "TEST")(73 . 2)(40 . 18.0)(49 . 12.0)(49 . -6.0)))
  )
	;;STYLE[文字スタイル](DXF)
  ;; シェイプフォントとビッグフォントを指定する
  (if (not (tblsearch "STYLE" "TEST"))
    (entmake '((0 . "STYLE")(2 . "TEST")(3 . "exthalf2.shx")(4 . "extfont2.shx")))
  )
  ;; TrueTypeフォントを指定する。
  ;; IJCAD は TTF/TTCファイルを指定する必要あり。
  (if (not (tblsearch "STYLE" "TTF"))
    (entmake '((0 . "STYLE")(2 . "TTF")(3 . "MSGothic.ttc")(-3 ("ACAD" (1000 . "MS Gothic")(1071 . 0 )))))
  )
	;;UCS[ユーザ座標系](DXF)
  ;;UCS原点、X方向、Y方向を指定しないとWCSと同じものができる。
  (if (not (tblsearch "UCS" "TEST"))
    (entmake '((0 . "UCS")(2 . "TEST")(10 0.0 0.0 0.0)(11 0.0 1.0 0.0)(12 1.0 0.0 0.0)))
  )
	;;VIEW[ビュー](DXF)
  ;;現在の標示画面を名前の付いたビュー TESTとして保存するなら次のようにする
  (if (not (tblsearch "VIEW" "TEST"))
    (command "-VIEW" "Save" "TEST")
  )
	;;VPORT[ビューポート](DXF)
  ;;名前のついたタイルビューポートはコマンドで作ったほうがよい
  (setvar "TILEMODE" 1)
  (if (not (tblsearch "VPORT" "TEST"))
    (command "VPORTS" "2" "V" "VPORTS" "S" "TEST" "VPORTS" "SI")
  )
  ;式の戻り値 nil の表示を抑制する
  (princ)
)

(defun C:LSPAddEnts()
	;;3DFACE[3D 面](DXF)
  (entmake '((0 . "3DFACE")(10 0.0 0.0 0.0)(11 1.0 0.0 0.0)(12 1.0 1.0 0.0)(13 0.0 1.0 0.0)))
	;;3DSOLID[3D ソリッド](DXF)
  ;;基本形ならコマンドで作成することが可能です
  (command "BOX" '(0.0 0.0 0.0) '(10.0 10.0 0.0) 10.0 )
  (command "PYRAMID" '(0.0 0.0 0.0) 10.0 20.0 )
  (command "CYLINDER" '(0.0 0.0 0.0) 10.0 20.0 )
  (command "CONE" '(0.0 0.0 0.0) 10.0 20.0 )
  (command "SPHERE" '(0.0 0.0 0.0) 10.0 )
  (command "WEDGE" '(0.0 0.0 0.0) '(10.0 10.0 0.0) 20.0)
  (command "TORUS" '(0.0 0.0 0.0) 20.0 5.0)
  (command "POLYSOLID" '(0.0 0.0 0.0) '(10.0 0.0 0.0) '(10.0 10.0 0.0) "")	
	;;ACAD_PROXY_ENTITY(DXF)
  ;;カスタム図形のアプリケーションが存在しないときに出現します。
  ;;LISPで作る方法はありません。
	;;ARC(DXF)
  ;;開始角度、終了角度の単位はラジアン
  (entmake '((0 . "ARC")(10 0.0 0.0 0.0)(40 . 5.0)(50 . 0.0)(51 . 1.0)))
	;;ATTDEF[属性定義](DXF)
  ;;位置合わせを省略すると 0=左 0=基準線になる
  (entmake '((0 . "ATTDEF")(10 0.0 0.0 0.0)(40 . 2.5)(1 . "something to enter.")(2 . "TEST")))
	;;BODY(DXF)
  ;;最小限のLISP式では作れない。
	;;CIRCLE[円](DXF)
  (entmake '((0 . "CIRCLE")(10 0.0 0.0 0.0)(40 . 5.0)))
	;;COORDINATION MODEL(DXF)
  ;;Navis Works からインポートされる図形らしい
	;;DIMENSION[寸法](DXF)
  ;;0 = 回転、水平、または垂直寸法
  ;;角度は省略されていると水平寸法になる
  ;;垂直寸法は 90°で回転寸法はその角度を指定する
  (entmake '((0 . "DIMENSION")(70 . 0)(10 5.0 10.0 0.0)(13 0.0 0.0 0.0)(14 10.0 0.0 0.0)))
  (entmake  (append '((0 . "DIMENSION")(70 . 0)(10 90.0 50.0 0.0)(13 100.0 0.0 0.0)(14 100.0 100.0 0.0)) (list (cons 50 (/ PI 2.0)))))
  ;;1 = 平行寸法
  (entmake '((0 . "DIMENSION")(70 . 1)(10 5.0 10.0 0.0)(13 0.0 0.0 0.0)(14 10.0 0.0 0.0)))
  ;;2 = 角度２線寸法 計測した線分の始点(15)・終点(10)、始点(14)・終点(13) と寸法円弧上の点(16)
  (entmake '((0 . "DIMENSION") (70 . 2) (10 17.339 5.24438 0.0) (13 4.99755 12.9437 0.0) (14 9.30009 6.48986 0.0) (15 9.30009 6.48986 0.0) (16 19.0327 13.396 0.0)))
  ;;3 = 直径寸法 円の中心を通る直線上の２点
  (entmake '((0 . "DIMENSION")(70 . 3)(10 5.0 0.0 0.0)(15 -5.0 0.0 0.0)))
  ;;4 = 半径寸法 中心と円周上の点
  (entmake '((0 . "DIMENSION")(70 . 4)(10 0.0 0.0 0.0)(15 0.0 5.0 0.0)))
  ;;5 = 角度 3 点寸法 寸法円弧上の点(10)、円弧の中心(15)、計測した円弧の両端点(13)、(14)
  (entmake '((0 . "DIMENSION")(70 . 5)(10 13.4575 17.7525 0.0) (13 11.4514 9.54692 0.0) (14 1.60082 13.5098 0.0) (15 5.30357 8.48952 0.0)))
  ;;6 = 座標寸法(X値) 70 = Y値
  (entmake '((0 . "DIMENSION") (70 . 6) (13 5.0 8.0 0.0) (14 20.0 8.0 0.0)))
  (entmake '((0 . "DIMENSION") (70 . 70) (13 5.0 8.0 0.0) (14 5.0 20.0 0.0)))
	;;ELLIPSE[楕円](DXF)
  (entmake '((0 . "ELLIPSE")(10 25.0 25.0 0.0)(11 10.0 0.0 0.0)(40 . 0.66667)))
  ;; 楕円弧は開始、終了パラメータも必要
  (entmake (append '((0 . "ELLIPSE")(10 25.0 25.0 0.0)(11 0.0 10.0 0.0)(40 . 0.66667)(41 . 0.0)) (list (cons 42 (/ PI 2.0)))))
	;;HATCH[ハッチング](DXF)
  ;; コマンドを使った方が簡単かと
  (command "RECTANGLE" '(0.0 0.0 0.0) '(20.0 20.0 0.0 ))
  (command "ZOOM" "OB" (entlast) "")
  (command "-HATCH" '(10.0 10.0 0.0) "")
	;;HELIX[らせん](DXF) 10 軸の基点 12 軸の方向 11 らせんの始点 40 半径 41 回転量 42 １回転あたりの高さ
  (entmake '((0 . "HELIX")(10 0.0 0.0 0.0)(11 1.0 0.0 0.0)(12 0.0 0.0 1.0)(40 . 1.0)(41 . 3.0)(42 . 1.0)))
	;;IMAGE[イメージ](DXF)
	;;INSERT[ブロック挿入](DXF)
	;;ATTRIB[属性](DXF)
	;;SEQEND[シーケンス終了](DXF)
  (if (tblsearch "BLOCK" "TEST")
    (progn
      (entmake '((0 . "INSERT")(2 . "TEST")(10 10.0 10.0 )(66 . 1)))
      (entmake '((0 . "ATTRIB")(2 . "TEST")(10 12.0 12.0 0.0)(1 . "Sample text")))
      (entmake '((0 . "SEQEND")))
    )
    (princ "\nNo block \"TEST\".")
  )
	;;LEADER[引出線](DXF)
  ;; 矢印フラグ(71)=有効(1),引き出し線(72)=直線(0),注釈(73)=なし(3) 頂点数(76)は無くても描ける
  (entmake '((0 . "LEADER")(10 323.0 10.5 0.0) (10 344.525 32.3898 0.0) (10 347.025 32.3898 0.0)))
	;;LIGHT[光源](DXF)
  ;; 白い光のスポットライトを作成します。照明の位置(10)と照明の目標点(11)は必須。
  (entmake '((0 . "LIGHT")(10 100.0 100.0 100.0) (11 0.0 0.0 0.0)))
	;;LINE[線分](DXF)
  (entmake '((0 . "LINE")(10 0.0 0.0 0.0)(11 1.0 1.0 0.0)))
	;;LWPOLYLINE(DXF)
  ;; ポリラインフラグ(70)を省略すると開いたポリラインになる
  (entmake '((0 . "LWPOLYLINE")(90 . 4)(10 174.5 10.5)(10 471.5 10.5)(10 471.5 -199.5)(10 174.5 -199.5)))
	;;MESH(DXF)
  ;;基本形ならコマンドで作成することが可能です
  (command "MESH" "BOX" '(0.0 0.0 0.0) '(10.0 10.0 0.0) 10.0 )
  (command "MESH" "CONE" '(0.0 0.0 0.0) 10.0 20.0 )
  (command "MESH" "CYLINDER" '(0.0 0.0 0.0) 10.0 20.0 )
  (command "MESH" "PYRAMID" '(0.0 0.0 0.0) 10.0 20.0 )
  (command "MESH" "SPHERE" '(0.0 0.0 0.0) 10.0 )
  (command "MESH" "WEDGE" '(0.0 0.0 0.0) '(10.0 10.0 0.0) 20.0)
  (command "MESH" "TORUS" '(0.0 0.0 0.0) 20.0 5.0)
	;;MLEADER[マルチ引出線](DXF)
  ;; H=arrow Head 引き出し線の矢印の位置、終点の位置、文字の内容 の順
  ;; L=Landing  引き出し線の終点の位置、矢印の位置、文字の内容 の順
  ;; C=Contents 文字の範囲と内容から指定するが command 関数ではうまくいかない。
  ;; 一度 Contents オプションに入ったら、MLEADER Contents が入力できない。
  (command "MLEADER" "H" '(0.0 0.0 0.0) '(10.0 10.0 0.0) "12345" )
  (command "MLEADER" "L" '(10.0 10.0 0.0) '(0.0 20.0 0.0) "Test" )
	;;MLINE[マルチライン](DXF)
  ;;がんばれはできそうだけど面倒なのでcommand関数から
  (command "MLINE" '(0.0 0.0 0.0) '(100.0 100.0 0.0) "")
	;;MTEXT[マルチ テキスト](DXF)
  ;;位置合わせを省略すると 1=左上になる
  (entmake '((0 . "MTEXT")(10 0.0 0.0 0.0)(40 . 2.5)(1 . "something else")))
	;;OLEFRAME[OLE フレーム](DXF)
  ;;今は作ることができません
	;;OLE2FRAME(DXF)
  ;;埋め込み型もリンク型もコマンドからしか作れません。DXFでは情報が不足です。
	;;POINT[点](DXF)
  (setvar "PDMODE" 3)
  (entmake '((0 . "POINT")(10 5.0 5.0 0.0)))
	;;POLYLINE[ポリライン](DXF)
	;;VERTEX(DXF)
	;;SEQEND[シーケンス終了](DXF)
  (entmake '((0 . "POLYLINE")( 70 . 1 )))
  (entmake '((0 . "VERTEX")(10 10.0 10.0 0.0)))
  (entmake '((0 . "VERTEX")(10 20.0 10.0 0.0)))
  (entmake '((0 . "VERTEX")(10 20.0 20.0 0.0)))
  (entmake '((0 . "VERTEX")(10 10.0 20.0 0.0)))
  (entmake '((0 . "SEQEND")))
	;;RAY[放射線](DXF)
  (entmake '((0 . "RAY")(10 20.0 0.0 0.0)(11 1.0 -1.0 0.0)))
	;;REGION[リージョン](DXF)
  ;;コマンドから作るしかありません。図形選択でループを構成する図形を複数選択できます。
  ;;ループが複数の場合、複数のリージョンができるので UNION や SUBTRACT で合成リージョンを作ります。
  (command "region" (ssget ":S"))
	;;SECTION[断面](DXF)
	;;SHAPE(DXF)
	;;SOLID(DXF)
  (entmake '((0 . "SOLID")(10 0.0 0.0 0.0)(11 1.0 0.0 0.0)(12 0.0 1.0 0.0)(13 1.0 1.0 0.0)))
	;;SPLINE[スプライン](DXF)
	;;SUN(DXF)
	;;SURFACE[サーフェス](DXF)
	;;TABLE(DXF)
	;;TEXT[文字記入](DXF)
  ;;位置合わせを省略すると 0=左 0=基準線になる
  (entmake '((0 . "TEXT")(10 0.0 0.0 0.0)(40 . 2.5)(1 . "something else")))
	;;TOLERANCE[幾何公差](DXF)
	;;TRACE[太線](DXF)
  (entmake '((0 . "TRACE")(10 0.0 0.0 0.0)(11 1.0 0.0 0.0)(12 0.0 1.0 0.0)(13 1.0 1.0 0.0)))
	;;UNDERLAY[アンダーレイ](DXF)
	;;WIPEOUT[ワイプアウト](DXF)
	;;XLINE(DXF)
  (entmake '((0 . "XLINE")(10 18.0 0.0 0.0)(11 1.0 -1.0 0.0)))
	;;VIEWPORT(DXF)
)

(defun C:LSPAddObjs()
	;;ACAD_PROXY_OBJECT[ACAD プロキシ オブジェクト](DXF)
	;;ACDBDICTIONARYWDFLT(DXF)
	;;ACDBPLACEHOLDER(DXF)
	;;ACDBNAVISWORKSMODELDEF(DXF)
	;;DATATABLE[データ テーブル](DXF)
	;;DICTIONARY[ディクショナリ](DXF)
	;;DICTIONARYVAR[ディクショナリ変数](DXF)
	;;DIMASSOC[自動調整管理](DXF)
	;;FIELD[フィールド](DXF)
	;;GEODATA(DXF)
	;;GROUP[グループ](DXF)
	;;IDBUFFER[ID バッファ](DXF)
	;;IMAGEDEF[イメージ定義](DXF)
	;;IMAGEDEF_REACTOR[イメージ定義リアクタ](DXF)
	;;LAYER_FILTER[画層フィルタ](DXF)
	;;LAYER_INDEX[画層インデックス](DXF)
	;;LAYOUT[レイアウト](DXF)
	;;LIGHTLIST[光源一覧](DXF)
	;;MATERIAL[マテリアル](DXF)
	;;MLEADERSTYLE[マルチ引き出し線スタイル](DXF) 
	;;MLINESTYLE[マルチライン スタイル](DXF)
	;;OBJECT_PTR[オブジェクト プリンタ](DXF)
	;;PLOTSETTINGS[印刷設定](DXF)
	;;RASTERVARIABLES[ラスター変数](DXF)
	;;RENDER(DXF)
	;;SECTION[断面](DXF)
	;;SORTENTSTABLE[SORTENTS テーブル](DXF)
	;;SPATIAL_FILTER[空間フィルタ](DXF)
	;;SPATIAL_INDEX[空間インデックス](DXF)
	;;SUNSTUDY[日照シミュレーション](DXF)
	;;TABLESTYLE[表スタイル](DXF)
	;;UNDERLAYDEFINITION[アンダーレイ定義](DXF)
	;;VBA_PROJECT[VBA プロジェクト](DXF)
	;;VISUALSTYLE[表示スタイル](DXF)
	;;WIPEOUTVARIABLES(DXF)
	;;XRECORD[拡張レコード](DXF)
)
