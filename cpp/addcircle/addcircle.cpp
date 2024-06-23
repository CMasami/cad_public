// addcircle.cpp : DLL の初期化ルーチンを定義します。
//

#include "pch.h"

void cmdAddCircle()
{
	ads_point ptres;
	int rc = ads_getpoint(NULL, L"\n中心を指定: ", ptres);
	if (rc != RTNORM)
		return;
	resbuf rb;
	ads_getvar(L"CIRCLERAD", &rb);
	double radius = rb.resval.rreal;
	ads_initget(RSG_NONEG | RSG_NOZERO, NULL);
	AcString prompt;
	prompt.format(L"\n半径を指示<%f>: ", radius);
	rc = ads_getdist(ptres, prompt, &radius);
	if (rc == RTNONE)
	{
		radius = rb.resval.rreal;
		rc = RTNORM;
	}
	if (rc != RTNORM)
		return;
	AcTransactionManager* tr = acTransactionManagerPtr();
	try
	{
		Acad::ErrorStatus es;
		tr->startTransaction();
		AcDbDatabase* db = curDoc()->database();
		AcDbBlockTableRecord* space;
		es = tr->getObject((AcDbObject*&)space, db->currentSpaceId(), AcDb::kForWrite);
		if (es)	throw es;
		AcDbCircle* circle = new AcDbCircle();
		circle->setDatabaseDefaults(db);
		circle->setCenter(asPnt3d(ptres));
		circle->setRadius(radius);
		es = space->appendAcDbEntity(circle);
		if (es)	throw es;
		es = tr->addNewlyCreatedDBRObject(circle, true);
		if (es)	throw es;
		tr->endTransaction();
		rb.resval.rreal = radius;
		ads_setvar(L"CIRCLERAD", &rb);
	}
	catch (Acad::ErrorStatus es)
	{
		ads_printf(acadErrorStatusText(es));
		tr->abortTransaction();
	}
}

void cmdAddCircle2()
{
	ads_point ptres;
	int rc = ads_getpoint(NULL, L"\n中心を指定: ", ptres);
	if (rc != RTNORM)
		return;
	resbuf rb;
	ads_getvar(L"CIRCLERAD", &rb);
	double radius = rb.resval.rreal;
	ads_initget(RSG_NONEG | RSG_NOZERO, NULL);
	AcString prompt;
	prompt.format(L"\n半径を指示<%f>: ", radius);
	rc = ads_getdist(ptres, prompt, &radius);
	if (rc == RTNONE)
	{
		radius = rb.resval.rreal;
		rc = RTNORM;
	}
	if (rc != RTNORM)
		return;
	resbuf* elist = ads_buildlist(
		RTDXF0, L"CIRCLE",
		10, ptres,
		40, radius,
		RTNONE
	);
	rc = ads_entmake(elist);
	ads_relrb(elist);
	if (rc == RTNORM)
	{
		rb.resval.rreal = radius;
		ads_setvar(L"CIRCLERAD", &rb);
	}
}

void cmdAddCircle3()
{
	ads_point pt = { 0.0, 0.0, 0.0 };
	double radius = 10.0;
	acedCommandS(RTSTR, L"CIRCLE", RT3DPOINT, pt, RTREAL, radius, RTNONE);
	// 任意の場所に作図
	acedCommandS(RTSTR, L"CIRCLE", RTSTR, PAUSE, RTSTR, PAUSE, RTNONE);
}