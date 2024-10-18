\ board.fs

0 CONSTANT EMPTY-BOARD

: BOARD<XY! ( bd,x,y -- bd' )
    8 * + 1 SWAP LSHIFT OR ;

\ 00 01 02  → 40
\ 08          48
\             56 57

: BOARD>XY ( board,n -- x,y,f )
    DUP 1 SWAP LSHIFT ROT AND IF
        8 /MOD TRUE
    ELSE
        -1 -1 FALSE
    THEN ;

: SQUARE-ROTATE ( x,y -- y,7-x )
    SWAP 7 SWAP - ;

: SQUARE-FLIP ( x,y -- 7-x,y )
    SWAP 7 SWAP - SWAP ;

: .BOARD-COORDS ( bd -- )
    64 0 DO
        1 I LSHIFT OVER AND IF
            I 8 /MOD SWAP ." (" 0 .R ." ," 0 .R ." ) "
        THEN
    LOOP DROP ;

: BOARD-ROTATE ( bd -- bd' )
    EMPTY-BOARD SWAP
    64 0 DO
        DUP I BOARD>XY IF
            SQUARE-ROTATE
            2>R SWAP 2R>
            BOARD<XY!
            SWAP
        ELSE
            2DROP DROP
        THEN
    LOOP DROP ;

: BOARD-FLIP ( bd -- bd' )
    EMPTY-BOARD SWAP
    64 0 DO
        DUP I BOARD>XY IF
            SQUARE-FLIP
            2>R SWAP 2R>
            BOARD<XY!
            SWAP
        ELSE
            2DROP DROP
        THEN
    LOOP DROP ;
