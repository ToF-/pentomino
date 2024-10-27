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

: PLACE-BLOCK ( p,x,y -- )
    8 * SWAP +
    BOARD + C! ;

: PLACE-NEXT ( c,p -- )
    TARGET 2@ COORDS+XY PLACE-BLOCK ;

: PLACE-SHAPE ( sh#,x,y -- )
    TARGET 2!  DUP NTH-SHAPE PIECE  \ sh#,p#
    >R COORDS 0 R>                  \ c1,c2,c3,c4,0,p#
    5 0 DO
        DUP ROT PLACE-NEXT
    LOOP DROP ;

: EMPTY-SQUARE? ( x,y -- f)
    PIECE-AT 0= ;

: FITTING? ( sh#,x,y -- f )
    TARGET 2!
    COORDS 0 TRUE
    5 0 DO
        SWAP
        TARGET 2@ COORDS+XY
        EMPTY-SQUARE? AND
    LOOP ;

