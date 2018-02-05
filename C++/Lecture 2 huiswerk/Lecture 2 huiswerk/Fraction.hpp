#pragma once
class Fraction 
{
public:
	Fraction(int n, int d);
	void simplify();
	void print();
private:
	int numerator;
	int denominator;
	int gcd(int a, int b);
};