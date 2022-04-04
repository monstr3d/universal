// Template Numerical Toolkit (TNT) for Linear Algebra
//
// BETA VERSION INCOMPLETE AND SUBJECT TO CHANGE
// Please see http://math.nist.gov/tnt for updates
//
// R. Pozo
// Mathematical and Computational Sciences Division
// National Institute of Standards and Technology


// Basic TNT  numerical vector (0-based [i] AND 1-based (i) indexing )
//

#ifndef VEC_H
#define VEC_H

#include "subscrpt.h"
#include <cstdlib>
#include <cassert>
#include <iostream>
////////////////////////////////////////////////////////////////////////
//
// Class: Vector; Parametrized Class;
//
// T: this class of vector's element
//
// Description:
//      This class is used for matrix vector operations
//

#define TNT_BOUNDS_CHECK

namespace TNT
{

template <class T>
class Vector
{


  public:

    typedef Subscript   size_type;      // Typedef of subscript
    typedef         T   value_type;     // Typedef of value
    typedef         T   element_type;   // Typedef of element
    typedef         T*  pointer;        // Typedef of pointer
    typedef         T*  iterator;       // Typedef of iterator
    typedef         T&  reference;      // Typedef of reference
    typedef const   T*  const_iterator; // Typedef of const iterator
    typedef const   T&  const_reference;// Typedef of const iterator

    Subscript lbound() const; // Gets the left bound

  protected:
    T* v_;          // Pointer to data
    T* vm1_;        // Pointer adjustment for optimzied 1-offset indexing
    Subscript n_;   // The length of the vector


    void initialize(Subscript N // The length of the vector
    );    // internal helper function to create the array  of row pointers


    void copy(const T*  v  // The pointer to copyed array
    );                     // Copyes the array to vector

    void set(const T& val  // The setted value
    );                     // Sets a single value to elements

    void destroy();  // The destroying of vector


  public:

    // access


    iterator begin(); // The begin pointer
    iterator end();   // The end pointer

    ~Vector();        // The destructor

    Vector(); // The default constructor

    Vector(const Vector<T> &A        // The vector to copy
    );                               // The copy constructor


    Vector(Subscript N,              // The size of the vector
    const T& value = T(0)            // The value
    );                               // The constuctor from value

    Vector(Subscript N,              // The size of the vector
    const T* v                       // The pointer to array
    );                               // The constuctor from array

    Vector(Subscript N,              // The size of the vector
    char *s                          // The string
    );                               // The constuctor from string

    Vector<T>& newsize(Subscript N   // The new size
    );                               // Resizing

    Vector<T>& operator=(const Vector<T> &A   // The vector to assign
    );                                        // Assignment to vector

    Vector<T>& operator=(const T& scalar      // The scalar to assign
    );                                        // Assignment to scalar

    Vector<T>& operator*=(const T& scalar     // The scalar to multiply
    );                                        // Overloaded operation

    Vector<T>& operator/=(const T& scalar   // The scalar to divide
    );                                      // Overloaded operation

    Subscript dim() const;                  // Gets dimension of the vector

    Subscript size() const;                 // Gets dimension of the vector

    reference operator()(Subscript i        // The number of element
    );                                      // The access to 1 - based element

    const_reference operator() (Subscript i // The number of element
    ) const;                                // The access to 1 - based element

    reference operator[](Subscript i        // The number of element
    );                                      // The access to 0 - based element

    const_reference operator[](Subscript i   // The number of element
    ) const;                                 // The access to 0 - based element

    void vecmult(const T& a                  // The scalar to multilpy
    );                                       // Multiplication to scalar

    template <class T1>
    operator Vector<T1>() const
    {
        Vector<T1> v(n_);
        for (int i = 0; i < n_; i++)
        {
                v[i] = T1(v_[i]);
        }
        return v;

    }
    Vector<T>& operator+=(const Vector<T>& x    // The vector to sum
    );                                    // Overloaded operation

	operator const T*()
	{
		return v_;
	}

	const T* GetPointer() const
	{
		return v_;
	}
	
	 

};


template <class T>
inline Subscript Vector<T>::lbound() const
{
        return 1;
}

template <class T>
inline void Vector<T>::initialize(Subscript N)
{
        // adjust pointers so that they are 1-offset:
        // v_[] is the internal contiguous array, it is still 0-offset
        //
        assert(v_ == NULL);
        v_ = new T[N];
        assert(v_  != NULL);
        vm1_ = v_-1;
        n_ = N;
}

template <class T>
inline void Vector<T>::copy(const T*  v)
{
        Subscript N = n_;
        Subscript i;

#ifdef TNT_UNROLL_LOOPS
        Subscript Nmod4 = N & 3;
        Subscript N4 = N - Nmod4;

        for (i=0; i < N4; i+=4)
        {
            v_[i] = v[i];
            v_[i+1] = v[i+1];
            v_[i+2] = v[i+2];
            v_[i+3] = v[i+3];
        }

        for (i = N4; i < N; i++)
        {
            v_[i] = v[i];
        }
#else

        for (i = 0; i < N; i++)
        {
            v_[i] = v[i];
        }
#endif
}

    template <class T>
    inline void Vector<T>::set(const T& val)
    {
        Subscript N = n_;
        Subscript i;

#ifdef TNT_UNROLL_LOOPS
        Subscript Nmod4 = N & 3;
        Subscript N4 = N - Nmod4;

        for (i = 0; i < N4; i += 4)
        {
            v_[i] = val;
            v_[i+1] = val;
            v_[i+2] = val;
            v_[i+3] = val;
        }

        for (i = N4; i < N; i++)
            v_[i] = val;
#else

        for (i = 0; i < N; i++)
            v_[i] = val;

#endif
    }



    template <class T>
    inline void Vector<T>::destroy()
    {
        /* do nothing, if no memory has been previously allocated */
        if (v_ == NULL) return ;

        /* if we are here, then matrix was previously allocated */
        delete [] (v_);

        v_ = NULL;
        vm1_ = NULL;
    }
    // access

    template <class T>
    inline T* Vector<T>::begin()
    {
        return v_;
    }

    template <class T>
    inline T* Vector<T>::end()
    {
        return v_ + n_;
    }

    /* These two operators are commented as the PORTLAND GROUP compiler
    does not recognize a "const" identifier in the return value.
    const iterator begin() const { return v_;}
    const iterator end() const  { return v_ + n_; }
    */

    // destructor

    template <class T>
    inline Vector<T>::~Vector()
    {
        destroy();
    }

    // constructors

    template <class T>
    inline Vector<T>::Vector() : v_(0), vm1_(0), n_(0)  {};

    template <class T>
    inline Vector<T>::Vector(const Vector<T> &A) : v_(0), vm1_(0), n_(0)
    {
        initialize(A.n_);
        copy(A.v_);
    }

    template <class T>
    inline Vector<T>::Vector(Subscript N, const T& value) :  v_(0), vm1_(0), n_(0)
    {
        initialize(N);
        set(value);
    }

    template <class T>
    inline Vector<T>::Vector(Subscript N, const T* v) :  v_(0), vm1_(0), n_(0)
    {
        initialize(N);
        copy(v);
    }

    template <class T>
    inline Vector<T>::Vector(Subscript N, char *s) :  v_(0), vm1_(0), n_(0)
    {
        initialize(N);
        std::istrstream ins(s);

        Subscript i;

        for (i = 0; i < N; i++)
        {
                ins >> v_[i];
        }
    }


    // methods
    //
    template <class T>
    inline Vector<T>& Vector<T>::newsize(Subscript N)
    {
        if (n_ == N) return *this;

        destroy();
        initialize(N);

        return *this;
    }


    // assignments
    //
    template <class T>
    inline Vector<T>& Vector<T>::operator=(const Vector<T> &A)
    {
        if (v_ == A.v_)
            return *this;

        if (n_ == A.n_)         // no need to re-alloc
            copy(A.v_);

        else
        {
            destroy();
            initialize(A.n_);
            copy(A.v_);
        }

        return *this;
    }

    template <class T>
    inline Vector<T>& Vector<T>::operator=(const T& scalar)
    {
        set(scalar);
        return *this;
    }

    template <class T>
    inline Vector<T>& Vector<T>::operator*=(const T& scalar)
    {
        vecmult(scalar);
        return *this;
    }

    template <class T>
    inline Vector<T>& Vector<T>::operator/=(const T& scalar)
    {
        vecmult(T(1) / scalar);
        return *this;
    }


    template <class T>
    inline Subscript Vector<T>::dim() const
    {
        return  n_;
    }

    template <class T>
    inline Subscript Vector<T>::size() const
    {
        return  n_;
    }


    template <class T>
    inline T& Vector<T>::operator()(Subscript i)
    {
#ifdef TNT_BOUNDS_CHECK
        assert(1 <= i);
        assert(i <= n_) ;
#endif
        return vm1_[i];
    }

    template <class T>
    inline const T& Vector<T>::operator() (Subscript i) const
    {
#ifdef TNT_BOUNDS_CHECK
        assert(1 <= i);
        assert(i <= n_) ;
#endif
        return vm1_[i];
    }

    template <class T>
    inline T& Vector<T>::operator[](Subscript i)
    {
#ifdef TNT_BOUNDS_CHECK
        assert(0 <= i);
        assert(i < n_) ;
#endif
        return v_[i];
    }

    template <class T>
    inline const T& Vector<T>::operator[](Subscript i) const
    {
#ifdef TNT_BOUNDS_CHECK
        assert(0 <= i);
        assert(i < n_) ;
#endif
        return v_[i];
    }

    template <class T>
    inline void Vector<T>::vecmult(const T& a)
    {
        for (Subscript i = 0; i < n_; i++)
        {
                v_[i] *= a;
        }
    }

    template <class T>
    inline Vector<T>& Vector<T>::operator+=(const Vector<T>& x)
    {
        for (Subscript i = 0; i < n_; i++)
        {
                v_[i] += x.v_[i];
        }
        return *this;
    }

/* ***************************  I/O  ********************************/

template <class T>
std::ostream& operator<<(std::ostream &s, const Vector<T> &A)
{
    Subscript N=A.dim();

    s <<  N << endl;

    for (Subscript i=0; i<N; i++)
        s   << A[i] << " " << endl;
    s << endl;

    return s;
}

template <class T>
std::istream & operator>>(std::istream &is, Vector<T> &A)
{

    Subscript N;

    is >> N;

    if ( !(N == A.size() ))
    {
        A.newsize(N);
    }


    for (Subscript i=0; i<N; i++)
            is >>  A[i];


    return is;
}

// *******************[ basic matrix algorithms ]***************************


template <class T>
Vector<T> operator+(const Vector<T> &A,
    const Vector<T> &B)
{
    Subscript N = A.dim();

    assert(N == B.dim());

    Vector<T> tmp(N);
    Subscript i;

    for (i=0; i<N; i++)
            tmp[i] = A[i] + B[i];

    return tmp;
}

template <class T>
Vector<T> operator-(const Vector<T> &A, 
    const Vector<T> &B)
{
    Subscript N = A.dim();

    assert(N==B.dim());

    Vector<T> tmp(N);
    Subscript i;

    for (i=0; i<N; i++)
            tmp[i] = A[i] - B[i];

    return tmp;
}

template <class T>
Vector<T> operator-(const Vector<T> &A)
{
    Subscript N = A.dim();

	Vector<T> tmp(N);
    Subscript i;

    for (i=0; i<N; i++)
            tmp[i] = -A[i];

    return tmp;
}

template <class T>
Vector<T> operator*(const Vector<T> &A, 
    const Vector<T> &B)
{
    Subscript N = A.dim();

    assert(N == B.dim());

    Vector<T> tmp(N);
    Subscript i;

    for (i=0; i<N; i++)
            tmp[i] = A[i] * B[i];

    return tmp;
}


template <class T>
T dot_prod(const Vector<T> &A, const Vector<T> &B)
{
    Subscript N = A.dim();
    assert(N == B.dim());

    Subscript i;
    T sum = 0;

    for (i=0; i<N; i++)
        sum += A[i] * B[i];

    return sum;
}

template <class T>
inline Vector<T> operator*(const Vector<T>  &A, const T &a)
{
    Vector<T> m(A);
    m.vecmult(a);
    return m;
}

template <class T>
inline Vector<T> operator*(const T &a, const Vector<T>  &A)
{
    return A * a;
}

template <class T>
inline Vector<T> operator/(const Vector<T>  &A, const T &a)
{
    return A * (T(1) / a);
}

template <class T>
inline T operator|(const Vector<T>  &A, const Vector<T>  &B)
{
        return  dot_prod(A, B);
}


}   /* namespace TNT */

#endif
// VEC_H
