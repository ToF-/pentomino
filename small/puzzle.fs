\ puzzle.fs

REQUIRE display.fs

64 CONSTANT PUZZLE%

: EMPTY-PUZZLE ( puzzle -- )
    PUZZLE% ERASE ;

: PLACE-BLOCK ( c,xy,puzzle -- )
    SWAP XY 8 * + + C! ;

: BLOCK-AT ( puzzle,xy -- c )
    XY 8 * + + C@ ;

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
        

