;;; (C) 2024 CAD Khan all rights reserved.
;;;
;;; addCircle.lsp
;;;

(defun C:ADDCIRCLE1 ()
  (command "CIRCLE" '(0.0 0.0 0.0) 10.0)
  (princ)
)

(defun C:ADDCIRCLE2 ()
  (entmake (list (cons 0  "CIRCLE")(cons 10 (list 20.0 0.0 0.0))(cons 40 10.0)))
  (entmake '((0 . "CIRCLE")(10 40.0 0.0 0.0)(40 . 10.0)))
  (princ)
)

(defun C:ADDCIRCLE3 ( / app doc model circle )
  (setq app (vlax-get-acad-object))
  (setq doc (vla-get-ActiveDocument app))
  (setq model (vla-get-ModelSpace doc))
  (setq circle (vla-AddCircle model (vlax-3d-point (list 60.0 0.0 0.0)) 10.0))
  (princ)
)

;|
  図形を作成する方法、３通り。
  command 関数で　CIRCLE コマンドを呼び出す。

  '( 0.0 0.0 0.0) の ’ はクォートと呼び、次のリストをデータとして処理することを意味する
  式かデータか、式は最初の引数は関数名で、残りは引数になる。
  データはリストそのものがデータである。

  entmake 関数で円を描く方法２つ。
  最初のは、クォートを使っていない。list 関数と cons 関数でリストを作っている
  ２行めは、クォートを使った例。
  図形を含むデータベースオブジェクトを作成するには最小限必要な値を与えればよい。
  その場合、画層(8)、線種(6)、線色(62)、線幅(370)などは図面の現在の値を利用する。

  オートメーションで円を描く方法
  vla-get-acad-object 関数。すべてのオートメーションの基点である、アプリケーションオブジェクトを取得。
  vla-get-ActiveDocument 関数。vla-get-プロパティ名は、オブジェクトのプロパティを取得する。アクティブなドキュメント オブジェクトを取得した。
  vla-get-ModelSpace 関数。アクティブなドキュメントのモデル空間ブロックを取得した。
  vla-AddCircle 関数 vla-メソッド名は、オブジェクトのメソッドを呼び出す。
  座標はLISPでは３つの要素のリストだが、オートメーションではセーフ配列で保持する。vlax-3d-point は座標を示すセーフ配列を作成する。
  以上で、図形の作り方には、command関数を呼ぶ方法、entmake関数を呼ぶ方法、Add-図形名 関数を呼ぶ方法があることがわかる。
|;