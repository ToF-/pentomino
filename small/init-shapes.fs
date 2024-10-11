\ init-shapes.fs

5 CONSTANT PIECE-LENGTH
25 CONSTANT PIECE-AREA
CHAR # CONSTANT PIECE-BLOCK
CHAR . CONSTANT PIECE-EMPTY

: SHAPE ( n <name> -- )
    CREATE DUP C, PIECE-AREA * ALLOT ;

: POSITION-MAX ( piece -- n )
    C@ ;

: POSITION ( piece,n -- addr )
    PIECE-AREA * SWAP 1+ + ;

: COORDS ( addr -- x4,y4,x3,y3,x2,y2,x1,y1,x0,y0 )
    PIECE-AREA 1-
    PIECE-AREA 0 DO
       OVER PIECE-AREA + I - 1-
       C@ PIECE-BLOCK = IF
           DUP PIECE-LENGTH /MOD 2SWAP
       THEN
        1-
    LOOP 2DROP ;

: FIRST-COORDS ( addr -- x,y )
    PIECE-AREA 0 DO
        DUP I + C@ PIECE-BLOCK = IF
            I PIECE-LENGTH /MOD
            LEAVE
        THEN
    LOOP ROT DROP ;

: TRANSLATE ( x0,y0,x1,y1 -- x0+x1,y0+y1 )
    ROT + -ROT + SWAP ;

: OPPOSE ( x,y -- -x,-y )
    NEGATE SWAP NEGATE SWAP ;

: WITHIN-PIECE-AREA? ( x,y -- f )
    0 PIECE-LENGTH WITHIN
    SWAP 0 PIECE-LENGTH WITHIN AND ;

: COPY-SHAPE-TO-PAD ( addr )
    PAD PIECE-AREA CMOVE ;

: EMPTY-SHAPE ( addr )
    PIECE-AREA PIECE-EMPTY FILL ;

: CALIBRATE ( addr -- )
    DUP FIRST-COORDS OPPOSE ROT
    DUP COPY-SHAPE-TO-PAD
    DUP EMPTY-SHAPE
    PIECE-AREA 0 DO
        PAD I + C@ PIECE-BLOCK = IF
            -ROT 2DUP I PIECE-LENGTH /MOD
            TRANSLATE 2DUP WITHIN-PIECE-AREA? IF
                PIECE-LENGTH * +
                >R ROT DUP R> +
                PIECE-BLOCK SWAP C!
            ELSE
                2DROP
            THEN
        THEN
    LOOP DROP 2DROP ;

: | ( adr <cccccc|> -- adr+5 )
    [CHAR] | WORD
    COUNT >R OVER R> CMOVE
    PIECE-LENGTH + ;

: MODEL{ ( piece -- adr )
    DUP 0 POSITION ;

: COPY-POSITIONS ( piece -- )
    DUP POSITION-MAX 1 DO
        DUP 0 POSITION DUP CALIBRATE
        OVER I POSITION
        PIECE-AREA CMOVE
    LOOP DROP ;

: ROTATE ( addr -- )
    DUP COPY-SHAPE-TO-PAD
    PIECE-LENGTH 0 DO
        PIECE-LENGTH 0 DO
            PAD PIECE-LENGTH I * +
            PIECE-LENGTH J - 1- +
            C@ OVER C!
            1+
        LOOP
    LOOP DROP ;

: FLIP ( addr -- )
    DUP COPY-SHAPE-TO-PAD
    PIECE-LENGTH 0 DO
        PIECE-LENGTH 0 DO
            PAD PIECE-LENGTH J * +
            PIECE-LENGTH I - 1- +
            C@ OVER C!
            1+
        LOOP
    LOOP DROP ;

: }MODEL ( piece,addr -- )
    DROP DUP COPY-POSITIONS 
    DUP POSITION-MAX 8 = IF
        3 1 DO
            DUP I POSITION
            I 0 DO DUP ROTATE LOOP
            CALIBRATE
        LOOP
        DUP 4 POSITION 
        DUP FLIP CALIBRATE
        3 1 DO
            DUP I 4 + POSITION
            I 0 DO DUP ROTATE LOOP
            CALIBRATE
        LOOP
    THEN DROP ;

: .SHAPE ( addr -- )
    PIECE-AREA 0 DO
        DUP I + C@
        I PIECE-LENGTH /MOD AT-XY EMIT
    LOOP DROP ;

: .DEMO ( piece -- )
    DUP POSITION-MAX 0 DO
        DUP I POSITION .SHAPE KEY DROP
    LOOP DROP ;
    
