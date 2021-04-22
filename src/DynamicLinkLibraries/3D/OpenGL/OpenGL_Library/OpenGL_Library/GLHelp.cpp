#include "StdAfx.h"
#include "GLHelp.h"

BOOL bSetupPixelFormat(HDC hdc, int mode)
{
    PIXELFORMATDESCRIPTOR pfd, *ppfd;
    int pixelformat;

    ppfd = &pfd;

    ppfd->nSize = sizeof(PIXELFORMATDESCRIPTOR);
    ppfd->nVersion = 1;
	if (mode)
	{
		ppfd->dwFlags = PFD_DRAW_TO_BITMAP | PFD_SUPPORT_OPENGL | PFD_SUPPORT_GDI;

		PIXELFORMATDESCRIPTOR & pixelDesc = *ppfd; 
		pixelDesc.iPixelType = PFD_TYPE_RGBA;
		pixelDesc.cColorBits = 32;
		pixelDesc.cRedBits = 0;
		pixelDesc.cRedShift = 0;
		pixelDesc.cGreenBits = 0;
		pixelDesc.cGreenShift = 0;
		pixelDesc.cBlueBits = 0;
		pixelDesc.cBlueShift = 0;
		pixelDesc.cAlphaBits = 0;
		pixelDesc.cAlphaShift = 0;
		pixelDesc.cAccumBits = 0;
		pixelDesc.cAccumRedBits = 0;
		pixelDesc.cAccumGreenBits = 0;
		pixelDesc.cAccumBlueBits = 0;
		pixelDesc.cAccumAlphaBits = 0;
		pixelDesc.cDepthBits = 32;
		pixelDesc.cStencilBits = 0;
		pixelDesc.cAuxBuffers = 0;
		pixelDesc.iLayerType = PFD_MAIN_PLANE;
		pixelDesc.bReserved = 0;
		pixelDesc.dwLayerMask = 0;
		pixelDesc.dwVisibleMask = 0;
		pixelDesc.dwDamageMask = 0;
		if (mode == 2)
		{
			ppfd->dwFlags = PFD_DRAW_TO_BITMAP | PFD_SUPPORT_OPENGL | PFD_NEED_PALETTE;
//			LOGPALETTE * pPal;
			ppfd->iPixelType = PFD_TYPE_COLORINDEX;
			LPLOGPALETTE lpLogPal;
			int     nPalEntries = 129;   // Number of entries in our
                                         // palette.
                                         // 256 are possible, but the
                                         // system reserves 20 of them.

			lpLogPal = (LPLOGPALETTE) new char[
                   sizeof (LOGPALETTE) + nPalEntries * sizeof
                   (PALETTEENTRY)];

			lpLogPal->palVersion    = 0x300;
			lpLogPal->palNumEntries = nPalEntries;

			for (int i = 0; i < nPalEntries; i++)
			{

				// Fill in the red, green, and blue values for our palette.
				// This particular palette is a wash from green to black.
				lpLogPal->palPalEntry[i].peRed   = (i & 0x7) * 30;
				lpLogPal->palPalEntry[i].peGreen = ((i >> 3) & 0x7) * 30;
				lpLogPal->palPalEntry[i].peBlue  = ((i >> 6) & 0x1) * 60;

				// Create unique palette entries. This flag may change depending
				// on your purposes. See the Windows API documentation
				// about the PALETTEENTRY structure for more information.
				lpLogPal->palPalEntry[i].peFlags = PC_NOCOLLAPSE;
			}

       // Create the logical palette.
			HPALETTE g_hPal = CreatePalette (lpLogPal);
			SelectPalette(hdc, g_hPal, false);

		
		}

	}
	else
	{
		ppfd->dwFlags = PFD_DRAW_TO_WINDOW | PFD_SUPPORT_OPENGL |
                        PFD_DOUBLEBUFFER;
		ppfd->dwLayerMask = PFD_MAIN_PLANE;
		ppfd->iPixelType = PFD_TYPE_COLORINDEX;
		ppfd->cColorBits = 8;
		ppfd->cAlphaBits = 64;
		ppfd->cAccumBits = 0;
		
		ppfd->cDepthBits = 16;

		ppfd->cStencilBits = 0;
	}


    if ( (pixelformat = ChoosePixelFormat(hdc, ppfd)) == 0 )
    {
        //MessageBox(NULL, L"ChoosePixelFormat failed", L"Error", MB_OK);
		return FALSE;
	}

    if (!SetPixelFormat(hdc, pixelformat, ppfd))
    {
		if (mode == 1)
		{
		//pfd.nSize = sizeof(PIXELFORMATDESCRIPTOR);
		//	ppfd->nVersion = 1;
		//	ppfd->dwFlags = PFD_SUPPORT_OPENGL | PFD_DOUBLEBUFFER | PFD_DRAW_TO_WINDOW;
			//ppfd->iPixelType = PFD_TYPE_RGBA;
		/*	ppfd->cColorBits = 32;
			ppfd->cAlphaBits = 0;
			ppfd->cAccumBits = 0;
		
			ppfd->cDepthBits = 0;

			ppfd->cStencilBits = 0;*/

			if ( (pixelformat = ChoosePixelFormat(hdc, ppfd)) == 0 )
			{
        //MessageBox(NULL, L"ChoosePixelFormat failed", L"Error", MB_OK);
				return FALSE;
			}

			if (!SetPixelFormat(hdc, pixelformat, ppfd))
			{
				return FALSE;
			}
		}
	}

    return TRUE;

}

/*BOOL bSetupPixelFormat(HDC hdc, int mode)
{
    PIXELFORMATDESCRIPTOR pfd, *ppfd;
    int pixelformat;

    ppfd = &pfd;

    ppfd->nSize = sizeof(PIXELFORMATDESCRIPTOR);
    ppfd->nVersion = 1;
	if (mode != 1)
	{
		ppfd->dwFlags = PFD_DRAW_TO_WINDOW | PFD_SUPPORT_OPENGL |
                        PFD_DOUBLEBUFFER;
		ppfd->dwLayerMask = PFD_MAIN_PLANE;
		ppfd->iPixelType = PFD_TYPE_COLORINDEX;
		ppfd->cColorBits = 64;
		ppfd->cAlphaBits = 64;
		ppfd->cAccumBits = 64;
		
		ppfd->cDepthBits = 64;

		ppfd->cStencilBits = 64;
	}
	else
	{
		ppfd->dwFlags = PFD_DRAW_TO_BITMAP | PFD_SUPPORT_OPENGL;// | PFD_NEED_PALETTE;
		ppfd->dwLayerMask = PFD_MAIN_PLANE;
		ppfd->iPixelType = PFD_TYPE_COLORINDEX;
		ppfd->cColorBits = 64;
		ppfd->cAlphaBits = 64;
		ppfd->cAccumBits = 64;
		
		ppfd->cDepthBits = 64;

		ppfd->cStencilBits = 64;
	}


		if ( (pixelformat = ChoosePixelFormat(hdc, ppfd)) == 0 )
		{
        //MessageBox(NULL, "ChoosePixelFormat failed", "Error", MB_OK);
			return FALSE;
		}

		if (SetPixelFormat(hdc, pixelformat, ppfd) == FALSE)
		{
       // MessageBox(NULL, "SetPixelFormat failed", "Error", MB_OK);
			return FALSE;
		}

    return TRUE;

}*/

