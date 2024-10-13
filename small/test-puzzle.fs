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
    MY-PUZZLE PUZZLE% DUMP
    MY-PUZZLE .PUZZLE
    
}T

