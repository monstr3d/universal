//---------------------------------------------------------------------------

#ifndef EuclideanTransformH
#define EuclideanTransformH
#include <complex>
#include "cmat.h"
#include "VectorProvider.h"

typedef std::complex<double>  ComplexD;
typedef TNT::Vector<double> VectorD;
typedef TNT::Vector<ComplexD> VectorC;
typedef TNT::Matrix<double> MatrixD;

////////////////////////////////////////////////////////////////////////
//
// Class: EuclideanTransform
//
// Description:
//      Objects of this class contains information about Euclidean transformation
//


class EuclideanTransform : public VectorProvider
{
protected:
        VectorD x;                      // The shift vector
        MatrixD A;                      // The 3D rotation matrix
        MatrixD AT;                     // The matrix of inverse rotation
		VectorD V;						// The velocity vector
		VectorD Om;						// The angular velocity vector
public:
        EuclideanTransform();           // Constructor

		virtual ~EuclideanTransform();

        virtual void SetState(const MatrixD & a,     // The 3D rotation matrix
        const VectorD & x               // The shift vector
        );                              // Sets new value of the object

        virtual void SetStateVector(const MatrixD & a,     // The 3D rotation matrix
        const VectorD & x,               // The shift vector
		const VectorD & v,				 // The velocity
		const VectorD & om				// The angular velocity
        );                              // Sets new value of the object

		virtual void SetMatrix(const MatrixD & a
			);                              // Sets new value of the object
        
		virtual void SetVector(
			const VectorD & x               // The shift vector
        );                              // Sets new value of the object

		const VectorD RepresentX (
			const EuclideanTransform & e1,		//Source EuclideanTransform 
			const EuclideanTransform & e2		//Representation system
			) const;							//Representation of shift vector of system in terms of another one 

		const VectorD RepresentV (
			const EuclideanTransform & e1,		//Source EuclideanTransform 
			const EuclideanTransform & e2		//Representation system
			) const;							//Representation of shift vector of system in terms of another one 

		const VectorD RepresentOm (
			const EuclideanTransform & e1,		//Source EuclideanTransform 
			const EuclideanTransform & e2		//Representation system
			) const;							//Representation of shift vector of system in terms of another one


		const VectorD LinAcceleration (
			const VectorD & f1,					//Force in stationar system
			const VectorD & f2					//Force in associated system				
			)const;								//Returns the resultation force in 
												//terms ofstationar coordinate system

		const VectorD AngAcceleration (
			const VectorD & m1,					//Momentum in stationar system
			const VectorD & m2					//Momentum in associated system
			)const;								//Returns the resultation of rotation momentum in 
												//terms of coordinate system, associated with mass center

        const VectorD  Transform(const VectorD & x   // The vector to transform
        ) const;                                     // Spatial vector trasformation

        const VectorD  InverseTransform(const VectorD & x   // The vector to transform
        ) const;                                     // Spatial vector inverse trasformation

        const VectorC Rotate(const VectorC & x		 // The vector to rotate
        ) const;                                     // The rotation of complex vector

		const VectorD Rotate(const VectorD & x		 // The vector to rotate
		) const;									 // The rotation of complex vector

        const VectorC InverseRotate(const VectorC & x   // The vector to rotate
        ) const;										// The inverse rotation of complex vector

		const VectorD InverseRotate(const VectorD & x   // The vector to rotate
        ) const;										// The inverse rotation of real vector
		
		MatrixD GetOrientation(const EuclideanTransform& e // The relative transform
			);											   // Gets orientation relative to e

		VectorD GetPosition(const EuclideanTransform& e // The relative transform
			);											// Gets position relative to e

		VectorD GetVelocity(const EuclideanTransform& e // The relative transform
			);											// Gets velocity relative to e
		
		VectorD GetAngularVelocity(const EuclideanTransform& e // The relative transform
			);											// Gets angular relative to e

		virtual int GetVectorCount() const; //Returns the number of vectors providing
				
		virtual TNT::Vector<double> GetVector(int i) const; //Returns the i'th providing vector 
		
		const MatrixD & GetOrientation();	// Gets the orientation
		
		const VectorD & GetPosition();		// Gets the position

		const VectorD & GetVelocity();	// Gets the velocity
		
		const VectorD & GetAngularVelocity();		// Gets the angular velocity


		void SetOrientation(const EuclideanTransform& e, // The relative transform
			const MatrixD & m							 // The orientaton matrix
			);											 // Sets orientation relative to e
		
		
		void SetPosition(const EuclideanTransform& e,	 // The relative transform
			const VectorD & v							 // The position vector
			);											 // Sets position relative to e

		virtual void SetRelative(const EuclideanTransform & relative, // Relative transform 
			const EuclideanTransform & base							  // Base transform
			);														  // Sets relative frame
		
		void SetAbsolute(const EuclideanTransform & relative,		  // Relative transform
			const EuclideanTransform & base							  // Base transform
			);														  // Sets absolute frame
		
		void SetRelativeState(const MatrixD & matrix,				// Matrix of absolute state
			const VectorD & vector,									// Vector of absolute state
			const EuclideanTransform & base							// The base reference frame
			);														// Sets relative transform by absolute parameters 

		void SetRelativeState(const MatrixD & matrix,				// Matrix of absolute state
			const VectorD & r,										// Vector of absolute state
			const VectorD & v,										// Velocity
			const VectorD & om,										// Angular velocity
			const EuclideanTransform & base							// The base reference frame
			);														// Sets relative transform by absolute parameters 
																	
		VectorD GetOwnAngularVelocity(void);
};

double norm(const VectorC & x
);                                                       // The norm calculation

double norm(const VectorD & x
			);											// The norm calculation

VectorC operator^(const VectorC & x, const VectorC & y); // The vector product
VectorC operator^(const VectorD & x, const VectorC & y); // The vector product
VectorC operator^(const VectorC & x, const VectorD & y); // The vector product
VectorC operator^(const VectorD & x, const VectorD & y); // The vector product
VectorD operator%(const VectorD & x, const VectorD & y); // The vector product
ComplexD operator%(const VectorC & x, const VectorC & y); //The scalar product
ComplexD operator|(const VectorD & x, const VectorC & y); //The scalar product

double Angle(const VectorD & x, const VectorD & y);



//---------------------------------------------------------------------------
#endif
