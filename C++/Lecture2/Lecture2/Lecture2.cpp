// Lecture2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <stdlib.h>
#include <cstring>

using namespace std;

int main()
{
	const int Length = 40;
	char name[Length];
	int attempts = 0;
	char guess[Length];
	char temp[Length];
	cout << "Please enter word: " << endl;
	cin.getline(name, Length);
	strcpy_s(temp, name);
	for (int i = 0; i < strlen(name) / 2; i++)
	{
		int x = rand() % strlen(name) - 1;
		temp[x] = '.';
	}

	cout << "Word is: " << temp << endl;

	
	do {
		if (attempts >= 10)
		{
			cout << "Loser" << endl;
			break;
		}
		if (attempts > 1)
			cout << "Attempt: " << attempts << " guessed: " << guess << endl;

		cin.getline(guess, Length);
		attempts++;
	} while (strcmp(name, guess));

	return 0;
}

