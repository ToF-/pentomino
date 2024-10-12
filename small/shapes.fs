\ shapes.fs

: H-SIZE ( shape -- n )
    C@ ;

: V-SIZE ( shape -- n )
    1+ C@ ;

: SIZE ( shape -- n )
    DUP H-SIZE SWAP V-SIZE * ;

: COLOR ( shape -- c )
    2 + C@ ;

: CURRENT-LINE ( shape -- n )
    3 + C@ ;

: GRID ( shape -- addr )
    4 + ;

: CURRENT-LINE++ ( shape -- )
    3 + 1 SWAP +! ;

: ALLOT-SHAPE ( shape -- )
    SIZE ALLOT ;

: ERASE-SHAPE ( shape -- )
    DUP GRID SWAP SIZE ERASE ;

: SHAPE ( h,v,c <name> -- addr )
    -ROT CREATE HERE -ROT
    SWAP C, C, SWAP C, 0 C,
    DUP ALLOT-SHAPE DUP ERASE-SHAPE ;

: APPLY-COLOR ( addr,color,c --  )
    [CHAR] . = IF DROP 0 THEN
    SWAP C! ;

: (|) ( addr,c <ccccc|> -- )
    [CHAR] | WORD COUNT
    OVER + SWAP DO
        2DUP I C@ APPLY-COLOR
        SWAP 1+ SWAP
    LOOP 2DROP ;

: | ( shape, <ccccc|> -- shape )
    DUP H-SIZE OVER CURRENT-LINE *
    OVER GRID + OVER COLOR (|)
    DUP CURRENT-LINE++ ;

: ;SHAPE ( shape -- )
    DROP ;

: .BLOCK-COLOR ( c -- )
    8 MOD 30 + ESC[ 2 .R [CHAR] m EMIT ;

: .BLOCK-CHAR ( c -- )
    8 / IF [CHAR] X ELSE [CHAR] # THEN DUP EMIT EMIT ;

: .BLOCK ( c -- )
    DUP .BLOCK-COLOR .BLOCK-CHAR ;

: .NORMAL
    ESC[ ." 0m" ;

: XY-BLOCK ( x,y -- 2x,2y,2x,2y+1 )
    SWAP 2* SWAP 2* 2DUP 1+ ;

: .SHAPE-ELEMENT ( shape,x,y -- )
    ROT COLOR >R XY-BLOCK
    AT-XY R@ .BLOCK
    AT-XY R> .BLOCK
    .NORMAL ;

: <++> ( a,b,c,d -- a+b,c+d )
    ROT + -ROT + SWAP ;

: .SHAPE ( shape,x,y -- )
    ROT DUP V-SIZE 0 DO
        DUP H-SIZE 0 DO
            DUP GRID OVER H-SIZE J * I + +
            C@ IF
                -ROT 2DUP I J <++> 2>R
                ROT DUP 2R> .SHAPE-ELEMENT
            THEN
    LOOP LOOP
    DROP 2DROP ;
