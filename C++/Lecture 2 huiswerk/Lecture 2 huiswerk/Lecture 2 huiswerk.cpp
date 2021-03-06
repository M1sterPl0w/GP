// Lecture 2 huiswerk.cpp : Defines the entry point for the console application.
//
#include "stdafx.h"
#include "Fraction.hpp"
#include "PlayerState.h"
#include <iostream>
#include <fstream>
#include <string>
using namespace std;

// is strlen oke? of moet ik echt opzoek naar het einde \0
bool Palindrome(char word[]) {
	int lastChar = strlen(word) - 1;
	int iets = strlen(word) / 2;
	for (int i = 0; i < iets; i++)
	{
		if (word[i] != word[lastChar - i])
			return false;
	}
	return true;
}


void ex5_read_textfile(string filename)
{
	char letter;
	ifstream file;
	file.open(filename);
	if (file.is_open())
	{
		letter = file.get();
		while (!file.eof())
		{
			cout << letter;
			letter = file.get();
		}
		file.close();
	}
	else
		cout << "unable to open file " << filename << endl;
}

// Wel even vragen over ╠╠╠╠╠╠╠╠, kan dit weg?
void PrintText() {
	ifstream inputFile;
	inputFile.open("test.txt");
	char test[1024];
	inputFile.read(test, 1024);
	for (int i = 0; ; i++)
	{
		if (test[i] == NULL)
			break;
		cout << test[i];
	}
	cout << endl;
	inputFile.close();
}

int main()
{
	// Excercise 2
	Fraction fraction(3, 12);
	fraction.simplify();
	fraction.print();

	// Excercise 3
	char names[10][40];
	strcpy_s(names[0], "Donald Duck");
	strcpy_s(names[1], "Bob de Bouwer");
	strcpy_s(names[2], "Peter Griffin");
	strcpy_s(names[3], "Homer Simpson");
	for (int i = 0; i < 4; i++)
		cout << i << " " << names[i] << endl;

	// Excercise 4
	char word[] = "Hallo";
	cout << Palindrome(word) << endl;
	char word2[] = "kok";
	cout << Palindrome(word2) << endl;
	char word3[] = "kook";
	cout << Palindrome(word3) << endl;
	
	// Excercise 5
	//PrintText();
	ex5_read_textfile("test.txt");

	// Hoe een array mee geven?
	// Excercise 7
	PlayerState player1("Piet", 1, 100, 0);
	PlayerState player2("Jan", 100, 100, 90);
	PlayerState player3("Peter", 20, 90, 10);
	PlayerState eenArray[3]{player1, player2, player3};
	for (int i = 0; i < 3; i++)
		eenArray[i].print();
	cin.get();
}




