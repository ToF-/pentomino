\ board.fs

REQUIRE coords.fs
REQUIRE pieces.fs

CREATE BOARD 64 ALLOT

: EMPTY-BOARD
    BOARD 64 ERASE ;

: PIECE-AT ( x,y -- n )
    8 * + BOARD + C@ ;

: PLACE-BLOCK ( p,xy -- )
    10 /MOD 8 * SWAP +
    BOARD + C! ;

: PLACE-SHAPE ( sh#,x,y -- )
    10 * + OVER NTH-SHAPE PIECE       \ sh#,xy,p
    2DUP SWAP PLACE-BLOCK            \ sh#,xy,p
    -ROT SWAP 4 0 DO                 \ p,xy,sh#
        2DUP I COORDS@ +             \ p,xy,sh#,ij
        2>R OVER 2R> ROT SWAP        \ p,xy,sh#,p,ij
        PLACE-BLOCK
    LOOP 2DROP DROP ;

: EMPTY-SQUARE? ( x,y -- f)
    PIECE-AT 0= ;

: )+ ( x,y,i,j -- x+i,y+j )
    ROT + -ROT + SWAP ;

