\ test-board.fs

REQUIRE ffl/tst.fs
REQUIRE board.fs
REQUIRE display.fs

." board" CR
."     can place a shape" CR
T{
    EMPTY-BOARD
    2 0 0 PLACE-SHAPE
    1 5 0 dbg PLACE-SHAPE
    BOARD 64 DUMP
}T
."     can check if a shape fits on it" CR
T{
}T


