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
    LOOP 
    KEY DROP PAGE
    -1. SHAPE-INDEX 2!
    BEGIN
        NEXT-SHAPE-INDEX
        SHAPE-INDEX 2@ -1. D<> WHILE
        CURRENT-SHAPE-POS SHAPE-INDEX 2@ SWAP 5 * SWAP 5 * SWAP .POS
    REPEAT ;
        
PAGE DEMO 0 60 AT-XY
}T
BYE





