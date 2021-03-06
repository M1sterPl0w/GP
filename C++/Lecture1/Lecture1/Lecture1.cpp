// Lecture1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <cmath>
#include "helper.h"

using namespace std;
#define LOG(x) cout << x << endl

int gcd(int a, int b);

// Excercise 8 'LCM
int lcm(int a, int b)
{
	return (a * b) / gcd(a, b);
}

// Excercise 7 'GCD' | Euclidean algorithm | recursive -> gevonden op internet
int gcd(int a, int b)
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

// Excercise 7 'GCD' | zelf
int gcd2(int a, int b)
{
	int temp; 
	while (b > 0)
	{
		temp = b;
		b = a % b;
		a = temp;
	}
	return a;
}

int gcd3(int a, int b)
{
	if (b == 0)
		return a;
	return (gcd3(a, a % b));
}

// Excercise 6 'bubble sort'
void bubbelSort(int array[], int size)
{
	int swap;

	for (int c = 0; c < (size - 1); c++)
	{
		for (int d = 0; d < size - c - 1; d++)
		{
			if (array[d] > array[d + 1]) /* For decreasing order use < */
			{
				swap = array[d];
				array[d] = array[d + 1];
				array[d + 1] = swap;
			}
		}
	}
}

// betere bubbelSort 
void bubbelSort2(int array[], int size)
{
	int swap;
	for (int c = 0; c < (size - 1); c++)
	{
		for (int d = 0; d < size - c - 1; d++)
		{
			if (array[d] > array[d + 1])
			{
				swap = array[d];
				array[d] = array[d + 1];
				array[d + 1] = swap;
			}
			break;
		}
	}
}

// Excercise 5
// HOE ZONDER SIZE? ZIE OPGAVEN
int contains(int a[], int size, int value)
{
	for (int i = 0; i < size; i++)
	{
		if (a[i] == value)
			return i;
	}
	return -1;
}

// Excercise 4
bool isPrime(int n)
{
	int a;

	if (n == 1)
		return true;

	for (a = 2; a <= (n / 2); a++)
		if ((n % a) == 0)
			return false;
	return true;
}

// Excercise 3
int power(int base, int exponent)
{
	if (exponent < 1)
		return 1;
	return base * power(base, exponent - 1);
}

// Excercise 2
void checkEven(int a)
{
	cout << (a % 2 == 0 ? "even" : "oneven") << endl;
}

// Excercise 1
int sum(int a, int b)
{
	return a + b;
}

int main()
{
	int myArray[4] = { 223, 23, 14, 25 };
	printArray(myArray, 4);
	bubbelSort(myArray, 4);
	printArray(myArray, 4);
	LOG(gcd2(54, 888));
	LOG(lcm(30, 66));
	cin.get();
}

