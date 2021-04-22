#pragma once
#include "Reper.h"
namespace OpenGL_Library 
{
	public ref class ReperGL : IDisposable
	{
	public:
	ReperGL(void);
	~ReperGL(void);
	void SetLength(double length);



	Reper * GetReper();

	!ReperGL()
	{
		Delete();
	}

	protected:
		
		virtual void Delete();

	private:
		Reper * reper;
	};
};
