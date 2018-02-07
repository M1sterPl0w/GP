#include "stdafx.h"
#include "PlayerState.h"
#include <iostream>

using namespace std;

PlayerState::PlayerState (const char* n, int l, double h, int e){
	this->name = n;
	this->level = l;
	this->health = h;
}

void PlayerState::print() {
	cout << "Name: " << this->name << ", Level: " << this->level << ", Health: " << this->health << endl;
}