\ test-pieces.fs

REQUIRE ffl/tst.fs
REQUIRE pieces.fs
REQUIRE display.fs

." pieces" CR
."     have a category and an orientation" CR
T{
    1  NTH-SHAPE DUP PIECE CROSS-SHAPES ?S ORIENTATION 0 ?S
    63 NTH-SHAPE DUP PIECE HOUSE-SHAPES ?S ORIENTATION 7 ?S
    15 NTH-SHAPE DUP PIECE BRIDGE-SHAPES ?S ORIENTATION 3 ?S
    14 NTH-SHAPE DUP PIECE BRIDGE-SHAPES ?S ORIENTATION 2 ?S
}T
."     have a list of square relative coords" CR
: REORDER 2>R SWAP 2R> SWAP 2SWAP ;
T{
    ' .COORDS IS (.BLOCK) .DEMO
}T




