// Lecture3.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

// Excercise 2
void createArray(int* &p, int n) {
	p = new int[n];
	for (int i = 0; i < n; i++)
	{
		p[i] = i + 1;
	}
}

void ex1(){
	// Excercise 1
	int* p = new int;
	int* q = new int;
	int* r;

	*p = 2;
	*q = 3;

	cout << "P: " << *p << ", Q: " << *q << endl;

	r = q;
	q = p;
	p = r;

	cout << "P: " << *p << ", Q: " << *q << endl;

	delete p;
	delete q;
}

void ex3(int** &p, int n){
	int i, j;
	p = new int*[n];
	for (i = 0; i < n; i++)
	{
		p[i] = new int[i + 1];
		p[i][0] = 1;
		p[i][i] = 1;
		for (j = 1; j < i; j++)
			p[i][j] = p[i - 1][j - 1] + p[i - 1][j];
	}
}

int main(){
	ex1();

	// Excercise 2
	int* p;
	createArray(p, 10);
	for (int i = 0; i < 10; i++)
	{
		cout << p[i] << endl;
	}
	delete p;
	// Excercise 3
	int** pa;
	ex3(pa, 10);

	for (int i = 0; i < 10; i++)
	{
		for (int j = 0; j <= i; j++)
		{
			if (pa[i][j] < 10)  // alignment
				cout << " ";
			if (pa[i][j] < 100) // alignment
				cout << " ";
			cout << pa[i][j] << " ";
		}
		cout << endl;
	}
	cin.get();
}

