\ display.fs

REQUIRE colors.fs

DEFER (.BLOCK)

: COORDS>XY ( c -- x,y )
    DUP 16 /MOD
    OVER 8 >= IF
        2DROP -16 /MOD NEGATE
    ELSE
        ROT DROP
    THEN ;

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
    5 0 DO
        2DUP 2>R ROT .BLOCK 2R>
    LOOP 2DROP ;

: .DEMO
    64 1 DO
        I NTH-SHAPE CATEGORY .COLOR
        I COORDS
        I 8 /MOD
        6 * 3 + SWAP
        6 * 3 + SWAP
        .SHAPE
    LOOP
    0 56 AT-XY .NORMAL ;
