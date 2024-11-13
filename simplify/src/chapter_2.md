# Acquiring Shapes

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
SHAPE| ##.|
     | .#.|
     | .#.|
     | .#.|
```
and end up with a list of ten values on the stack.

`SHAPE|` would start the acquisition process.
`|` would acquire a new line for the current shape

Since row and column values varies between 0 and 4, they can easily be stored in a nibble. Thus 5 couples of coordinates can be stored in 5 bytes, which is less than than the size of a cell in gforth.

