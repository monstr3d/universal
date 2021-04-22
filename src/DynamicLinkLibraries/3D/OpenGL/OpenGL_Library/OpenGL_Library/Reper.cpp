#include "stdafx.h"
#include "windows.h"
#include "Reper.h"

#define M_PI       3.14159265358979323846


Reper::Reper(void)
{
	length = 1;
}

Reper::~Reper(void)
{
}

void Reper::SetLength(double length)
{
	this->length = length;
}
	
void Reper::Draw()
{
	glBegin(GL_LINES);

	glEnable(GL_CULL_FACE);
	
	glColor3d(1.0, 0.0, 0.0);
	glVertex3d(length, 0.0, 0.0);
	glVertex3d(0.0, 0.0, 0.0);
	
	glColor3d(1.0, 1.0, 0.0);
	glVertex3d(0.0, length, 0.0);
	glVertex3d(0.0, 0.0, 0.0);

	glColor3d(0.0, 1.0, 0.0);
	glVertex3d(0.0, 0.0, length);
	glVertex3d(0.0, 0.0, 0.0);

	glEnd();

	for (int i = 0; i < 36; i++)
	{
		glBegin(GL_TRIANGLES);

		glColor3d(1.0, 0.0, 0.0);
		glVertex3d(length, 0.0, 0.0);
		glVertex3d(0.9 * length, 0.025 * sin(i * M_PI / 18) * length, 0.025 * cos(i * M_PI / 18) * length);
		glVertex3d(0.9 * length, 0.025 * sin((i + 1) * M_PI / 18) * length, 0.025 * cos((i + 1) * M_PI / 18) * length);

		glColor3d(1.0, 1.0, 0.0);
		glVertex3d(0.0, length, 0.0);
		glVertex3d(0.025 * sin(i * M_PI / 18) * length, 0.9 * length, 0.025 * cos(i * M_PI / 18) * length);
		glVertex3d(0.025 * sin((i + 1) * M_PI / 18) * length, 0.9 * length, 0.025 * cos((i + 1) * M_PI / 18) * length);

		glColor3d(0.0, 0.0, 1.0);
		glVertex3d(0.0, 0.0, length);
		glVertex3d(0.025 * sin(i * M_PI / 18) * length, 0.025 * cos(i * M_PI / 18) * length, 0.9 * length);
		glVertex3d(0.025 * sin((i + 1) * M_PI / 18) * length, 0.025 * cos((i + 1) * M_PI / 18) * length, 0.9 * length);
		
		glEnd();

	}
}

