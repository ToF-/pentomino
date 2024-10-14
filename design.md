
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



