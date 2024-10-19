

---


the puzzle is solved when all the pieces are placed on a 8x8 grid, without holes

pieces can rotate, flip vertically or flip horizontally


```
# # # #

###
#
#

  #
###
#

####
 #

 ##
##
 #

 ##
##
#

###
# #

 #
###
 #

   #
####

#####

#
###
#

 #
##
##

 #
 #
##
#

 ##
##
#

```

display: a 8x8 square where space is empty, and pieces are made from hex numbers : 0 1 2 3 4 5 6 7 8 9 A B C D E F


```
0,1,2,3 : [(0,0)]
▓

4       : [(0,0),(0,1),(0,2),(0,3),(0,4)]   
4a     
▓▒▒▒▒

4b
▓
▒
▒
▒
▒


5a     : [(0,0),(0,1),(0,2),(0,3),(1,3)]
   ▒
▓▒▒▒

5b
▓
▒
▒
▒▒

5c
▒▒▒▓
▒

5d
▒▒
 ▒
 ▒
 ▓

5e
▓▒▒▒
   ▒

5f
 ▓
 ▒
 ▒
 ▒
▒▒

5g
▒
▒▒▒▓

5h
▒▒
▒
▒
▓

6a
  #
@###


7
  #
  #
###

8
 #
 #
###

9
  #
###
#

10
  ##
###

11
##
###

12
# #
###

13
 ##
##
#

14
 ##
##
 #

15
 #
###
 #


```
AAABCCCC
ABBB0CDD
ABEE1DDF
0EE888DF
0E2878FF
063777F5
06667455
06444455

(or colors)

a piece is a list of coords (row,col)
A,1,2,3: [(0,0)]

9: [(0,0),(0,1),(0,2),(0,3),(1,3)]

5: [(0,0),(0,1),(1,0),(1,1),(2,1)]

6: [(0,0),(1,0),(1,1),(1,2),(2,0)]

7: [(0,1),(1,0),(1,1),(1,2),(2,1)]

8: [(0,0),(0,2),(1,0),(1,1),(1,2)]

0: [(0,0),(1,0),(2,0),(3,0),(4,0)]

A: [(0,0),(1,0),(2,0),(2,1),(2,2)]

B: [(0,0),(1,0),(1,1),(1,2),(2,2)]

C: [(0,1),(1,0),(1,1),(1,2),(1,3)]

D: [(0,1),(1,0),(1,1),(2,1),(2,2)]

E: [(0,0),(1,0),(1,1),(2,1),(2,2)]

F: [(0,0),(1,0),(1,1),(2,1),(2,1)]

all piece surfaces are either 1 square or 5 squares
each piece should have a (0,0) square, used as pivoting point for rotation or flipping
ex1 : write a program that draw each piece on the terminal


If we except small squares, each piece has an area of 5 squares.

The square1, square2, square3, square4 have only 1 possible orientation (no rotation or flip) but we don't manage these pieces since their location on the board can be deduced from the positions of all other pieces.

The cross has only 1 possible orientation (no rotation or flip)
The upper I has 2 two possible orientations (horizontal or vertical)
The bridge, the corner, the stairs, the upper T have 4 orientations (rotations)
The lower S has 4 orientations (rotation and flip)
The lower T, the upper L, the bird, the snake, the house have 8 orientations (rotations, flipped rotations)
For a total of 63 possibles shapes
0 : cross
1 : upper I, horizontal
2 : upper I, vertical
3 : upper T, north
…
63 : house, flipped, east

cross   : 0
upper I : 1,2 (pos:0…3,on/off)
bridge  : 3,4,5 ditto
corner  : 6,7,8 ditto
stairs  : 9,10,11 ditto
upper T : 12,13,14 ditto
lower S : 15,16,17 ditto
lower T : 18,19,20,21 (pos:0…7,on/off)
upper L : 22,23,24,25 ditto
bird    : 26,27,28,29
snake   : 30,31,32,33
house   : 34,36,36,37


HOUS-SNAK-BIRD-UPPL-LOWT-LOWS-UPPT-STRS-CORN-BRDG-UPPI-CRSS = 6 bytes

0: CROSS
1: UPPERI
2: BRIDGE 3: CORNER 4: STAIRS 5: UPPERT
6: LOWERS
7: LOWERT 8: UPPERL 9: BIRD 10: SNAKE 11: HOUSE

0: 0 0  -1 1  0 1  1 1  0 1
1: 0 0  1 0  2 0  3 0  4 0   0 0  0 1  0 2  0 3  0 4
2: 0 0  1 0  2 0  0 1  2 1   0 0  1 0  0 1  0 2  1 2   0 0  2 0  0 1  1 1  2 1   0 0  1 0  1 1  0 2  1 2
3: 0 0  1 0  2 0  0 1  0 2   0 0  0 1  0 2  1 2  2 2   0 0  1 0  2 0  2 -1  2  -2   0 0  1 0  2 0  2 1  2 2



(X=not used)
byte 0: cross on/XXX, upper I on/orient XX0…XX1
byte 1: bridge on/X00…X11, corner on/X00…X11
byte 2: stairs on/X00…X11, upper T on/X00…X11
byte 3: lower S on/X00…X11, lower T on/000…111
byte 4: upper L on/000…111,  bird on/000…111
byte 5: snake on/000…111, house on/000…111

byte 6,7,8: cross location 000000…111111, upper I location 000000…111111, bridge location 000000…111111, corner location 000000…111111
byte 9,10,11: stairs location, upper T location, lower S location, lower T location
byte 12,13,14: upper L location, bird Location, snake location, house location

byte 15: not used

byte 16: squares 0 to 7 (occupied/free)
byte 17: squares 8 to 15
byte 18: squares 16 to 23
byte 19: squares 24 to 31
byte 20: squares 32 to 39
byte 21: squares 40 to 47
byte 22: squares 48 to 55
byte 23: squares 56 to 63 

24 bytes = 3 cells






Each shape taken alone can be placed on several squares on a empty puzzle
The cross can be placed on squares 9,1 to 6,8 hence 36 possible locations
The upper I position 0 (horizontal) can be placed on squares 0,0 to 3,7 hence 32 locations

We can characterize a puzzle by stating for each of the 12 pieces :
- if the piece is on the board or not (bit 9)
- its orientation (bits 6…8)
- its starting location (bits 0…5)

120 bits are necessary for 12 pieces, 15 bytes.

Such each distinct configuration on the board can be encoded as a 15 bytes key.
Furthermore, each distinct configuration on the board has a binary trace, with one bit for each square occupied by a piece, which holds into a 64 bit cell. 

example
``` 
cross (0), orientation 0, in position 1,1 (9)  … 0000 0000 0010 0000 1001
00 00 00 00 00 00 00 00 00 00 00 00 00 02 09 

trace on the board : only squares 1,8,9,10,17   … 10 0000 0111 0000 0010
00 00 00 00 00 02 07 02

upperi (1), orientation 0, in position 0,2 (2) … 1000 0000 1000 0000 0000
00 00 00 00 00 00 00 00 00 00 00 08 08 00 00

trace on the board : only squares 2,3,4,5,6    … 00111 1100
00 00 00 00 00 00 00 7C


the two pieces above, combined on same board : … 1000 0000 1010 0000 1001
00 00 00 00 00 00 00 00 00 00 00 08 0A 09

their trace on the board          0010 0000  0111 0111 1110
00 00 00 00 00 00 07 7E
```
knowing if two pieces in their location can fit together on the same board is easy : if the piece A trace AND piece B trace yields 0, they fit together.

The strategy is thus :
- set the list of all possible configurations for piece A
- set the list of all posiible configurations for piece B

- compute Ai AND Bi, Aj AND Bi … An AND Bn, keeping only those configurations that are compatible R and S
- compute Ar OR Bs, the new configurations where piece A and B coexist in a new list AB

- compute ABi AND Ci, ABj AND Cj … keeping only those configurations where A,B and C pieces fit together


This strategy is taking way too much operations.

What about limiting the merge to situations where at least one piece from the second set is adjacent to one piece of thef first set.

the situation board is for instance 00011111  (UPPERI in 0,0) then merging is possible only with situations having one these squares : 5,8,9,10,11,12

(mark N the board made of all neighbors of A, then the merge candidate is B where
- B inter A is null
- B inter B is non null




