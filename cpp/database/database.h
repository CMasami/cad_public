// database.h : database DLL のメイン ヘッダー ファイル
//

#pragma once

#ifndef __AFXWIN_H__
	#error "PCH に対してこのファイルをインクルードする前に 'pch.h' をインクルードしてください"
#endif

#include "resource.h"		// メイン シンボル


// CdatabaseApp
// このクラスの実装に関しては database.cpp をご覧ください
//

class CdatabaseApp : public CWinApp
{
public:
	CdatabaseApp();

// オーバーライド
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
