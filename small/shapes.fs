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
    DUP SIZE SWAP POS-MAX 15 AND COORDS% * + ;

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

: ROTATE ( pos -- )
    COORDS% ))ROTATE ;

: FLIP ( pos -- )
    COORDS% ))FLIP ;

: NEXT-POS ( pos -- pos' )
    DUP COPY-POS COORDS% + ;

: 3ROT-FLIP-3ROT ( shape -- )
    0 POS
    NEXT-POS DUP ROTATE
    NEXT-POS DUP ROTATE
    NEXT-POS DUP ROTATE
    NEXT-POS DUP ROTATE DUP FLIP
    NEXT-POS DUP ROTATE
    NEXT-POS DUP ROTATE
    NEXT-POS ROTATE ;

: 1ROT ( shape -- )
    0 POS
    NEXT-POS ROTATE ;

: 3ROT ( shape -- )
    0 POS
    NEXT-POS DUP ROTATE
    NEXT-POS DUP ROTATE
    NEXT-POS ROTATE ;

: 1ROT-FLIP-1ROT ( shape -- )
    DUP 3 + 4 SWAP C!
    0 POS
    NEXT-POS DUP ROTATE
    NEXT-POS DUP ROTATE DUP FLIP
    NEXT-POS ROTATE ;

: ;SHAPE ( shape -- )
    DUP INIT-POS
    DUP POS-MAX
    DUP 8 = IF DROP 3ROT-FLIP-3ROT ELSE
    DUP 4 = IF DROP 3ROT ELSE
    DUP 20 = IF DROP 1ROT-FLIP-1ROT ELSE
    DUP 2 = IF DROP 1ROT ELSE
    DROP DROP THEN THEN THEN THEN ;

