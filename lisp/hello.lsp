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
  LISP�̊֐����`����ɂ́Adefun �֐����g���܂��B
 (defun �֐��� �������X�g  �֐��{�� )

  LISP�̊֐����R�}���h�Ƃ��Ē�`����ɂ́A�֐����� C:�R�}���h�� �Ƃ��܂��B
  ��L�̗�ł͂Q�̃R�}���h HELLO �� HELLOMSG ����`����܂��B

  princ �֐��͈������R�}���h�E�B���h�E�ɕ\�����܂��B
  (princ �l)
  �߂�l�͒l���̂��̂ł��B
  (princ)
  ���������� princ �֐��͖߂�l�̕\����}������̂Ɏg���܂��B

  alert �֐��͌x���_�C�A���O��\�����܂��B
  (alert �x�����b�Z�[�W [�_�C�A���O�^�C�g��])
|;