\ shapes.fs

: COLOR ( shape -- c )
    C@ ;

: H-SIZE ( shape -- n )
    1+ C@ ;

: V-SIZE ( shape -- n )
    2 + C@ ;

: CURRENT-LINE ( shape -- n )
    3 + C@ ;

: GRID ( shape -- addr )
    4 + ;

: CURRENT-LINE++ ( shape -- )
    3 + 1 SWAP +! ;

: SHAPE ( color,h-size,v-size <name> -- addr )
    CREATE
    HERE >R
    ROT C, SWAP C, C, 0 C,
    R> DUP H-SIZE OVER V-SIZE * ALLOT ;

: | ( shape, <ccccc|> -- shape )
    DUP H-SIZE
    OVER CURRENT-LINE *
    OVER GRID +
    [CHAR] | WORD COUNT
    -ROT SWAP ROT CMOVE
    DUP CURRENT-LINE++ ;

: APPLY-COLOR ( addr,c --  )
    OVER C@ [CHAR] . = IF DROP 0 THEN
    SWAP C! ;

: ;SHAPE ( shape -- )
    DUP V-SIZE 0 DO
        DUP H-SIZE 0 DO
            DUP COLOR SWAP
            DUP GRID
            OVER H-SIZE J * I + +
            ROT APPLY-COLOR
    LOOP LOOP DROP ;

: .COLOR ( c -- )
    ESC[
    DUP IF
        DUP 8 < IF 30 ELSE 8 - 40 THEN +
        2 .R [CHAR] m EMIT
    ELSE
        DROP ." 0m"
    THEN ;

: .SHAPE-ELEMENT ( shape,x,y -- )
    AT-XY COLOR .COLOR [CHAR] # EMIT
    0 .COLOR ;

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
