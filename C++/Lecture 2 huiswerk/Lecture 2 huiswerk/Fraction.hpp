#pragma once
class Fraction 
{
public:
	Fraction(int a, int b);
	void simplify();
	void print();
private:
	int numerator;
	int denominator;
	int gcd(int a, int b);
};