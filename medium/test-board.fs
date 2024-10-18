\ test-board.fs

REQUIRE ffl/tst.fs
REQUIRE board.fs
REQUIRE display.fs

." board" CR
."    encode positions of squares on a binary cell" CR
T{
    EMPTY-BOARD 0 0 BOARD<XY! 1 ?S
    EMPTY-BOARD 1 0 BOARD<XY! HEX 02 ?S DECIMAL
    EMPTY-BOARD 0 1 BOARD<XY! HEX 100 ?S DECIMAL
    EMPTY-BOARD 1 1 BOARD<XY! HEX 200 ?S DECIMAL
    EMPTY-BOARD 2 2 BOARD<XY! HEX 40000 ?S DECIMAL
    EMPTY-BOARD 1 0 BOARD<XY! 0 1 BOARD<XY! 1 1 BOARD<XY! 2 1 BOARD<XY! 1 2 BOARD<XY!

    2 BASE ! 000000100000011100000010 DECIMAL ?S
}T
."    accumulates positions of squares on a binary cell" CR
T{
    EMPTY-BOARD
    0 0 BOARD<XY!
    1 0 BOARD<XY!
    0 1 BOARD<XY!
    1 1 BOARD<XY!
    2 2 BOARD<XY!
    2 BASE ! 1000000001100000011 ?S DECIMAL
}T
."    rotates squares on a binary cell" CR
T{
    VARIABLE MY-BOARD
    EMPTY-BOARD 0 0 BOARD<XY! 1 0 BOARD<XY! 2 0 BOARD<XY! 0 1 BOARD<XY! MY-BOARD !
    MY-BOARD @ BOARD-ROTATE 
    EMPTY-BOARD 0 7 BOARD<XY! 0 6 BOARD<XY! 0 5 BOARD<XY! 1 7 BOARD<XY! ?S
}T
."    flips squares on a binary cell" CR
T{
    MY-BOARD @ BOARD-FLIP
    EMPTY-BOARD 7 0 BOARD<XY! 6 0 BOARD<XY! 5 0 BOARD<XY! 7 1 BOARD<XY! ?S
}T


