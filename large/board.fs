\ board.fs

REQUIRE coords.fs
REQUIRE pieces.fs

CREATE BOARD 64 ALLOT

: EMPTY-BOARD
    BOARD 64 ERASE ;

: PIECE-AT ( x,y -- n )
    8 * + BOARD + C@ ;

: PLACE-BLOCK ( p,x,y -- )
    10 / 8 * SWAP +
    BOARD + C! ;

: PLACE-SHAPE ( sh#,x,y -- )
    TARGET 2!
    DUP NTH-SHAPE PIECE           \ sh#,p#
    >R COORDS R>                  \ c1,c2,c3,c4,p#
    DUP TARGET-XY PLACE-BLOCK     \ c1,c2,c3,c4,p# 
    4 0 DO
        DUP ROT
        TARGET-XY COORDS+XY? IF
            PLACE-BLOCK
        THEN
    LOOP DROP ;

: EMPTY-SQUARE? ( x,y -- f)
    PIECE-AT 0= ;

: )+ ( x,y,i,j -- x+i,y+j )
    ROT + -ROT + SWAP ;

