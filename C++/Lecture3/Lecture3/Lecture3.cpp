// Lecture3.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

const char* test;

int main()
{
	test = "Hello world";
	test = "Byebye";
	cout << test << endl;
	cin.get();
}

