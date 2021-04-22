#pragma once
class MultiVertex;
class CameraGL;
namespace OpenGL_Library 
{
	public ref class ShapeGL : IDisposable
	{

	private:
		MultiVertex * shape;

		virtual void Delete();

	public:
		ShapeGL(void);
		virtual ~ShapeGL(void);

		void Set(int n, array<double> ^ x);

		MultiVertex * GetShape();

		void SetColor(int n, double alpha, double red, double green, double blue);
	
	private:

		!ShapeGL()
		{
			Delete();
		}
	};
};
