\ demo.fs

REQUIRE shapes.fs
REQUIRE display.fs

3 3 4 8 SHAPE SNAKE
    | .##|
    | ##.|
    | .#.|
    ;SHAPE

4 2 1 8 SHAPE UPPERL
    | ...#|
    | ####|
    ;SHAPE

VARIABLE Y

: .ALL-POS
    8 0 DO
        DUP DUP I POS
        I 5 * Y @
        .POS
    LOOP DROP ;

: DEMO
    1 Y ! SNAKE .ALL-POS
    6 Y ! UPPERL .ALL-POS ;

PAGE DEMO 10 10 AT-XY

BYE





