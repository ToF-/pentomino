\ situation.fs

REQUIRE pieces.fs
REQUIRE display.fs
REQUIRE bitfields.fs

0 CONSTANT EMPTY-BOARD

6 CONSTANT :SQUARE
3 CONSTANT :ORIENT
1 CONSTANT :PIECE-ON

: EMPTY-SITUATION ( -- kh,kl,bd )
    0.0 0 ;

: PIECE-INFO ( o,x,y -- p )
    )64 SWAP 8 OR 6 LSHIFT OR ;

: PIECE-KEY ( n,o,x,y -- key )
    PIECE-INFO SWAP 10 * LSHIFT ;

: PIECE-BOARD ( n,o,x,y -- board )
    2SWAP SWAP NTH-PIECE SWAP COORDS
    COORDS% OVER + SWAP
    2>R EMPTY-BOARD -ROT 2R> DO
        I )@ 2OVER )+
        )64 1 SWAP LSHIFT
        -ROT 2SWAP OR -ROT
    2 +LOOP 2DROP ;

: PIECE-SITUATION ( n,o,x,y -- kh,kl,bd )
    2OVER 2OVER PIECE-BOARD >R
    2SWAP OVER >R SWAP 6 MOD SWAP 2SWAP
    PIECE-KEY R> 5 > IF 0 ELSE 0 SWAP THEN R> ;

: MERGE-SITUATIONS ( kh0,kl0,bd0,kh1,kl1,bd1 -- kh,kl,bd )
    -ROT 2SWAP OR >R
    ROT OR -ROT OR SWAP R> ;

: FITTING? ( n,o,x,y -- f )
    2SWAP SWAP NTH-PIECE SWAP COORDS
    COORDS% OVER + SWAP
    2>R TRUE -ROT 2R> DO
        I )@ 2OVER )+ )WITHIN?
        -ROT 2SWAP AND -ROT
    2 +LOOP 2DROP ;

: MERGING? ( kh0,kl0,bd0,kh1,kl1,bd1 -- ? )
    -ROT 2SWAP AND 0= >R
    ROT AND 0= -ROT
    AND 0= AND R> AND ;

: NEW-SET ( <name> n -- exec: addr )
    CREATE 3 CELLS * CELL+ ALLOCATE ASSERT( 0= )
    DUP , 0 SWAP !
    DOES> @ ;

: SITUATIONS ( n -- n )
    3 CELLS * ;

3 CELLS CONSTANT SITUATION% 

: SITUATION! ( kh,kl,bd,addr )
    TUCK CELL+ CELL+ !
    TUCK CELL+ ! ! ;

: +SITUATION! ( kh,kl,bd,addr )
    DUP @ SITUATIONS OVER CELL+ + SWAP >R SITUATION! 1 R> +! ;

: SET-COUNT ( addr -- addr, count )
    DUP CELL+ SWAP @ ;


: PIECE-SITUATIONS ( < name> n -- exec: addr)
    4096 NEW-SET HERE CELL - @
    SWAP DUP NTH-PIECE ORIENT-MAX
    0 DO
        8 0 DO 8 0 DO
            2DUP K I J
            2OVER 2OVER FITTING? IF
                PIECE-SITUATION
                2SWAP -ROT
                k . i . j . .s cr key drop
                dup >r
                +SITUATION!
                r> set-count situations dump
            ELSE
                2DROP 2DROP
            THEN
        LOOP LOOP
    LOOP 2DROP ;

: SITUATION@ ( addr -- kh,kl,bd )
    DUP @ SWAP CELL+
    DUP @ SWAP CELL+
    @ ;



