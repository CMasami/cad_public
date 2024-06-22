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
  �}�`���쐬������@�A�R�ʂ�B
  command �֐��Ł@CIRCLE �R�}���h���Ăяo���B

  '( 0.0 0.0 0.0) �� �f �̓N�H�[�g�ƌĂсA���̃��X�g���f�[�^�Ƃ��ď������邱�Ƃ��Ӗ�����
  �����f�[�^���A���͍ŏ��̈����͊֐����ŁA�c��͈����ɂȂ�B
  �f�[�^�̓��X�g���̂��̂��f�[�^�ł���B

  entmake �֐��ŉ~��`�����@�Q�B
  �ŏ��̂́A�N�H�[�g���g���Ă��Ȃ��Blist �֐��� cons �֐��Ń��X�g������Ă���
  �Q�s�߂́A�N�H�[�g���g������B
  �}�`���܂ރf�[�^�x�[�X�I�u�W�F�N�g���쐬����ɂ͍ŏ����K�v�Ȓl��^����΂悢�B
  ���̏ꍇ�A��w(8)�A����(6)�A���F(62)�A����(370)�Ȃǂ͐}�ʂ̌��݂̒l�𗘗p����B

  �I�[�g���[�V�����ŉ~��`�����@
  vla-get-acad-object �֐��B���ׂẴI�[�g���[�V�����̊�_�ł���A�A�v���P�[�V�����I�u�W�F�N�g���擾�B
  vla-get-ActiveDocument �֐��Bvla-get-�v���p�e�B���́A�I�u�W�F�N�g�̃v���p�e�B���擾����B�A�N�e�B�u�ȃh�L�������g �I�u�W�F�N�g���擾�����B
  vla-get-ModelSpace �֐��B�A�N�e�B�u�ȃh�L�������g�̃��f����ԃu���b�N���擾�����B
  vla-AddCircle �֐� vla-���\�b�h���́A�I�u�W�F�N�g�̃��\�b�h���Ăяo���B
  ���W��LISP�ł͂R�̗v�f�̃��X�g�����A�I�[�g���[�V�����ł̓Z�[�t�z��ŕێ�����Bvlax-3d-point �͍��W�������Z�[�t�z����쐬����B
  �ȏ�ŁA�}�`�̍����ɂ́Acommand�֐����Ăԕ��@�Aentmake�֐����Ăԕ��@�AAdd-�}�`�� �֐����Ăԕ��@�����邱�Ƃ��킩��B
|;