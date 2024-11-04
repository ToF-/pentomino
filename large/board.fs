\ board.fs

REQUIRE coords.fs
REQUIRE pieces.fs

SIZE DUP * CONSTANT BOARD%

2VARIABLE TARGET

CREATE BOARD BOARD% ALLOT

: EMPTY-BOARD
    BOARD BOARD% ERASE ;

: PIECE-AT ( x,y -- n )
    8 * + BOARD + C@ ;

: PLACE-BLOCK-AT ( p,x,y -- )
    8 * + BOARD + C! ;

: PLACE-BLOCK ( c,p -- )
    TARGET 2@ COORDS+XY PLACE-BLOCK-AT ;

: PLACE-SHAPE ( sh#,x,y -- )
    TARGET 2!  DUP NTH-SHAPE CATEGORY  \ sh#,p#
    >R COORDS 0 R>                  \ c1,c2,c3,c4,0,p#
    5 0 DO
        DUP ROT PLACE-BLOCK
    LOOP DROP ;

: EMPTY-SQUARE? ( x,y -- f)
    PIECE-AT 0= ;

: ON-BOARD? ( categ -- f )
    FALSE SWAP
    BOARD DUP BOARD% + SWAP DO
        DUP I C@ =
        ROT OR SWAP
    LOOP DROP ;

: (FITTING?) ( sh#,x,y -- f )
    TARGET 2!
    COORDS 0 TRUE
    5 0 DO
        SWAP
        TARGET 2@ COORDS+XY
        EMPTY-SQUARE? AND
    LOOP ;

: FITTING? ( sh#,x,y -- f)
    ROT DUP NTH-SHAPE
    CATEGORY ON-BOARD? IF
        2DROP DROP FALSE
    ELSE
        -ROT (FITTING?)
    THEN ;

