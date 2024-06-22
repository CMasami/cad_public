// GrxHello.h : GrxHello DLL のメイン ヘッダー ファイル
//

#pragma once

#ifndef __AFXWIN_H__
	#error "PCH に対してこのファイルをインクルードする前に 'pch.h' をインクルードしてください"
#endif

#include "resource.h"		// メイン シンボル


// CGrxHelloApp
// このクラスの実装に関しては GrxHello.cpp をご覧ください
//

class CGrxHelloApp : public CWinApp
{
public:
	CGrxHelloApp();

// オーバーライド
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
