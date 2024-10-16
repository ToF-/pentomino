\ test-situation.fs

REQUIRE ffl/tst.fs
REQUIRE situation.fs

." puzzle" CR

."    a piece with a given orientation and location as puzzle sitution" CR
T{
    CROSS PIECE-NUMBER 0 0 0 SITUATION
    2 BASE ! 100000011100000010 ?S
    NIP HEX 80 ?S DECIMAL

    CROSS PIECE-NUMBER 0 7 7 SITUATION
    -1 ?S 2DROP

    SNAKE PIECE-NUMBER 0 0 0 SITUATION
    2 BASE ! 110000000111 ?S
    DROP HEX 800000 ?S DECIMAL

    UPPERI PIECE-NUMBER 0 0 0 SITUATION
    2 BASE ! 11111 ?S
    NIP HEX 8000 ?S DECIMAL

    UPPERI PIECE-NUMBER 1 0 0 SITUATION
    2 BASE ! 0000000100000001000000010000000100000001 ?S
    NIP HEX 9000 ?S DECIMAL

    UPPERI PIECE-NUMBER 1 4 0 SITUATION
    2 BASE ! 1000000010000000100000001000000010000 ?S
    NIP HEX 9400 ?S DECIMAL
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
    CROSS-SITUATIONS UPPERI-SITUATIONS MY-SET UNION
    MY-SET @ 3146 ?S
    MY-SET .SITUATION-SET
}T
