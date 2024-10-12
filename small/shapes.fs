\ shapes.fs

REQUIRE coords.fs

5 CONSTANT COORDS-PER-SHAPE

: H-SIZE ( shape -- n )
    C@ ;

: V-SIZE ( shape -- n )
    1+ C@ 15 AND ;

: SIZE ( shape -- n )
    DUP H-SIZE SWAP V-SIZE * ;

: COLOR ( shape -- c )
    2 + C@ ;

: CURRENT-LINE ( shape -- n )
    1+ C@ 4 RSHIFT ;

: POSITION-MAX ( shape -- n )
    3 + C@ ;

: GRID ( shape -- addr )
    4 + ;

: GRID-AT ( shape,y,x -- addr )
    -ROT OVER H-SIZE *
    ROT + SWAP GRID + ;

: POSITION ( shape,n -- addr )
    COORDS-PER-SHAPE * OVER SIZE +
    SWAP GRID + ;

: CURRENT-LINE++ ( shape -- )
    1+ 16 SWAP +! ;

: TOTAL-SIZE ( shape -- n )
    DUP SIZE SWAP POSITION-MAX COORDS-PER-SHAPE * + ;

: ALLOT-SHAPE ( shape -- )
    TOTAL-SIZE ALLOT ;

: ERASE-SHAPE ( shape -- )
    DUP GRID SWAP TOTAL-SIZE ERASE ;

: SHAPE ( h,v,c,p <name> -- addr )
    2SWAP CREATE HERE -ROT
    SWAP C, C, -ROT SWAP C, C,
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

: CAPTURE-COORDS ( shape -- )
    DUP 0 POSITION SWAP
    DUP V-SIZE 0 DO
        DUP H-SIZE 0 DO
            DUP J I GRID-AT C@ IF
                SWAP I J )C OVER C!
                1+ SWAP
            THEN
    LOOP LOOP
    DROP COORDS-PER-SHAPE ))CENTER ;

: ;SHAPE ( shape -- )
    CAPTURE-COORDS ;

: ROTATE-LEFT ( x,y -- -y,x )
    NEGATE SWAP ;

: FLIP ( x,y -- x,-y )
    NEGATE ;
