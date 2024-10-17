\ test-situation.fs

REQUIRE ffl/tst.fs
REQUIRE situation.fs

: BINARY
    2 BASE ! ;

." situation" CR

."    empty situation" CR
T{   
    EMPTY-SITUATION 0 0 0 ?S ?S ?S
}T
."    creating a key value from a piece" CR
T{
    CROSS PIECE-NUMBER 1 2 3 PIECE-KEY BINARY 1001011010 ?S DECIMAL
    UPPERI PIECE-NUMBER 1 7 7 PIECE-KEY BINARY 10011111110000000000 ?S DECIMAL
}T

BYE
."    adding a piece to a situation" CR
T{
    EMPTY-SITUATION
    CROSS PIECE-NUMBER 1 2 3 dbg KEY-VALUE
    BINARY 100000011100000010 ?S DECIMAL
    BINARY 1000000000 ?S DECIMAL
    DROP
}T
BYE
."    a piece with a given orientation and location as puzzle sitution" CR
T{
    CROSS PIECE-NUMBER 0 0 0 SITUATION
    2 BASE ! 100000011100000010 ?S
    NIP HEX 200 ?S DECIMAL  \ 1000 000000

    CROSS PIECE-NUMBER 0 7 7 SITUATION
    -1 ?S 2DROP

    SNAKE PIECE-NUMBER 0 0 0 SITUATION
    2 BASE ! 110000000111 ?S
    DROP HEX 2000000000000 ?S DECIMAL  \ 1000 000000 0000 000000 0000 000000 0000 000000 0000 000000

    UPPERI PIECE-NUMBER 0 0 0 SITUATION
    2 BASE ! 11111 ?S
    NIP HEX 80000 ?S DECIMAL      \  1000 000000 0000 000000

    UPPERI PIECE-NUMBER 1 0 0 SITUATION
    2 BASE ! 0000000100000001000000010000000100000001 ?S
    NIP HEX 90000 ?S DECIMAL

    UPPERI PIECE-NUMBER 1 4 0 SITUATION
    2 BASE ! 1000000010000000100000001000000010000 ?S
    NIP HEX 91000 ?S DECIMAL
}T

."    collect all possible for a given piece" CR
T{
    CROSS SITUATION-SET CROSS-SITUATIONS
    CROSS-SITUATIONS @ 36 ?S

    UPPERI SITUATION-SET UPPERI-SITUATIONS
    UPPERI-SITUATIONS @ 64 ?S

    HOUSE SITUATION-SET HOUSE-SITUATIONS
    HOUSE-SITUATIONS @ 336 ?S

}T

."    collect all possible unions of two pieces" CR
T{
    CREATE MY-SET SITUATION-SET% ALLOT
    MY-SET SITUATION-SET% ERASE
    CROSS-SITUATIONS UPPERI-SITUATIONS MY-SET UNION
    MY-SET @ 1608 ?S
    MY-SET CELL+ 100 SITUATION% * + SITUATION@ 40 30 .SITUATION
    35 10 AT-XY KEY DROP
}T
