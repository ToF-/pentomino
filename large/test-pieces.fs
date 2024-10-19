\ test-pieces.fs

REQUIRE ffl/tst.fs
REQUIRE pieces.fs

." pieces" CR
."     have a category and an orientation" CR
T{
    1  NTH-SHAPE DUP CATEGORY CROSS-SHAPES ?S ORIENTATION 0 ?S
    63 NTH-SHAPE DUP CATEGORY HOUSE-SHAPES ?S ORIENTATION 7 ?S
    15 NTH-SHAPE DUP CATEGORY BRIDGE-SHAPES ?S ORIENTATION 3 ?S
    14 NTH-SHAPE DUP CATEGORY BRIDGE-SHAPES ?S ORIENTATION 2 ?S
}T
."     have a list of square relative coords" CR
: REORDER 2>R SWAP 2R> SWAP 2SWAP ;
T{
    1 COORDS REORDER 7 ?S 8 ?S 9 ?S 16 ?S
}T



