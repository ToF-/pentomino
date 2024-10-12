\ shapes.fs

: SHAPE ( color,h-size,v-size <name> -- addr )
    2DUP * >R
    CREATE
    ROT C, SWAP C, C, 0 C,
    HERE
    R> ALLOT ;

: COLOR ( shape -- c )
    C@ ;

: H-SIZE ( shape -- n )
    1+ C@ ;

: V-SIZE ( shape -- n )
    2 + C@ ;

: CURRENT-LINE ( shape -- n )
    3 + C@ ;

: GRID ( shape -- addr )
    3 + ;

: CURRENT-LINE++ ( shape -- )
    3 + 1 SWAP +! ;

: | ( shape, <ccccc|> -- shape )
    DUP H-SIZE
    OVER CURRENT-LINE *
    OVER GRID OVER +
    [CHAR] | WORD COUNT CMOVE ;

: APPLY-COLOR ( addr,c --  )
    OVER C@ [CHAR] . = IF DROP 0 THEN
    SWAP C! ;

: ;SHAPE ( shape -- )
    DUP V-SIZE 0 DO
        DUP H-SIZE 0 DO
            DUP GRID OVER H-SIZE J * I +
            OVER COLOR APPLY-COLOR
    LOOP LOOP DROP ;

: .COLOR ( c -- )
    ESC[
    DUP IF
        DUP 8 < IF 30 ELSE 8 - 40 THEN +
        2 .R [CHAR] m EMIT
    ELSE
        ." 0m"
    THEN ;

: .SHAPE-ELEMENT ( shape,x,y -- )
    AT-XY COLOR .COLOR [CHAR] # EMIT
    0 .COLOR ;

: .SHAPE ( shape,x,y -- )
    ROT DUP V-SIZE 0 DO
        DUP H-SIZE 0 DO
            DUP GRID OVER H-SIZE J * I +
            C@ IF
                -ROT
                2DUP I J TRANSLATE
                -ROT .SHAPE-ELEMENT
            THEN
    LOOP LOOP DROP ;
