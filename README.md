# RiskPOC
Exploration of TDD behavior based C# unit tests using the instructions to the board game Risk.

This code represents a personal experiment in expressing behavior based unit tests in C#.  
Tenets of SOLID and DRY are used.
I used the instructions manual for the board game Risk.  
The code is imcomplete (May 2015).
There is no graphical user interface and is not a playable game.

The solution is divided into the rules engine and the unit tests.  

The rules engine code is devided into models and services.

The unit tests are broken down by events including:

  - At the beginning of the game
  - At the beginning of the player's turn
  - At the end of the player's turn.
