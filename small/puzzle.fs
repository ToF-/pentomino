\ puzzle.fs

REQUIRE display.fs

64 CONSTANT PUZZLE%

: EMPTY-PUZZLE ( puzzle -- )
    PUZZLE% ERASE ;

: PLACE-BLOCK ( c,xy,puzzle -- )
    SWAP XY 8 * + + C! ;

: BLOCK-AT ( puzzle,xy -- c )
    XY 8 * + + C@ ;

: NEXT-FREE-CELL ( puzzle -- xy )
    0 SWAP
    DUP PUZZLE% + SWAP DO
        I C@ 0= IF
            8 /MOD )C
            LEAVE
        ELSE
            1+
        THEN
    LOOP ;

: FALSE-RESULT ( f,a,b -- 0,a,b )
    ROT DROP FALSE -ROT ;

: CAN-FIT ( shape,p,xy,puzzle -- f )
    2SWAP POS DUP COORDS% + SWAP
    2>R TRUE -ROT 2R> DO
        OVER I C@ )+ )<0 IF
            FALSE-RESULT
            LEAVE
        ELSE
            2DUP SWAP I C@ )+ BLOCK-AT IF
                FALSE-RESULT
                LEAVE
        THEN THEN
    LOOP 2DROP ;


: PLACE-SHAPE ( shape,p,xy,puzzle -- )
    2SWAP OVER COLOR -ROT POS
    DUP COORDS% + SWAP DO        \ xy,puzzle,c
        DUP 2OVER                \ xy,puzzle,c,c,xy,puzzle
        SWAP I C@ )+ SWAP        \ xy,puzzle,c,c,ij,puzzle
        PLACE-BLOCK
    LOOP
    DROP 2DROP ;

: .PUZZLE ( puzzle -- )
    8 0 DO
        8 0 DO
            DUP I J )C BLOCK-AT
            I J .BLOCK
        LOOP
    LOOP DROP
    .NORMAL ;
        

