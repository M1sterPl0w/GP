// Lecture5-random.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <cmath>
#include <ctime>
#include <chrono>
#include <thread>

int random(const long int mn = pow(2, 32))
{
	long long int static seed = 0;
	const long int m = mn;
	const int a = 1664525;
	const int c = 1013904223;
	seed = (a * seed + c) % m;
	return seed;
}


int main()
{
	while (true)
	{
		if (clock() % 400 == 0)
		{
			std::cout << random() << std::endl;
		}
	}

	std::cin.get();
    return 0;
}

