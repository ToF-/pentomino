\ board.fs

CREATE BOARD 64 ALLOT

: EMPTY-BOARD
    BOARD 64 ERASE ;

: PIECE-AT ( x,y -- n )
    8 * + BOARD + C@ ;

: PLACE-BLOCK ( p,xy -- )
    BOARD + C! ;

: PLACE-SHAPE ( sh#,x,y -- )
    8 * + OVER NTH-SHAPE PIECE       \ sh#,xy,p
    2DUP SWAP PLACE-BLOCK            \ sh#,xy,p
    -ROT SWAP 4 0 DO                 \ p,xy,sh#
        2DUP I COORDS@ +             \ p,xy,sh#,ij
        2>R OVER 2R> ROT SWAP        \ p,xy,sh#,p,ij
        PLACE-BLOCK
    LOOP 2DROP DROP ;

: EMPTY-SQUARE? ( x,y -- f)
    PIECE-AT 0= ;

: COORD-WITHIN? ( xy -- f )
    0 64 WITHIN ;

: CAN-FIT? ( sh#,x,y -- f )
    8 * + DUP COORD-WITHIN? IF
    ELSE
        2DROP FALSE
    THEN ;

