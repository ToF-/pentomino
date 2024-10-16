\ situation.fs

REQUIRE pieces.fs
REQUIRE display.fs

3 CELLS CONSTANT SITUATION%

512 CONSTANT PIECE-SET-MASK

64 8 * SITUATION% * CELL+ CONSTANT SITUATION-SET%

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

: SITUATION>KEY ( piece-no,orientation,x,y -- sh,sl )
    )64 SWAP 8 OR 6 LSHIFT OR
    SWAP DUP 6 < IF
        10 * LSHIFT 0 SWAP
    ELSE
        6 MOD 10 * LSHIFT 0
    THEN ;

: KEY>>PIECE-SITUATION ( situation -- orientation,x,y )
    DUP 63 AND 8 /MOD
    ROT 6 RSHIFT 7 AND -ROT ;


: SITUATION ( piece-no,orientation,x,y -- situation,board )
    2OVER 2OVER SITUATION>KEY 2ROT 2ROT
    2SWAP SWAP NTH-PIECE SWAP 2SWAP
    2OVER 2OVER ))WITHIN? IF
        SITUATION-BOARD
    ELSE
        2DROP 2DROP -1
    THEN ;

: SITUATION@ ( addr -- situ,ation,board )
    DUP CELL+ CELL+ SWAP 2@ ROT @ ;

: SITUATION! ( situ,ation,board,addr -- )
    DUP CELL+ CELL+ ROT SWAP ! 2! ;

: .BOARD ( board -- )
    8 0 DO 8 0 DO
        1 J 8 * I + LSHIFT
        OVER AND IF SHARP ELSE POINT THEN
        I J AT-XY EMIT
    LOOP LOOP DROP ;

2VARIABLE ORIGIN
: ORIGIN-XY ( x,y )
    ORIGIN 2@ ;

: .SITUATION ( sh,sl,b,x,y -- )
    ORIGIN ! DROP
    6 0 DO
        DUP PIECE-SET-MASK AND IF
            DUP KEY>>PIECE-SITUATION
            ROT I NTH-PIECE SWAP
            2SWAP ORIGIN-XY )+ .PIECE
        THEN
        10 RSHIFT
    LOOP
    DROP
    6 0 DO
        DUP PIECE-SET-MASK AND IF
            DUP KEY>>PIECE-SITUATION
            ROT I 6 + NTH-PIECE SWAP
            2SWAP ORIGIN-XY )+ .PIECE
        THEN
        10 RSHIFT
    LOOP
    2DROP ;


: SET-LIMITS ( set -- end,start )
    DUP @ SITUATION% * OVER CELL+ + SWAP CELL + ;

: .SITUATION-SET ( set -- )
    SET-LIMITS DO
        I SITUATION@ -ROT 2DROP .BOARD KEY DROP
    SITUATION% +LOOP ;

: SITUATION-SET ( piece -- )
    CREATE HERE 0 ,
    OVER PIECE-NUMBER
    ROT ORIENT-MAX 0 DO
        8 0 DO 8 0 DO
            DUP K I J SITUATION
            DUP -1 <> IF
               -ROT 2, ,
            ELSE
                DROP 2DROP
            THEN
        LOOP LOOP
    LOOP DROP
    HERE OVER CELL+ - SITUATION% / SWAP ! ;

: OR-SITUATION ( a,b,c,d,e,f -- a|d,b|e,c|f )
    -ROT 2SWAP OR >R
    ROT OR -ROT
    OR SWAP R> ;

2VARIABLE OUTER-LIMITS
2VARIABLE INNER-LIMITS

: UNION ( setA,setB,dest -- )
    DUP CELL+ 2SWAP
    SET-LIMITS OUTER-LIMITS 2!
    SET-LIMITS INNER-LIMITS 2!
    OUTER-LIMITS 2@ DO
        INNER-LIMITS 2@ DO
            I SITUATION@ -ROT 2DROP
            J SITUATION@ -ROT 2DROP
            AND 0= IF
                I SITUATION@
                J SITUATION@
                OR-SITUATION   \ dest,sh,sl,b
                2>R OVER 2R> ROT \ dest,sh,sl,b,dest
                SITUATION!
                SITUATION% +
                SWAP 1 OVER +! SWAP
            THEN
        SITUATION% +LOOP
    SITUATION% +LOOP
    2DROP ;

