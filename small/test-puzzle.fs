\ test-puzzle.fs

REQUIRE ffl/tst.fs
REQUIRE puzzle.fs
REQUIRE shapes.fs
REQUIRE pieces.fs

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

."     finding the next free square" CR
T{
    MY-PUZZLE NEXT-FREE-SQUARE 3 0 )C ?S
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
."     solved if only four square are empy" CR
: PL
    )C MY-PUZZLE PLACE-SHAPE ;
T{
    MY-PUZZLE SOLVED? ?FALSE
    MY-PUZZLE EMPTY-PUZZLE
    CORNER 0    0 0 PL
    LOWERS 3    1 0 PL
    LOWERT 4    4 0 PL
    BIRD   0    5 1 PL
    UPPERI 1    0 3 PL
    STAIRS 3    1 2 PL
    BRIDGE 0    3 3 PL
    SNAKE  5    6 2 PL
    UPPERT 3    1 5 PL
    CROSS  0    3 4 PL
    UPPERL 0    2 6 PL
    HOUSE  3    6 5 PL
    MY-PUZZLE SOLVED? ?TRUE


}T
