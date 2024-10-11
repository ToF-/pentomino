\ init-shapes.fs

5 CONSTANT PIECE-LENGTH
25 CONSTANT PIECE-AREA
CHAR # CONSTANT PIECE-BLOCK 

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
