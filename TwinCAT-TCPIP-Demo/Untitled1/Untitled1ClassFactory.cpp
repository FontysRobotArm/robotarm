///////////////////////////////////////////////////////////////////////////////
// Untitled1ClassFactory.cpp
#include "TcPch.h"
#pragma hdrstop

#include "Untitled1ClassFactory.h"
#include "Untitled1Services.h"
#include "Untitled1Version.h"

BEGIN_CLASS_MAP(CUntitled1ClassFactory)
///<AutoGeneratedContent id="ClassMap">
///</AutoGeneratedContent>
END_CLASS_MAP()

CUntitled1ClassFactory::CUntitled1ClassFactory() : CObjClassFactory()
{
	TcDbgUnitSetImageName(TCDBG_UNIT_IMAGE_NAME_TMX(SRVNAME_UNTITLED1));
#if defined(TCDBG_UNIT_VERSION)
	TcDbgUnitSetVersion(TCDBG_UNIT_VERSION(Untitled1));
#endif //defined(TCDBG_UNIT_VERSION)
}

