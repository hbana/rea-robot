# rea-robot
REA Coding Challenge

This is a C# console application, built using .NET Framework 4.5.2. The Visual Studio solution file to view source-code and unit tests is located in rea-robot/rea-robot-code directory, and the C# code is available within sub-directories.

Test Data:

PLACE 0,0,NORTH <ENTER>
LEFT <ENTER>
REPORT <ENTER>
0,0,WEST
<ENTER>

PLACE 1,2,EAST <ENTER>
MOVE <ENTER>
MOVE <ENTER>
LEFT <ENTER>
MOVE <ENTER>
REPORT <ENTER>
3,3,NORTH 
<ENTER>

PLACE 0,0,NORTH <ENTER>
MOVE <ENTER>
REPORT <ENTER>
0,1,NORTH
<ENTER>

MOVE <ENTER>
RIGHT <ENTER>
REPORT <ENTER>
No robot placed on the tabletop
<ENTER>

PLACE 6,6,NORTH <ENTER>
... Invalid Command <ENTER>
REPORT <ENTER>
No robot placed on the tabletop
<ENTER>

PLACE 4,4,SOUTH <ENTER>
LEFT <ENTER>
MOVE <ENTER>
... Invalid command <ENTER>
REPORT <ENTER>
4,4,EAST
<ENTER>
