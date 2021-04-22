#pragma once

class VectorProvider
{
public:
	virtual int GetVectorCount() const = 0; //Returns the number of vectors providing
	virtual TNT::Vector<double> GetVector(int i) const = 0; //Returns the i'th providing vector 
};
