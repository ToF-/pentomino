\ shapes.fs

REQUIRE coords.fs

5 CONSTANT COORDS%

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

: POS-MAX ( shape -- n )
    3 + C@ ;

: GRID ( shape -- addr )
    4 + ;

: GRID-AT ( shape,y,x -- addr )
    -ROT OVER H-SIZE *
    ROT + SWAP GRID + ;

: POS ( shape,n -- addr )
    COORDS% * OVER SIZE +
    SWAP GRID + ;

: CURRENT-LINE++ ( shape -- )
    1+ 16 SWAP +! ;

: TOTAL-SIZE ( shape -- n )
    DUP SIZE SWAP POS-MAX COORDS% * + ;

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

: INIT-POS ( shape -- )
    DUP 0 POS SWAP
    DUP V-SIZE 0 DO
        DUP H-SIZE 0 DO
            DUP J I GRID-AT C@ IF
                SWAP I J )C OVER C!
                1+ SWAP
            THEN
    LOOP LOOP
    DROP COORDS% ))CENTER ;

: COPY-POS ( srce )
    DUP COORDS% + COORDS% CMOVE ;

: 3ROT-FLIP-3ROT ( shape -- )
    0 POS
    DUP COPY-POS COORDS% + DUP COORDS% ))ROTATE
    DUP COPY-POS COORDS% + DUP COORDS% ))ROTATE
    DUP COPY-POS COORDS% + DUP COORDS% ))ROTATE
    DUP COPY-POS COORDS% + DUP COORDS% ))ROTATE DUP COORDS% ))FLIP
    DUP COPY-POS COORDS% + DUP COORDS% ))ROTATE
    DUP COPY-POS COORDS% + DUP COORDS% ))ROTATE
    DUP COPY-POS COORDS% + DUP COORDS% ))ROTATE
    DROP ;

: ;SHAPE ( shape -- )
    DUP INIT-POS
    3ROT-FLIP-3ROT ;

: ROTATE-LEFT ( x,y -- -y,x )
    NEGATE SWAP ;

: FLIP ( x,y -- x,-y )
    NEGATE ;
