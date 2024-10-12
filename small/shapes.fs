\ shapes.fs

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

: CURRENT-LINE++ ( shape -- )
    1+ 16 SWAP +! ;

: TOTAL-SIZE ( shape -- n )
    DUP SIZE SWAP POSITION-MAX 10 * + ;

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

: ;SHAPE ( shape -- )
    DROP ;

: ROTATE-LEFT ( x,y -- -y,x )
    NEGATE SWAP ;

: FLIP ( x,y -- x,-y )
    NEGATE ;
