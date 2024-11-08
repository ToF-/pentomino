\ shape.fs

VARIABLE COL
VARIABLE ROW

CHAR | CONSTANT BAR
CHAR # CONSTANT SQUARE

: <<COORD! ( coords,n -- coords' )
    SWAP 8 LSHIFT OR ;

: | ( ccccc | )
    BAR WORD
    COUNT OVER + SWAP DO
        I C@ SQUARE = IF
            COL @ <<COORD!
            ROW @ <<COORD!
        THEN
        1 COL +!
    LOOP
    1 ROW +!
    COL OFF ;

: SHAPE| ( ccccc | )
    COL OFF ROW OFF
    0 | ;





