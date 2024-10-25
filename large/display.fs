\ display.fs

REQUIRE colors.fs
REQUIRE board.fs
REQUIRE coords.fs

DEFER (.BLOCK)

: XY+ ( x,y,i,j -- x+i,y+j )
    ROT + -ROT + SWAP ;

: .BLOCK ( x,y,c -- )
    COORDS>XY XY+
    (.BLOCK) ;

: .SHARP ( x,y -- )
    AT-XY [CHAR] # EMIT ;

: .COORDS ( x,y -- )
    [CHAR] [ EMIT 32 EMIT
    SWAP . . 
    [CHAR] ] EMIT ;

' .COORDS IS (.BLOCK)

: .SHAPE ( c1,c2,c3,c4,x,y -- )
    0 -ROT
    5 1 DO
        2DUP 2>R ROT .BLOCK 2R>
    LOOP 2DROP ;

: .BOARD
    8 0 DO
        8 0 DO
            I J 2DUP EMPTY-SQUARE? IF
                .NORMAL
                AT-XY [CHAR] . EMIT
            ELSE
                2DUP PIECE-AT .COLOR
                AT-XY [CHAR] # EMIT
            THEN
    LOOP LOOP
    .NORMAL ;

: .DEMO
    64 1 DO
        I NTH-SHAPE PIECE .COLOR
        I COORDS
        I 8 /MOD
        6 * 3 + SWAP
        6 * 3 + SWAP
        .SHAPE
    LOOP .NORMAL DROP ;


