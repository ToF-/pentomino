\ demo.fs

REQUIRE pieces.fs
REQUIRE display.fs


: .PIECES 
    PIECE-MAX 0 DO
        PIECES I CELLS + @
        DUP ORIENT-MAX 0 DO
            DUP I
            J 6 / 50 * I 6 * + J 6 MOD 6 * .PIECE
        LOOP DROP
    LOOP ;

PAGE
.PIECES
.NORMAL
5 53 AT-XY
BYE
