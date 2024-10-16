\ situation.fs

REQUIRE pieces.fs

0 CONSTANT EMPTY-BOARD

: SET-SQUARE ( board,n -- board' )
    1 SWAP LSHIFT OR ;

: SITUATION-BOARD ( piece,n,x,y -- board )
    2SWAP COORDS PAD COORDS% CMOVE
    PAD COORDS% ))+
    EMPTY-BOARD PAD COORDS% OVER + SWAP DO
        I )@ )64 SET-SQUARE
    2 +LOOP ;

8 CONSTANT PIECE-MASK

: SITUATION-KEY ( piece-no,orientation,x,y )
    )64 SWAP 8 OR 4 LSHIFT OR
    SWAP DUP 8 < IF
        8 * LSHIFT 0 SWAP
    ELSE
        8 MOD 8 * LSHIFT 0
    THEN ;

: SITUATION ( piece-no,orientation,x,y -- situation,board )
    2OVER 2OVER SITUATION-KEY 2ROT 2ROT
    2SWAP SWAP NTH-PIECE SWAP 2SWAP
    2OVER 2OVER ))WITHIN? IF
        SITUATION-BOARD
    ELSE
        2DROP 2DROP -1
    THEN ;
