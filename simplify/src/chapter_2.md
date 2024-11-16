# Shape coordinates

What is a shape ? It's a list of square relative positions, for instance the shape :
```
  012

0 ##.
1 .#.
2 .#.
3 .#.

```
Can be defined with the list : {(0,0),(1,0),(1,1),(2,1),(3,1)} where each couple is the row and column of each square respectively.

How can we automatically capture a shape as drawn above with a forth word ? What we'd like is to encode a shape's squares in a way that gives us a list of coords in the end, like this :
```
SHAPE
| ##.|
| .#.|
| .#.|
| .#.|
```
and end up with a list of coordinates. Since row and column values varies between 0 and 4, they can easily be stored in a 4 bit nibble. Thus 5 couples of coordinates can be stored in 5 bytes, which is less than than the size of a cell in gforth.

To insert a 4 bit value in a cell, we shift this cell 4 bits on the left, apply a 4 bit mask on the value, and do a bitwise or between the cell and the value. An x,y coord can be inserted by repeating this operation.

 ```
 4 CONSTANT NIBBLE
 15 CONSTANT VALUE-MASK

: SHAPE<<N ( n,coords -- coords' )
    NIBBLE LSHIFT SWAP VALUE-MASK AND OR ;

: SHAPE<<XY ( x,y,coords -- coords' )
    SHAPE<<N SHAPE<<N ;

```
Let's check our words:
```
REQUIRE ffl/tst.fs
REQUIRE shape.fs
HEX
1 1 2 1 3 1 3 2 3 3 0 SHAPE<<XY SHAPE<<XY SHAPE<<XY SHAPE<<XY SHAPE<<XY
3323131211 ?S
BYE
```
