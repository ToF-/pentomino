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
EXTRACT
SWAP 0 ?S 0 ?S
SWAP 1 ?S 0 ?S
SWAP 1 ?S 1 ?S
SWAP 1 ?S 2 ?S
SWAP 1 ?S 3 ?S

SHAPE| ##.|
     | .##|
     | .#.|
EXTRACT
SWAP 0 ?S 0 ?S
SWAP 1 ?S 0 ?S
SWAP 1 ?S 1 ?S
SWAP 2 ?S 1 ?S
SWAP 1 ?S 2 ?S
}T
." translating CR
T{
SHAPE| ##.|
     | .##|
     | .#.|
1 2 (TRANSLATE) EXTRACT
SWAP 1 ?S 2 ?S
SWAP 2 ?S 2 ?S
SWAP 2 ?S 3 ?S
SWAP 3 ?S 3 ?S
SWAP 2 ?S 4 ?S
}T
." rotating" CR
T{
SHAPE| ##.|
     | .##|
     | .#.|
ROTATE EXTRACT
SWAP 0 ?S 2 ?S
SWAP 0 ?S 1 ?S  \ .#.
SWAP 1 ?S 1 ?S  \ ###
SWAP 1 ?S 0 ?S  \ #..
SWAP 2 ?S 1 ?S
}T
." flipping" CR
T{
SHAPE| ##.|
     | .##|
     | .#.|
FLIP EXTRACT
SWAP 2 ?S 0 ?S
SWAP 1 ?S 0 ?S  \ .##
SWAP 1 ?S 1 ?S  \ ##.
SWAP 0 ?S 1 ?S  \ ...
SWAP 1 ?S 2 ?S
}T
BYE
