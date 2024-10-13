\ test-puzzle.fs

REQUIRE ffl/tst.fs
REQUIRE puzzle.fs
REQUIRE shapes.fs

." puzzle" CR

."     it can receive pieces of different shapes and positions" CR
T{
    CREATE MY-PUZZLE PUZZLE% ALLOT
    MY-PUZZLE EMPTY-PUZZLE
    3 3 4 4 SHAPE BRIDGE
    | ###|
    | #.#|
    ;SHAPE

    3 3 5 1 SHAPE CROSS
    | .#.|
    | ###|
    | .#.|
    ;SHAPE
    
    BRIDGE 0 0 0 )C MY-PUZZLE PLACE-SHAPE
    CROSS  0 0 1 )C MY-PUZZLE PLACE-SHAPE
}T

."     finding the next free cell" CR
T{
    MY-PUZZLE NEXT-FREE-CELL 3 0 )C ?S
}T

."     checking if a shape can fit" CR
T{
    4 2 6 8 SHAPE THISL
    | ...#|
    | ####|
    ;SHAPE
    
    THISL 5 7 0 )C MY-PUZZLE  CAN-FIT ?FALSE
    THISL 5 1 0 )C MY-PUZZLE CAN-FIT ?FALSE
    THISL 5 2 0 )C MY-PUZZLE CAN-FIT ?TRUE
}T
