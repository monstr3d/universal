// 
// Errors.c 
// 
// Contains error messages for DIBAPI.DLL 
// 
// These error messages all have constants associated with 
// them, contained in dibapi.h. 
// 
// Copyright 1991-1998 Microsoft Corporation. All rights reserved. 
// 
 
#define     STRICT      // enable strict type checking 
#include "stdafx.h" 
#include <windows.h> 
#include "dibapi.h" 

 
extern WORD nLangID = 0; 
static char *szErrors[] = 
{ 
    "Not a Windows DIB file!", 
    "Couldn't allocate memory!", 
    "Error reading file!", 
    "Error locking memory!", 
    "Error opening file!", 
    "Error creating palette!", 
    "Error getting a DC!", 
    "Error creating Device Dependent Bitmap", 
    "StretchBlt() failed!", 
    "StretchDIBits() failed!", 
    "SetDIBitsToDevice() failed!", 
    "Printer: StartDoc failed!", 
    "Printing: GetModuleHandle() couldn't find GDI!", 
    "Printer: SetAbortProc failed!", 
    "Printer: StartPage failed!", 
    "Printer: NEWFRAME failed!", 
    "Printer: EndPage failed!", 
    "Printer: EndDoc failed!", 
    "SetDIBits() failed!", 
    "File Not Found!", 
    "Invalid Handle", 
    "General Error on call to DIB function" 
}; 
 
static char *szErrorsJ[] = 
{ 
    "Windows DIB  t @ C                 B", 
    "         m                             B", 
    " t @ C             G   [", 
    "           b N  G   [", 
    " t @ C     I [ v    G   [", 
    " p   b g       G   [", 
    " f o C X  R   e L X g       G   [", 
    " f o C X     r b g } b v       G   [", 
    "StretchBlt()      s         B", 
    "StretchDIBits()      s         B", 
    "SetDIBitsToDevice()      s         B", 
    " v     ^: StartDoc      s         B", 
    "    : GetModuleHandle() GDI                        B", 
    " v     ^: SetAbortProc      s         B", 
    " v     ^: StartPage      s         B", 
    " v     ^: NEWFRAME      s         B", 
    " v     ^: EndPage      s         B", 
    " v     ^: EndDoc      s         B", 
    "SetDIBits()      s         B", 
    " t @ C                         B", 
    "       n   h  ", 
    "DIB  t @   N V         o           G   [" 
}; 
 
void DIBError(int ErrNo) 
{ 
 /*   if (nLangID == LANG_JAPANESE) { 
        if ((ErrNo < ERR_MIN) || (ErrNo >= ERR_MAX)) 
            MessageBox(NULL, "   m   G   [ B", NULL, MB_OK | MB_ICONHAND); 
        else 
            MessageBox(NULL, szErrorsJ[ErrNo], NULL, MB_OK | MB_ICONHAND); 
    } 
    else { 
        if ((ErrNo < ERR_MIN) || (ErrNo >= ERR_MAX)) 
            MessageBox(NULL, "Undefined Error!", NULL, MB_OK | MB_ICONHAND); 
        else*/ 
          //  MessageBox(NULL, szErrors[ErrNo], NULL, MB_OK | MB_ICONHAND); 
 //   } 
} 
