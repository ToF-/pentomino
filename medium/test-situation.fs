\ test-situation.fs

REQUIRE ffl/tst.fs
REQUIRE situation.fs
REQUIRE display.fs

: BINARY
    2 BASE ! ;

." situation" CR

."    empty situation" CR
T{   
    EMPTY-SITUATION 0 0 0 ?S ?S ?S
}T
."    creating a key value from a piece" CR
T{
    CROSS PNO 0 2 3 PIECE-KEY BINARY 1000011010 ?S DECIMAL
    UPPERI PNO 1 7 7 PIECE-KEY BINARY 10011111110000000000 ?S DECIMAL
}T
."    creating a board value from a piece" CR
T{
    CROSS PNO 0 0 0 PIECE-BOARD BINARY 000000100000011100000010 ?S DECIMAL
    UPPERI PNO 0 0 0 PIECE-BOARD BINARY 11111 ?S DECIMAL
    UPPERI PNO 1 0 0 PIECE-BOARD BINARY 100000001000000010000000100000001 ?S DECIMAL
    LOWERS PNO 0 0 0 PIECE-BOARD BINARY 110000001000000110 ?S DECIMAL
}T
."    creating a one piece situation for a piece number within 0-5" CR
T{
    UPPERI PNO 0 0 0 PIECE-SITUATION
    BINARY 11111 ?S DECIMAL
    BINARY 10000000000000000000 ?S DECIMAL
    0 ?S
}T
."    creating a one piece situation for a piece number within 6-11" CR
T{
    LOWERS PNO 0 0 0 PIECE-SITUATION
    BINARY 110000001000000110 ?S DECIMAL
    0 ?S
    BINARY 1000000000 ?S DECIMAL
}T
."    merging two piece situations together (assuming they are fitting together)" CR
T{
    UPPERI PNO 0 0 0 PIECE-SITUATION
    CROSS  PNO 0 0 1 PIECE-SITUATION
    MERGE-SITUATIONS
    BINARY 10000001110000001000011111 ?S DECIMAL
    BINARY 10000000001000001000 ?S DECIMAL
    0 ?S
}T
."    checking that a piece is fitting at a position" CR
T{
    UPPERI PNO 0 7 0 FITTING? ?FALSE
    UPPERI PNO 0 3 0 FITTING? ?TRUE
    UPPERI PNO 1 0 7 FITTING? ?FALSE
    UPPERI PNO 1 0 3 FITTING? ?TRUE
}T
."    checking that two situations can be merged: case of conflicting squares" CR
T{
    UPPERI PNO 0 0 0 PIECE-SITUATION
    CROSS  PNO 0 0 0 PIECE-SITUATION
    MERGING? ?FALSE
    UPPERI PNO 0 0 0 PIECE-SITUATION
    CROSS  PNO 0 0 1 PIECE-SITUATION
    MERGING? ?TRUE
}T
."    checking that two situations can be merged: case of piece already present" CR
T{
    UPPERI PNO 0 0 0 PIECE-SITUATION
    UPPERI PNO 0 0 1 PIECE-SITUATION
    MERGING? ?FALSE
    UPPERI PNO 0 0 0 PIECE-SITUATION
    CROSS  PNO 0 0 1 PIECE-SITUATION
    MERGING? ?TRUE
    SNAKE  PNO 0 0 0 PIECE-SITUATION
    SNAKE  PNO 0 0 3 PIECE-SITUATION
    MERGING? ?FALSE
    UPPERI PNO 0 0 0 PIECE-SITUATION
    SNAKE  PNO 0 0 3 PIECE-SITUATION
    MERGING? ?TRUE
}T
."    collect all possible situation for a given piece" CR

: .DEMO
    3 * CELLS OVER + SWAP DO
        I SITUATION@
        .BOARD KEY DROP
        2DROP 
    3 CELLS +LOOP ;
T{
    CROSS PNO PIECE-SITUATIONS CROSS-SITUATIONS
    CROSS-SITUATIONS @ 36 ?S

    UPPERI PNO PIECE-SITUATIONS UPPERI-SITUATIONS
    UPPERI-SITUATIONS @ 64 ?S

    HOUSE PNO PIECE-SITUATIONS HOUSE-SITUATIONS
    HOUSE-SITUATIONS @ 336 ?S

    CROSS-SITUATIONS  FREE 0 ?S
    UPPERI-SITUATIONS FREE 0 ?S
    HOUSE-SITUATIONS  FREE 0 ?S

}T
BYE
."    collect all possible situations for two pieces" CR
T{
    CROSS-SITUATIONS UPPERI-SITUATIONS MERGE MY-SET
}T


