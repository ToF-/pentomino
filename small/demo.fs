\ demo.fs

REQUIRE shapes.fs
REQUIRE display.fs

5 2 1 8 SHAPE UPPERI
    | #####|
    ;SHAPE

3 3 2 8 SHAPE BIRD
    | .##|
    | ##.|
    | .#.|
    ;SHAPE

4 2 3 8 SHAPE UPPERL
    | ...#|
    | ####|
    ;SHAPE

3 3 4 8 SHAPE BRIDGE
    | ###|
    | #.#|
    ;SHAPE

4 2 5 8 SHAPE UPPERL
    | ####|
    | #...|
    ;SHAPE

4 2 6 8 SHAPE LOWERT
    | .#..|
    | ####|
    ;SHAPE

4 2 7 8 SHAPE SNAKE
    | ..##|
    | ###.|
    ;SHAPE

3 3 9 8 SHAPE UPPERT
    | ###|
    | .#.|
    | .#.|
    ;SHAPE

3 3 10 8 SHAPE LOWERS
    | .##|
    | .#.|
    | ##.|
    ;SHAPE

3 3 11 8 SHAPE CORNER
    | ###|
    | #..|
    | #..|
    ;SHAPE

3 2 12 8 SHAPE HOUSE
    | ##.|
    | ###|
    ;SHAPE

3 3 13 8 SHAPE STAIRS
    | ##.|
    | .##|
    | ..#|
    ;SHAPE

3 3 14 8 SHAPE CROSS
    | .#.|
    | ###|
    | .#.|
    ;SHAPE


VARIABLE Y
VARIABLE X

: .ALL-POS
    8 0 DO
        DUP DUP I POS
        I 6 * X @ + Y @
        .POS
    LOOP DROP ;

: DEMO
     0 X !
     0 Y ! BIRD   .ALL-POS
     5 Y ! UPPERL .ALL-POS
    10 Y ! UPPERI .ALL-POS
    15 Y ! BRIDGE .ALL-POS
    20 Y ! SNAKE  .ALL-POS
    25 Y ! LOWERT .ALL-POS
    50 X !
     0 Y ! UPPERT .ALL-POS
     5 Y ! LOWERS .ALL-POS
    10 Y ! CORNER .ALL-POS
    15 Y ! HOUSE  .ALL-POS
    20 Y ! STAIRS .ALL-POS
    25 Y ! SNAKE  .ALL-POS


    ;

PAGE DEMO 0 60 AT-XY

BYE





