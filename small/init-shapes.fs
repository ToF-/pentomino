\ init-shapes.fs

5 CONSTANT PIECE-LENGTH
25 CONSTANT PIECE-AREA
CHAR # CONSTANT PIECE-BLOCK
CHAR . CONSTANT PIECE-EMPTY

: SHAPE ( n <name> -- )
    CREATE C, ;

: | ( <cccccc|> -- )
    [CHAR] | WORD
    COUNT OVER + SWAP
    DO I C@ C, LOOP ;

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
