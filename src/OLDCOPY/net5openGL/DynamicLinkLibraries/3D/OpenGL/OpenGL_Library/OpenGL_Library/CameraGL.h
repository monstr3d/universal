#pragma once

#include "GLCamera.h"

using namespace System;
using namespace System::Collections;
using namespace System::Diagnostics;


namespace OpenGL_Library {

	ref class ShapeGL;
	ref class ReperGL;
	/// <summary>
	/// Summary for CameraGL
	/// </summary>
	public ref class CameraGL  : IDisposable 
	{
	public:
		CameraGL(int w, int h);

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		virtual ~CameraGL();


		void Draw(void * hdc, ShapeGL ^ shape, array<double> ^ state);
		
		void Draw(void * hdc, ReperGL ^ reper, array<double> ^ state);

		void BeginPaint(void * hdc);
		
		void BeginPaint(void * hdc, bool invertY);

		void EndPaint(void * hdc);

		void PrepareHDC(void * hdc, int mode);

		void SetReferenceAngle(double angle);

		!CameraGL()
		{
			Delete();
		}


	protected:
	  
		virtual void Delete();

	private:

		GLCamera * camera;
		/// <summary>
		/// Required designer variable.
		/// </summary>



	};
}
