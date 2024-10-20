\ test-board.fs

REQUIRE board.fs

." board" CR
."     can place a shape" CR
T{
    EMPTY-BOARD
    BOARD 64 DUMP
    2 0 0 PLACE-SHAPE
    1 5 0 PLACE-SHAPE
    BOARD 64 DUMP
}T
."     can check if a shape fits on it" CR
T{
    EMPTY-BOARD
    2 0 0 CAN-FIT? ?TRUE
    2 5 0 CAN-FIT? ?FALSE
}T


