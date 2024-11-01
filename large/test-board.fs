\ test-board.fs

REQUIRE ffl/tst.fs
REQUIRE board.fs
REQUIRE display.fs

." board" CR
."    can place a shape" CR
T{
    EMPTY-BOARD
    2 0 0 PLACE-SHAPE
    1 5 0 PLACE-SHAPE
    4 3 3 PLACE-SHAPE
    14 0 3 PLACE-SHAPE
    63 2 1 PLACE-SHAPE
    BOARD 64 DUMP CR
    \ KEY DROP PAGE .BOARD
}T
."    can check that a shape fits" CR
T{
    EMPTY-BOARD
    2 0 0 PLACE-SHAPE
    2 0 0 FITTING? ?FALSE
    43 6 4 FITTING? ?TRUE
}T
."   a shape can't fit if piece is already on board" CR
T{
    EMPTY-BOARD
    14 0 3 PLACE-SHAPE
    15 4 4 FITTING? ?FALSE
}T
."   first free square" CR
T{
    EMPTY-BOARD
    2 0 0 PLACE-SHAPE
    0 0 FIRST-FREE-SQUARE ?TRUE SWAP 5 ?S 0 ?S
    14 5 0 PLACE-SHAPE
    5 0 FIRST-FREE-SQUARE ?TRUE SWAP 6 ?S 0 ?S
    6 0 FIRST-FREE-SQUARE ?TRUE SWAP 0 ?S 1 ?S
}T


