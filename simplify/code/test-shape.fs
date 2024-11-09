\ test-shape

REQUIRE ffl/tst.fs
REQUIRE shape.fs

." acquiring a shape" CR
T{

HEX
SHAPE| ##.|
     | .#.|
     | .#.|
     | .#.|

0010111213 ?S

SHAPE| ##.|
     | .##|
     | .#.|

0010112112 ?S
}T
." getting coordinates" CR
T{
SHAPE| ##.|
     | .##|
     | .#.|
XYS!
0 #XY@ SWAP 0 ?S 0 ?S
1 #XY@ SWAP 1 ?S 0 ?S
2 #XY@ SWAP 1 ?S 1 ?S
3 #XY@ SWAP 2 ?S 1 ?S
4 #XY@ SWAP 1 ?S 2 ?S
XYS>>COORDS
0010112112 ?S
}T
." rotating coordinates" CR
T{
ROTATE-XYS
XYS>>COORDS
2021111201 ?S
}T
." flipping coordinates" CR
T{
FLIP-XYS
0 #XY@ SWAP 0 ?S 0 ?S         \ #..
1 #XY@ SWAP 0 ?S 1 ?S         \ ###
2 #XY@ SWAP 1 ?S 1 ?S         \ .#.
3 #XY@ SWAP 1 ?S 2 ?S
4 #XY@ SWAP 2 ?S 1 ?S
}T
CR
BYE
