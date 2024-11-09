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
DECIMAL
." getting coordinates" CR
T{
SHAPE| ##.|
     | .##|
     | .#.|

GET-SHAPE-COORDS
0 NTH-COORDS@ SWAP 0 ?S 0 ?S
1 NTH-COORDS@ SWAP 1 ?S 0 ?S
2 NTH-COORDS@ SWAP 1 ?S 1 ?S
3 NTH-COORDS@ SWAP 2 ?S 1 ?S
4 NTH-COORDS@ SWAP 1 ?S 2 ?S
ROTATE-SHAPE-COORDS
0 NTH-COORDS@ SWAP 2 ?S 0 ?S         \ ..#
1 NTH-COORDS@ SWAP 2 ?S 1 ?S         \ ###
2 NTH-COORDS@ SWAP 1 ?S 1 ?S         \ .#.
3 NTH-COORDS@ SWAP 1 ?S 2 ?S
4 NTH-COORDS@ SWAP 0 ?S 1 ?S

}T
CR
BYE
