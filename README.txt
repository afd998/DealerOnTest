Mars Rovers
Coding test for DealerOn
Atticus Deutsch
10/7/20

Assumptions:
  1. If the rover goes out of bounds, its execution is terminated and its position is not logged.
  2. If there are no commands for a rover, a blank line will be left in the input file instead of having the intial position of the next rover be imediately following the initial position of the current rover.
  3. Negative coridinates are not allowed (the orgin is always the southwest corner).
  4. Bounds are set once per run.
  5. Bounds and intial position have space seperated components while commands are not space seperated.


Design:

  1.The input lines are read in and converted to an IEnumerator type.
  2.The bounds of the grid and parsed and saved to fields of the program's class

  3. We check if there is a next line. If not, we are done. If so, we parse it as an initial position.
  4. If the initial position is has valid parse we instanciate a rover with its x y and head positions as fields.
  5. We atempt to move the rover according to the next line of the input.
  6. If that succeeds, we print the ending location, else we have printed the error and move on the the next rover  starting over at step


HOW TO EXECUTE:

type your bounds and initial position and commands in input.txt

To build+run cd into the folder and run:

$ dotnet build; dotnet run

to clear binaries run:

$ dotnet clean

(Make sure you have dotnet installed and the .NET CLI)




