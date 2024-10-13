\ demo.fs

REQUIRE ffl/tst.fs
REQUIRE display.fs
REQUIRE pieces.fs

T{
VARIABLE Y
VARIABLE X

: .ALL-POS
    DUP POS-MAX 15 AND 0 DO
        DUP DUP I POS
        I 6 * X @ + Y @
        .POS
    LOOP DROP ;

: DEMO
    MAX-PIECES 0 DO
        I 6 /MOD 50 * X ! 5 * Y !
        I PIECE .ALL-POS
    LOOP ;

PAGE DEMO 0 60 AT-XY
}T
BYE





