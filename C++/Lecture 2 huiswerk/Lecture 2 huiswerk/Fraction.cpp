#include "Fraction.hpp"
#include "stdafx.h"
#include <iostream>
using namespace std;

Fraction::Fraction(int num, int den) {
	numerator = num;
	denominator = den;
}

int Fraction::gcd(int a, int b)
{
	if (a == 0)
		return b;
	if (b == 0)
		return a;
		
	if (a > b)
		return gcd(a % b, b);
	else
		return gcd(a, b % a);
}

void Fraction::simplify() {
	int temp = gcd(numerator, denominator);
	numerator /= temp;
	denominator /= temp;
}

void Fraction::print() {
	//cout << "Numerator: " << numerator << " Denominator: " << denominator << endl;
}


