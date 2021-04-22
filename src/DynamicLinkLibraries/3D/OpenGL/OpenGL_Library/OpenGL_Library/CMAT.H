// Template Numerical Toolkit (TNT) for Linear Algebra
//
// BETA VERSION INCOMPLETE AND SUBJECT TO CHANGE
// Please see http://math.nist.gov/tnt for updates
//
// R. Pozo
// Mathematical and Computational Sciences Division
// National Institute of Standards and Technology


// C compatible matrix: row-oriented, 0-based [i][j] and 1-based (i,j) indexing
//

#ifndef CMAT_H
#define CMAT_H

#include "subscrpt.h"
#include "vec.h"
#include <cstdlib>
#include <cassert>
#include <iostream>
#ifdef TNT_USE_REGIONS
#include "region2d.h"
#endif

////////////////////////////////////////////////////////////////////////
//
// Class: Matrix; Parametrized Class;
//
// T: this class of matrix's element
//
// Description:
//      This class is used for matrix vector operations
//

namespace TNT
{


template <class T>
class Matrix 
{


  public:

    typedef Subscript   size_type;      // Typedef of subscript
    typedef         T   value_type;     // Typedef of value
    typedef         T   element_type;   // Typedef of element
    typedef         T*  pointer;        // Typedef of pointer
    typedef         T*  iterator;       // Typedef of iterator
    typedef         T&  reference;      // Typedef of reference
    typedef const   T*  const_iterator;  // Typedef of const iterator
    typedef const   T&  const_reference; // Typedef of const reference


    Subscript lbound() const;    // Rerurns the left bound

  protected:
    Subscript m_;                // Number of rows
    Subscript n_;                // Number of columns
    Subscript mn_;               // Total size
    T* v_;                       // The pointer to data
    T** row_;                    // The pointer to row
    T* vm1_ ;                    // These point to the same data, but are 1-based
    T** rowm1_;                  // The 1 - based pointer to row


    void initialize(Subscript M, // The number of rows
                Subscript N      // The number of columns
                );     // internal helper function to create the array
                                                   // of row pointers

    void copy(const T*  v    // Pointer to the array
    );                       // Copies the array to vector

    void set(const T& val     // The value to set
    );                        // Sets the same value to all elements

    void destroy();            // Destroys the matrix


  public:

    operator T**();        // Access to pointer
    operator T**() const;  // Access to pointer


    Subscript size() const;     // Gets nnumber of elements

    // constructors

    Matrix();        // Default constructor

    Matrix(const Matrix<T> &A   // The matrix to copy
    );   // The copy constructor

    Matrix(Subscript M,         // The number of rows
    Subscript N,                // The number of columns
    const T& value = T(0)       // The value of elemets
    );                          // The constructor  form value

    Matrix(Subscript M,        // The number of rows
    Subscript N,               // The number of columns
    const T* v                 // The pointer of array
    );                         // The constructor  form array

    Matrix(Subscript M,        // The number of rows
    Subscript N,               // The number of columns
    const char *s              // The string
    );                         // The constructor  form string
                               //The destructor
    ~Matrix();

    Matrix<T>& newsize(Subscript M, // The number of rows
    Subscript N                     // The number of columns
    );                              // Risizing

    Matrix<T>& operator=(const Matrix<T> &A   // The assignment matrix
    );                                        // The assignment to matrix

    Matrix<T>& operator=(const T& scalar     // The assignment scalar
    );                                       // The assignment to scalar


    Matrix<T>& operator*=(const T& scalar    // The scalar to multiply
    );                                       // Overloaded operation

    Matrix<T>& operator/=(const T& scalar    // The divisor
    );                                       // Overloaded operation

    Subscript dim(Subscript d                // The type of dimension
    ) const;        // Gets dimension (d == 1 - rows d = 2 columns)

    Subscript num_rows() const; // Gets number of rows
    Subscript num_cols() const; // Gets number of columns




    T* operator[](Subscript i  // The number of row
    );                         // Gets the row

    const T* operator[](Subscript i  // The number of row
    ) const;                         // Gets the row

    reference operator()(Subscript i  // The number of the element
    );                                // Access to 1 base element reference

    const_reference operator()(Subscript i  // The number of the element
    ) const;                                // Access to 1 base element reference



    reference operator()(Subscript i,   // The number of row
    Subscript j                         // The number of column
    );                                  // Access to 1 base element reference


    const_reference operator() (Subscript i,  // The number of row
    Subscript j                               // The number of column
    ) const;                                  // Access to 1 base element reference

    void matmult(const T& a     // The scalar to multiply
    );                          // The multiplication to scalar


#ifdef TNT_USE_REGIONS

    typedef Region2D<Matrix<T> > Region;


    Region operator()(const Index1D &I, const Index1D &J);

    typedef const_Region2D< Matrix<T> > const_Region;
    const_Region operator()(const Index1D &I, const Index1D &J) const;

#endif

	Matrix<T> operator~();	// Transposition

	Vector<T> Row(int i		// Row number
		);					// Returns i - th row

	Vector<T> Column(int i	// Column number
		) const;			// Returns i - th row

	void SetRow(int i,			// Row number 
		const Vector<T> & row	// The row
		);						// Sets i - th row

	void SetColumn(int i,		// Column number 
		const Vector<T> & row	// The column
		);						// Sets i - th column

};

template <class T>
inline Subscript Matrix<T>::lbound() const
{
        return 1;
}
    
	template <class T>
    inline void Matrix<T>::initialize(Subscript M, Subscript N)     // internal helper function to create the array
    // of row pointers

    {
        mn_ = M * N;
        m_ = M;
        n_ = N;

        v_ = new T[mn_];
        row_ = new T*[M];
        rowm1_ = new T*[M];

        assert(v_  != NULL);
        assert(row_  != NULL);
        assert(rowm1_ != NULL);

        T* p = v_;
        vm1_ = v_ - 1;
        for (Subscript i=0; i<M; i++)
        {
            row_[i] = p;
            rowm1_[i] = p-1;
            p += N ;

        }

        rowm1_-- ;     // compensate for 1-based offset
    }

    template <class T>
    void Matrix<T>::copy(const T*  v)
    {
        Subscript N = m_ * n_;
        Subscript i;

#ifdef TNT_UNROLL_LOOPS
        Subscript Nmod4 = N & 3;
        Subscript N4 = N - Nmod4;

        for (i=0; i<N4; i+=4)
        {
            v_[i] = v[i];
            v_[i+1] = v[i+1];
            v_[i+2] = v[i+2];
            v_[i+3] = v[i+3];
        }

        for (i=N4; i< N; i++)
        {
            v_[i] = v[i];
        }
#else

        for (i=0; i< N; i++)
        {
            v_[i] = v[i];
        }
#endif
    }
    template <class T>
    inline void Matrix<T>::set(const T& val)
    {
        Subscript N = m_ * n_;
        Subscript i;

#ifdef TNT_UNROLL_LOOPS
        Subscript Nmod4 = N & 3;
        Subscript N4 = N - Nmod4;

        for (i=0; i < N4; i += 4)
        {
            v_[i] = val;
            v_[i+1] = val;
            v_[i+2] = val;
            v_[i+3] = val;
        }

        for (i = N4; i < N; i++)
        {
            v_[i] = val;
        }
#else

        for (i = 0; i < N; i++)
        {
            v_[i] = val;
        }

#endif
    }


    template <class T>
    inline void Matrix<T>::destroy()
    {
        /* do nothing, if no memory has been previously allocated */
        if (v_ == NULL)
        {
                return;
        }

        /* if we are here, then matrix was previously allocated */
        if (v_ != NULL)
        {
                delete [] (v_);
        }
        if (row_ != NULL)
        {
                delete [] (row_);
        }

        /* return rowm1_ back to original value */
        rowm1_++;
        if (rowm1_ != NULL )
        {
                delete [] (rowm1_);
        }
    }

    template <class T>
    inline Matrix<T>::operator T**()
    {
        return  row_;
    }

    template <class T>
    inline Matrix<T>::operator T**() const
    {
        return row_;
    }


    template <class T>
    inline Subscript Matrix<T>::size() const
    {
        return mn_;
    }

    // constructors

    template <class T>
    inline Matrix<T>::Matrix() : m_(0), n_(0), mn_(0), v_(0),
        row_(0), vm1_(0), rowm1_(0)
    {
    }

    template <class T>
    inline Matrix<T>::Matrix(const Matrix<T> &A)
    {
        initialize(A.m_, A.n_);
        copy(A.v_);
    }

    template <class T>
    inline Matrix<T>::Matrix(Subscript M, Subscript N, const T& value)
    {
        initialize(M, N);
        set(value);
    }

    template <class T>
    inline Matrix<T>::Matrix(Subscript M, Subscript N, const T* v)
    {
        initialize(M, N);
        copy(v);
    }

    template <class T>
    inline Matrix<T>::Matrix(Subscript M, Subscript N, const char *s)
    {
        initialize(M, N);
        std::istrstream ins(s);

        Subscript i, j;

        for (i=0; i < M; i++)
            for (j=0; j < N; j++)
                ins >> row_[i][j];
    }

    // destructor
    //
    template <class T>
    inline Matrix<T>::~Matrix()
    {
        destroy();
    }


    template <class T>
    inline Matrix<T>& Matrix<T>::newsize(Subscript M, Subscript N)
    {
        if (num_rows() == M && num_cols() == N)
            return *this;

        destroy();
        initialize(M, N);

        return *this;
    }




    // assignments
    //
    template <class T>
    inline Matrix<T>& Matrix<T>::operator=(const Matrix<T> &A)
    {
        if (v_ == A.v_)
            return *this;

        if (m_ == A.m_  && n_ == A.n_)      // no need to re-alloc
            copy(A.v_);

        else
        {
            destroy();
            initialize(A.m_, A.n_);
            copy(A.v_);
        }

        return *this;
    }

    template <class T>
    inline Matrix<T>& Matrix<T>::operator=(const T& scalar)
    {
        set(scalar);
        return *this;
    }

    template <class T> 
    inline Subscript Matrix<T>::dim(Subscript d) const
    {
#ifdef TNT_BOUNDS_CHECK
       assert( d >= 1);
        assert( d <= 2);
#endif
        return (d == 1) ? m_ : ((d == 2) ? n_ : 0);
    }

    template <class T>
    inline Subscript Matrix<T>::num_rows() const
    {
        return m_;
    }

    template <class T>
    inline Subscript Matrix<T>::num_cols() const
    {
        return n_;
    }



    template <class T>
    inline T* Matrix<T>::operator[](Subscript i)
    {
#ifdef TNT_BOUNDS_CHECK
        assert(0 <= i);
        assert(i < m_) ;
#endif
        return row_[i];
    }

    template <class T> 
    inline const T* Matrix<T>::operator[](Subscript i) const
    {
#ifdef TNT_BOUNDS_CHECK
        assert(0 <= i);
        assert(i < m_) ;
#endif
        return row_[i];
    }

    template <class T> 
    inline T& Matrix<T>::operator()(Subscript i)
    {
#ifdef TNT_BOUNDS_CHECK
        assert(1 <= i);
        assert(i <= mn_) ;
#endif
        return vm1_[i];
    }

    template <class T>
    inline const T& Matrix<T>::operator()(Subscript i) const
    {
#ifdef TNT_BOUNDS_CHECK
        assert(1 <=i );
        assert(i <= mn_) ;
#endif
        return vm1_[i];
    }


    template <class T>
    inline T& Matrix<T>::operator()(Subscript i, Subscript j)
    {
#ifdef TNT_BOUNDS_CHECK
        assert(1 <= i);
        assert(i <= m_) ;
        assert(1 <= j);
        assert(j <= n_);
#endif
        return  rowm1_[i][j]; 
    }



    template <class T> 
    inline const T& Matrix<T>::operator() (Subscript i, Subscript j) const
    {
#ifdef TNT_BOUNDS_CHECK
        assert(1 <= i);
        assert(i <= m_) ;
        assert(1 <= j);
        assert(j <= n_);
#endif
        return rowm1_[i][j];
    }


    template <class T>
    inline void Matrix<T>::matmult(const T& a)
    {
        for (Subscript i = 0; i < m_; i++)
        {
                for (Subscript j = 0; j < n_; j++)
                {
                        _row[i][j] *= a;
                }
        }
    }


#ifdef TNT_USE_REGIONS

    typedef Region2D<Matrix<T> > Region;

    template <class T>
    inline Region Matrix<T>::operator()(const Index1D &I, const Index1D &J)
    {
        return Region(*this, I,J);
    }


    typedef const_Region2D< Matrix<T> > const_Region;
    template <class T>
    inline const_Region Matrix<T>::operator()(const Index1D &I, const Index1D &J) const
    {
        return const_Region(*this, I,J);
    }

#endif


/* ***************************  I/O  ********************************/

template <class T>
std::ostream& operator<<(std::ostream &s, const Matrix<T> &A)
{
    Subscript M=A.num_rows();
    Subscript N=A.num_cols();

    s << M << " " << N << "\n";

    for (Subscript i=0; i<M; i++)
    {
        for (Subscript j=0; j<N; j++)
        {
            s << A[i][j] << " ";
        }
        s << "\n";
    }


    return s;
}

template <class T>
std::istream& operator>>(std::istream &s, Matrix<T> &A)
{

    Subscript M, N;

    s >> M >> N;

    if ( !(M == A.num_rows() && N == A.num_cols() ))
    {
        A.newsize(M, N);
    }


    for (Subscript i = 0; i < M; i++)
    {
        for (Subscript j = 0; j < N; j++)
        {
            s >>  A[i][j];
        }
    }


    return s;
}

// *******************[ basic matrix algorithms ]***************************


template <class T>
Matrix<T> operator+(const Matrix<T> &A, 
    const Matrix<T> &B)
{
    Subscript M = A.num_rows();
    Subscript N = A.num_cols();

    assert(M == B.num_rows());
    assert(N == B.num_cols());

    Matrix<T> tmp(M, N);
    Subscript i, j;

    for (i = 0; i < M; i++)
    {
        for (j = 0; j < N; j++)
        {
            tmp[i][j] = A[i][j] + B[i][j];
        }
    }

    return tmp;
}

template <class T>
Matrix<T> operator-(const Matrix<T> &A, 
    const Matrix<T> &B)
{
    Subscript M = A.num_rows();
    Subscript N = A.num_cols();

    assert(M == B.num_rows());
    assert(N == B.num_cols());

    Matrix<T> tmp(M, N);
    Subscript i, j;

    for (i = 0; i < M; i++)
    {
        for (j = 0; j < N; j++)
        {
            tmp[i][j] = A[i][j] - B[i][j];
        }
    }
    return tmp;
}

template <class T>
Matrix<T> mult_element(const Matrix<T> &A, 
    const Matrix<T> &B)
{
    Subscript M = A.num_rows();
    Subscript N = A.num_cols();

    assert(M==B.num_rows());
    assert(N==B.num_cols());

    Matrix<T> tmp(M,N);
    Subscript i,j;

    for (i = 0; i < M; i++)
    {
        for (j = 0; j < N; j++)
        {
            tmp[i][j] = A[i][j] * B[i][j];
        }
    }

    return tmp;
}


template <class T>
Matrix<T> transpose(const Matrix<T> &A)
{
    Subscript M = A.num_rows();
    Subscript N = A.num_cols();

    Matrix<T> S(N,M);
    Subscript i, j;

    for (i = 0; i < M; i++)
    {
        for (j = 0; j < N; j++)
        {
            S[j][i] = A[i][j];
        }
    }

    return S;
}



template <class T>
inline Matrix<T> matmult(const Matrix<T>  &A,
    const Matrix<T> &B)
{

#ifdef TNT_BOUNDS_CHECK
    assert(A.num_cols() == B.num_rows());
#endif

    Subscript M = A.num_rows();
    Subscript N = A.num_cols();
    Subscript K = B.num_cols();

    Matrix<T> tmp(M, K);
    T sum;

    for (Subscript i = 0; i < M; i++)
    {
        for (Subscript k = 0; k < K; k++)
        {
                sum = 0;
                for (Subscript j = 0; j < N; j++)
                {
                        sum = sum +  A[i][j] * B[j][k];

                        tmp[i][k] = sum;
                }
        }
    }

    return tmp;
}

template <class T>
inline Matrix<T> operator*(const Matrix<T>  &A,
    const Matrix<T> &B)
{
    return matmult(A,B);
}

template <class T>
inline int matmult(Matrix<T>& C, const Matrix<T>  &A,
    const Matrix<T> &B)
{

    assert(A.num_cols() == B.num_rows());

    Subscript M = A.num_rows();
    Subscript N = A.num_cols();
    Subscript K = B.num_cols();

    C.newsize(M,K);

    T sum;

    const T* row_i;
    const T* col_k;

    for (Subscript i = 0; i < M; i++)
    for (Subscript k = 0; k < K; k++)
    {
        row_i  = &(A[i][0]);
        col_k  = &(B[0][k]);
        sum = 0;
        for (Subscript j = 0; j < N; j++)
        {
            sum  += *row_i * *col_k;
            row_i++;
            col_k += K;
        }
        C[i][k] = sum; 
    }

    return 0;
}

template <class T1, class T2>
Vector<T2> matmult(const Matrix<T1>  &A, const Vector<T2> &x)
{

#ifdef TNT_BOUNDS_CHECK
    assert(A.num_cols() == x.dim());
#endif

    Subscript M = A.num_rows();
    Subscript N = A.num_cols();

    Vector<T2> tmp(M);
    T2 sum;

    for (Subscript i = 0; i < M; i++)
    {
        sum = 0;
        const T1 * rowi = A[i];
        for (Subscript j = 0; j < N; j++)
        {
            sum = sum +  T2(rowi[j]) * x[j];
        }

        tmp[i] = sum; 
    }

    return tmp;
}


/*template <class T>
Vector<T> matmult(const Matrix<T>  &A, const Vector<T> &x)
{

#ifdef TNT_BOUNDS_CHECK
    assert(A.num_cols() == x.dim());
#endif

    Subscript M = A.num_rows();
    Subscript N = A.num_cols();

    Vector<T> tmp(M);
    T sum;

    for (Subscript i=0; i< M; i++)
    {
        sum = 0;
        const T* rowi = A[i];
        for (Subscript j=0; j< N; j++)
            sum = sum +  rowi[j] * x[j];

        tmp[i] = sum; 
    }

    return tmp;
}*/

/*
template <class T>
inline Vector<T> operator*(const Matrix<T>  &A, const Vector<T> &x)
{
    return matmult(A,x);
}*/

template <class T1, class T2>
inline Vector<T2> operator*(const Matrix<T1>  &A, const Vector<T2> &x)
{
    return matmult(A,x);
}

template <class T>
inline Matrix<T> operator*(const Matrix<T>  &A, const T &a)
{
    Matrix<T> m(A);
    m.matmult(a);
    return m;
}

template <class T>
inline Matrix<T> operator*(const T &a, const Matrix<T>  &A)
{
    Matrix<T> m(A);
    m.matmult(a);
    return m;
}

template <class T>
inline Matrix<T> operator/(const Matrix<T>  &A, const T &a)
{
    Matrix<T> m(A);
    m.matmult(T(1) / a);
    return m;
}

template <class T>
inline Matrix<T>& Matrix<T>::operator*=(const T& scalar)
{
        matmult(scalar);
        return *this;
}

template <class T>
inline Matrix<T>& Matrix<T>::operator/=(const T& scalar)
{
        matmult(T(1) / scalar);
        return *this;
}

    template <class T>
    inline Matrix<T> Matrix<T>::operator~() 
	{
		return transpose(*this);
	}


template <class T>
Vector<T> Matrix<T>::Row(int i)
{
	Vector<T> v(n_);
	T * r = row_[i];
	for (Subscript j = 0; j < n_; j++)
	{
		v[j] = r[j];
	}
	return v;
}

template <class T>
Vector<T> Matrix<T>::Column(int i) const
{
	Vector<T> v(m_);
	for (Subscript j = 0; j < m_; j++)
	{
		v[j] = v_[i + j * n_];
	}
	return v;
}
	
template <class T>
void Matrix<T>::SetRow(int i, const Vector<T> & row)
{
	T * r = row_[i];
	for (Subscript j = 0; j < n_; j++)
	{
		r[j] = row[j];
	}
}

template <class T>
void Matrix<T>::SetColumn(int i, const Vector<T> & column)
{
	for (Subscript j = 0; j < m_; j++)
	{
		v_[i + j * n_] = column[j];
	}
}



} // namespace TNT

#endif
// CMAT_H
