#pragma once

struct PlayerState {
	PlayerState(const char* name, int level, double health, int experience);
	const char* name;
	int level;
	double health;
	int experience;
	void print();
};