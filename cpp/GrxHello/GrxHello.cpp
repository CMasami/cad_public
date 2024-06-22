// GrxHello.cpp : DLL の初期化ルーチンを定義します。
//

#include "pch.h"
#include "framework.h"
#include "GrxHello.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

void cmdHello()
{
    acutPrintf(_T("\nHello World."));
}

void cmdHelloDlg()
{
    acedAlert(_T("Hello World."));
}

void initApp()
{
    acedRegCmds->addCommand(_T("ASDK_SAMPLES_HELLOWORLD"), _T("ASDK_HELLOWORLD"), _T("HELLOWORLD"), ACRX_CMD_MODAL, cmdHello);
    acedRegCmds->addCommand(_T("ASDK_SAMPLES_HELLOWORLD"), _T("ASDK_HELLODLG"), _T("HELLODLG"), ACRX_CMD_MODAL, cmdHelloDlg);
}


void unloadApp()
{
    acedRegCmds->removeGroup(_T("ASDK_SAMPLES_HELLOWORLD"));
}


extern "C" AcRx::AppRetCode
acrxEntryPoint(AcRx::AppMsgCode msg, void* appId)
{
    switch (msg) {
    case AcRx::kInitAppMsg:
        acrxDynamicLinker->unlockApplication(appId);
        acrxDynamicLinker->registerAppMDIAware(appId);
        initApp();
        break;
    case AcRx::kUnloadAppMsg:
        unloadApp();
    }
    return AcRx::kRetOK;
}


// CGrxHelloApp

BEGIN_MESSAGE_MAP(CGrxHelloApp, CWinApp)
END_MESSAGE_MAP()

CGrxHelloApp::CGrxHelloApp()
{
}

CGrxHelloApp theApp;

BOOL CGrxHelloApp::InitInstance()
{
	CWinApp::InitInstance();
	return TRUE;
}
