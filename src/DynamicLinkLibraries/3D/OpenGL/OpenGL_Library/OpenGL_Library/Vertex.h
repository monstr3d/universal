//---------------------------------------------------------------------------

#ifndef VertexH
#define VertexH


////////////////////////////////////////////////////////////////////////
//
// Class: Vertex;
//
// Description:
//      GL vertex
//

#include "MultiVertex.h"
#include "ID3DFace.h"

class Vertex
{
    friend class MultiVertex;

	public:

		Vertex(double* x				 // The array of points' coordinates
			);							 // Constructor


        Vertex(double s,				 // The area
			const VectorD & position,	 // The position
			const VectorD & norm		 // The normale vector
			);							 // Constructor
        

		Vertex(ID3DFace * Face		 // The face
			);							 // Constructor from face

		Vertex(const Vertex & v		// Vertex to copy
			);							// Copy constructor


		Vertex(const VectorD & x1,	// First vertex
			const VectorD & x2,			// Second vertex
			const VectorD & x3			// Third vertex
			);							// Constructor by three vetrtices


		virtual ~Vertex();			 // Destructor

		void Set(double * x				 // The array of coordinates
			);							 // Sets new values vetrices coordinates from array

		
		void LoadFromStream(std::istream& is  // The input stream
			);			      // Loads this obect from stream


        const VectorD& GetVertex(int i	// The number of point
			) const;					// Returns the i - th vertex

        void SetVisibilityPoint(const VectorD & point // The point for visibility calculation 
			);										  // Sets the point for visibility calculation

        bool isVisible(const VectorD & point	// The point for visibility calculation
			
			);									// Returns visibility from the point

		void Init();							//Initialization

		const VectorD & GetPosition();			// Gets position

		void SetValue(double Value				// The value
			);									// Sets a value

		void SetParent(MultiVertex * Parent		// The parent
			);									// Sets parent
		void SetColorV(const VectorD & v				// The color vector
			);											// Sets color
	
		void ResetColor();				 //	Resets initial color to associated face

		void Reset();					 // Resets surface current

		virtual void SetTransitionMatrix(const MatrixD & m	// Transition matrix
			);									// Sets transition matrix

		double GetSolidAngleIntegral() const;	// Gets solid angle integral

		int GetMaterialNumber();				// Gets material number

		void SetColor(double alpha, double red, double green, double blue);

	protected:
        
       VectorD Position;                // The relative position
        VectorC norm;                    // The normale vector
        VectorD normD;					 // The real normale vector
        bool enabled;                    // Auxiliary field
        double S;                        // The area of vertex
		ID3DFace * face;				 // The 3D graphics face associated with this object
        int index;						 // The index of the vertex
        VectorD vertices[3];			 // Array of vertices
        MultiVertex * parent;			 // Parent object
        VectorD ownColor;				 // Own color of the vertex
		double sum;						 // Auxiliary variable
		VectorD relative[3];			 // relative vectors;
		double distanceIn[3];			 // Input distances
		double distanceOut[3];			 // Output distances
		double sourceDistance;			 // Distance to source


		Vertex();						 // Constructor


		void ZeroExt();					 // Resets current induced by external field
        
		void ZeroInt();					 // Resets current induced by internal field

        void Prepare();					 // Preparation
		
		void SetFace(ID3DFace * Face	 // The face
			);							 // Conscructs the vertex for 3D graphics face
		
		
		void Draw(double a				 // The intensity parameter
			);							 // Draws the intensity of the EM current on 3D face

		void DrawValue(double min,		// Minimal value 
			double max					// Maximal value
			);							// Draws color according value
		

		VectorD proj;					// Projection of wave vector

		int materialNumber;			// Number of material;

		int calculatorNubmer;			// Number of calculator;

		double area;					 // The area of the object

		const VectorD& Vertex::GetNorm() const; // The normale vector


	private:
		
		
		void AddSquare();				 // Adds square of current to calculate EM color
		
		void ResetSum();				 // Resets sum color

        VectorD SourcePoint;             // The point of radiation source

        MatrixD VisibleMat;              // The auxiliary matrix for
		                                 // visibility calculation

        double VisibleProjection;        // Projection to normale
		
		double value;					// The color value

		double size;					// The size

		std::vector<Vertex *> barycentric();	//Barycentric division

		void CreateCollection(double Size, std::vector<Vertex *> & collection, std::vector<Vertex *> & del);

		static bool Colored;					// The "Colored" sign

};

std::istream& operator>>(std::istream& is, Vertex & v);


#endif
