\ shape.fs

VARIABLE COL
VARIABLE ROW

CHAR | CONSTANT BAR
CHAR # CONSTANT SQUARE

: <<COORD! ( coords,n -- coords' )
    SWAP 8 LSHIFT OR ;

: | ( ccccc | coords -- coords' )
    BAR WORD
    COUNT OVER + SWAP DO
        I C@ SQUARE = IF
            COL @ <<COORD!
            ROW @ <<COORD!
        THEN
        1 COL +!
    LOOP
    COL OFF ;
    1 ROW +!

: SHAPE| ( ccccc | -- coords )
    COL OFF ROW OFF 0 | ;


