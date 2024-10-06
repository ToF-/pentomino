
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
