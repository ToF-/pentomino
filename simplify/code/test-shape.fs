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

COORD>>XY@ SWAP 1 ?S 3 ?S
COORD>>XY@ SWAP 1 ?S 2 ?S
COORD>>XY@ SWAP 1 ?S 1 ?S
COORD>>XY@ SWAP 1 ?S 0 ?S
COORD>>XY@ SWAP 0 ?S 0 ?S
DROP
SHAPE| ##.|
     | .##|
     | .#.|

COORD>>XY@ SWAP 1 ?S 2 ?S
COORD>>XY@ SWAP 2 ?S 1 ?S
COORD>>XY@ SWAP 1 ?S 1 ?S
COORD>>XY@ SWAP 1 ?S 0 ?S
COORD>>XY@ SWAP 0 ?S 0 ?S
DROP
}T
." calibrating" CR
T{
SHAPE| ##.|
     | .##|
     | .#.|
1 1 CALIBRATE
COORD>>XY@ SWAP 1 ?S 1 ?S
COORD>>XY@ SWAP 2 ?S 1 ?S
COORD>>XY@ SWAP 2 ?S 2 ?S
COORD>>XY@ SWAP 3 ?S 2 ?S
COORD>>XY@ SWAP 2 ?S 3 ?S
DROP
}T
." rotating" CR
T{
SHAPE| ##.|
     | .##|
     | .#.|
ROTATE
COORD>>XY@ SWAP 2 ?S 1 ?S
COORD>>XY@ SWAP 1 ?S 0 ?S
COORD>>XY@ SWAP 1 ?S 1 ?S
COORD>>XY@ SWAP 0 ?S 1 ?S
COORD>>XY@ SWAP 0 ?S 2 ?S
DROP
}T
." flipping" CR
T{
SHAPE| ##.|
     | .##|
     | .#.|
FLIP
COORD>>XY@ SWAP 1 ?S 2 ?S
COORD>>XY@ SWAP 0 ?S 1 ?S
COORD>>XY@ SWAP 1 ?S 1 ?S
COORD>>XY@ SWAP 1 ?S 0 ?S
COORD>>XY@ SWAP 2 ?S 0 ?S
DROP
}T
BYE
