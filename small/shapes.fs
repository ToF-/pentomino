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

