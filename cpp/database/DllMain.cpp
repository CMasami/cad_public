// DllMain.cpp : DLL の初期化ルーチンを定義します。

#include "pch.h"

void initApp()
{
    acedRegCmds->addCommand(_T("ASDK_SAMPLES_HELLOWORLD"), _T("ASDK_HELLOWORLD"), _T("HELLOWORLD"), ACRX_CMD_MODAL, cmdHello);
    acedRegCmds->addCommand(_T("ASDK_SAMPLES_HELLOWORLD"), _T("ASDK_HELLODLG"), _T("HELLODLG"), ACRX_CMD_MODAL, cmdHelloDlg);
}


void unloadApp()
{
    acedRegCmds->removeGroup(_T("ASDK_SAMPLES_HELLOWORLD"));
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
