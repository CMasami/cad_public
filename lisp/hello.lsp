;;; (C) 2024 CAD Khan all rights reserved.
;;;
;;; hello.lsp
;;;

(defun C:HELLO ()
  (princ "\nHello, World.")
  (princ)
)

(defun C:HELLOMSG ()
  (alert "Hello, World.")
  (princ)
)

;|
  LISPの関数を定義するには、defun 関数を使います。
 (defun 関数名 引数リスト  関数本体 )

  LISPの関数をコマンドとして定義するには、関数名を C:コマンド名 とします。
  上記の例では２つのコマンド HELLO と HELLOMSG が定義されます。

  princ 関数は引数をコマンドウィンドウに表示します。
  (princ 値)
  戻り値は値そのものです。
  (princ)
  引数無しの princ 関数は戻り値の表示を抑制するのに使います。

  alert 関数は警告ダイアログを表示します。
  (alert 警告メッセージ [ダイアログタイトル])
|;