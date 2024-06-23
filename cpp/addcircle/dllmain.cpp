// dllmain.cpp : DLL の初期化ルーチンを定義します。
#include "pch.h"

void cmdAddCircle();
void cmdAddCircle2();

// アプリケーションの初期化
void initApp()
{
	acedRegCmds->addCommand(_T("ADDCIRCLE_GROUP"), _T("ADDCIRCLE"), _T("ADDCIRCLE"), ACRX_CMD_SESSION, cmdAddCircle);
	acedRegCmds->addCommand(_T("ADDCIRCLE_GROUP"), _T("ADDCIRCLE2"), _T("ADDCIRCLE2"), ACRX_CMD_SESSION, cmdAddCircle2);
}

// アプリケーションの後処理
void unloadApp()
{
	acedRegCmds->removeGroup(_T("ADDCIRCLE_GROUP"));
}

// ARX/GRXモジュールのエントリーポイント
extern "C" AcRx::AppRetCode acrxEntryPoint
(AcRx::AppMsgCode msg, void* appId)
{
	switch (msg)
	{
	case AcRx::kInitAppMsg:
		acrxDynamicLinker->unlockApplication(appId);
		acrxDynamicLinker->registerAppMDIAware(appId);
		initApp();
		break;
	case AcRx::kUnloadAppMsg:
		unloadApp();
		break;
	default:
		break;
	}
	return AcRx::kRetOK;
}

// ARX MFC 拡張モジュールのリソース管理クラスの定義
AC_IMPLEMENT_EXTENSION_MODULE(arxSampleDLL)

// DLLファイルのエントリーポイント
extern "C" int APIENTRY
DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
	UNREFERENCED_PARAMETER(lpReserved);

	if (dwReason == DLL_PROCESS_ATTACH)
	{
		AfxSetResourceHandle(acedGetAcadResourceInstance());
		arxSampleDLL.AttachInstance(hInstance);
	}
	else if (dwReason == DLL_PROCESS_DETACH)
	{
		arxSampleDLL.DetachInstance();
	}
	return TRUE;
}
