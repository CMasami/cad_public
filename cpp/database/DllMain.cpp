// DllMain.cpp : DLL の初期化ルーチンを定義します。

#include "pch.h"

void cmdAddTableRecords();
void cmdAddEntities();
void cmdAddDatabaseObjects();

void initApp()
{
    acedRegCmds->addCommand(TESTDB_GROUP_NAME, _T("ADDRECORDS"), _T("ADDRECORDS"), ACRX_CMD_MODAL, cmdAddTableRecords);
    acedRegCmds->addCommand(TESTDB_GROUP_NAME, _T("ADDENTS"), _T("ADDENTS"), ACRX_CMD_MODAL, cmdAddEntities);
	acedRegCmds->addCommand(TESTDB_GROUP_NAME, _T("ADDOBJS"), _T("ADDOBJS"), ACRX_CMD_MODAL, cmdAddDatabaseObjects);
}


void unloadApp()
{
    acedRegCmds->removeGroup(TESTDB_GROUP_NAME);
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
