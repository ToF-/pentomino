\ display.fs

DEFER (.BLOCK)

: .BLOCK ( c,x,y -- )
    ROT 16 /MOD
    ROT + -ROT + SWAP 
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

