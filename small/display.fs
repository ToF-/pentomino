\ display.fs

REQUIRE shapes.fs

: COLOR-CODE ( color -- n )
    8 MOD 30 + ;

: CHAR-CODE ( color -- c )
    8 / IF [CHAR] X ELSE [CHAR] # THEN ;

: .COLOR ( color -- )
    ESC[ COLOR-CODE
    2 .R ." m" ;

: .NORMAL
    ESC[ ." 0m" ;

: .BLOCK ( c,x,y -- )
    2* SWAP 2* SWAP
    ROT DUP .COLOR
    CHAR-CODE DUP
    2OVER AT-XY 2DUP EMIT EMIT
    2SWAP 1+ AT-XY EMIT EMIT
    .NORMAL ;

: <++> ( a,b,c,d -- a+b,c+d )
    ROT + -ROT + SWAP ;

2VARIABLE COORDS

: .SHAPE ( shape,x,y -- )
    COORDS 2!
    DUP V-SIZE 0 DO
        DUP H-SIZE 0 DO
            DUP GRID OVER H-SIZE J * I + +
            C@ IF 
                DUP COLOR
                COORDS 2@ I J <++>
                .block
            THEN
    LOOP LOOP DROP ;

