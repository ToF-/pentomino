\ test-board.fs

REQUIRE ffl/tst.fs
REQUIRE board.fs
REQUIRE display.fs

." board" CR
."     can place a shape" CR
T{
    EMPTY-BOARD
    2 0 0 PLACE-SHAPE
    1 5 0 PLACE-SHAPE
    4 3 3 PLACE-SHAPE
    40 1 1 PLACE-SHAPE
    14 0 3 PLACE-SHAPE
    63 2 1 PLACE-SHAPE
    BOARD 64 DUMP
    KEY DROP
    PAGE
    .BOARD
}T


