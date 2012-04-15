Team XFire (Crossfire)
----------------------
Josh Kierpiec
Andrew Barge
Mark Gehan
Chris Baum



BadAssTanks - Base Build 2 Readme


Table of Contents
=================
1.) Input
	a.) Keyboard Input
	b.) Mouse Input (Next Build)
2.) GamePlay
3.) Known Bugs



1.) Input:
==========

Keyboard input is captured via the Keyboard Handler. Movement and rotation of the tank are 
handled by the UP and DOWN keys and the LEFT and RIGHT keys, respectively. 

	a.)Keyboard Input:
	==================

	Rotating and Moving the tank:
	-----------------------------
	Left Arrow - Rotates the tank to the left.
	Right Arrow - Rotates the tank to the right.
	Up Arrow - Moves the tank forward in the direction it is facing.
	Down Arrow - Move the tank in the opposite direction it is facing.

	F1 - Toggles fullscreen mode.
	Esc - Closes down the application.
	P - Paused rendering. No key input will be taken other than Esc/F1 or P to unpause.

	b.) Mouse Input:
	================

	The mouse will be used in order to aim the tank's turret to provide an aiming mechanism
	for destroying enemies. The mouse cursor will be hidden during gameplay and the user
	will be able to move the mouse around the tank, thus moving the tank's turret.

	The firing of weapons will be utilized by clicking and holding the left mouse button.

2.) Gameplay:
=============

For this build, a test gameworld is displayed in order to test boundary checking, tile animation,
and world construction.  The tank can explore this world, with the only boundary collision being
with the outside of the drawn world.  Grass tiles are drawn with a yellow boundary in order to 
determine the accuracy of world tile and tile coordinate tracking.  

Text debug output is shown in the upper left portion of the screen.  The first pair of coordinates
are tracking the tanks position within a specific tile.  The center of a tile is the point (0, 0)
with the width and height both being 1 unit in length.  The second pair of coordinates is the current
tile the tank is residing in.  The bottom left corner of the screen is the (0, 0) tile, with the top
right of the screen being the (width, height) tile.

Known Bugs:
====================

BASE BUILD 1
============

- When holding down more than one arrow, the tank gyrates between the two movements. This is due to the
way keyboard input is handled.  == (FIXED) ==

- When moving the tank in windowed mode, the tank is placed back at the origin when fullscreen mode
is enabled.  == (FIXED) ==

BASE BUILD 2
============

- When changing the size of the window, the tank appears to stretch and compress when it turns.

