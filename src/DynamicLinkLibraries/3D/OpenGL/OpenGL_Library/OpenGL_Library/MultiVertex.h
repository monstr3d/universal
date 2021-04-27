//---------------------------------------------------------------------------

#ifndef MultiVertexH
#define MultiVertexH

////////////////////////////////////////////////////////////////////////
//
// Class: MultiVertex
//
// Description:
//      The EM object that contains collection of vertices
//

#include <vector>
#include "EuclideanTransform.h"

class ID3DFaceArray;
class ID3D;
class IMeshBuilder;

class MultiVertex  : public EuclideanTransform
{
	friend class Vertex;
	public:
		
		MultiVertex(int n,					// Number of facets
			const double * x,				// Data
			double size						// Size
			);								// Constructor

		MultiVertex(int n,					// Number of facets
			int nm,							// Number of materials
			const int * materials,			// Array of materials
			const double * x,				// Data
			double size						// Size
			);								// Constructor

		MultiVertex(int n,					// Number of facets
			int nm,							// Number of materials
			int nEdges,						// Number of edges
			int net,						// Number of edges types
			const int * materials,			// Array of materials
			const int * edgesTypes,			// Array of edges types
			const double * facetsData,		// Data of facets
			const double * edgesData		// Data of edges
			);								// Constructor


		MultiVertex(const char * filename	// The filename
			);								// Contructor

		MultiVertex(ID3DFaceArray * faces	// The face array
			);								// Constructor from 3D graphics object

		MultiVertex(const char * filename,	// The filename
			int nh, int nb, int ne);		// Constructor

		MultiVertex(std::vector<MultiVertex *> & vect	//Vector of figures
			);											//Constructor from vector

		MultiVertex(const MultiVertex & mv,	// Prototype 
			double size						// Maximal size
			);								// Constructor from prototype 

		MultiVertex(const MultiVertex & mv,	// Prototype 
			bool mode						// Mode
			);								// Constructor from prototype 

		virtual ~MultiVertex();				// Destructor
		
		void SaveToFile(const char * filename				// The filename
			);												// Saves this object tu file
		
		void CreateMeshBuilder(ID3D *d3d,					// The d3d
			IMeshBuilder **builder							// The builder
			);												// Creates mesh builder

		void CreatePointerMeshBuilder(ID3D *d3d,			// The d3d
			IMeshBuilder **builder							// The builder
			);												// Creates mesh builder from pointer
		
		void AddSquare();									// Adds root square to currents
		
		void ResetSum();									// Resets sum of squares
		
		void ResetColor();									// Resets colors
		

		bool GetVisibility(int i,			  // The first vertex number 
			int j							  // The second vertex number
			) const;						  // Returns true if i - th and j - th vertexes are visible to each other

		int GetVertexQuantity() const;		  // Returns quantity of vertices

		void Draw();						  // Draws 3D object

		Vertex & operator[](int i			  // The vertex number
			);								  // Gets i th vertex

		void DrawValue(double min,		// Minimal value 
			double max					// Maximal value
			);							// Draws color according value
										
		double GetFacetSize();				 // Gets the size of facet
													
		void GetData(double * x				// The data
			);								// Gets data

		void GetMaterials(int * x			// The materials
			);								// Gets materials


		EuclideanTransform & GetFlatFieldCollectionTransform(); // Gets flat field collection euclidean transform

		void CalculateMaxSize();				// Calculates maximal size
		
		double GetMaxSize();				    // Gets maximal facet size

		double GetSolidAngleIntegral() const;	//Gets solid angle integral

		void ResetExternalVisibility();			// Resets external visibility

		void SetExternalVisibility(int i,		// Facet number 
			bool visible						// Visibility flag
			);									// Sets external visibility
		
		double GetVertexDistance(
			EuclideanTransform & transform,		// Transform  
			int i								// Vertex number
			);									// Distance to i -th vertex to transform

		void SetSize(double size				// The size
			);									// Sets size
		
		void SetColor(int n, double alpha, double red, double green, double blue);

	protected:
		
		MultiVertex(int n);
			
		bool external;						// auxiliary variable
		int nVertex;						// The number of vertixes
		int nEdges;							// The number of edges
		Vertex ** vertices;				// The array of vertixes
		bool** visibility;					// Iterrior visibility matrix
		bool* externalVisibility;			// External visibility array
		int w;								// Width of bitmap
		int h;								// Height of bitmap
		double size;						// Size 
		
		void SetVisibility(int i,			// The first vertex number
			int j,							// The second vertex number 
			bool v							// The visibility flag
			);								// Sets i, j - th visibility to v
											
		void CalculateVisibility();			// Calculates interior visibility
		
		void CalculateVisibility(const VectorD& point // The point
			);										  // Calculates external visibility from the point
		
		double facetSize;             			  // The maximal size of facet
		
		void CalculateFacetSize();						// Calculates size

		int nLayersMaterials;						// Number of layers materials

		int nEdgesTypes;    						// Number of edges types

};

#endif
