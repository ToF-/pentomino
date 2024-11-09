\ shape.fs

VARIABLE COL
VARIABLE ROW

CHAR | CONSTANT BAR
CHAR # CONSTANT SQUARE

: <<COORD! ( coords,n -- coords' )
    SWAP 4 LSHIFT OR ;

: | ( ccccc | coords -- coords' )
    BAR WORD
    COUNT OVER + SWAP DO
        I C@ SQUARE = IF
            COL @ <<COORD!
            ROW @ <<COORD!
        THEN
        1 COL +!
    LOOP
    COL OFF
    1 ROW +! ;

: SHAPE| ( ccccc | -- coords )
    COL OFF ROW OFF 0 | ;

CREATE SHAPE-COORDS 10 CELLS ALLOT

: NTH-COORDS@ ( n -- x,y )
    2* CELLS SHAPE-COORDS + 2@ SWAP ;

: NTH-COORDS! ( x,y,n -- )
    2* CELLS SHAPE-COORDS + 2! ;

: GET-SHAPE-COORDS ( n -- )
    5 0 DO
        DUP 5 I 1+ -
        8 * RSHIFT 255 AND
        DUP 15 AND SWAP 4 RSHIFT
        I NTH-COORDS!
    LOOP DROP ;

: ROTATE-COORD ( x,y -- -y,x )
    NEGATE SWAP ;

: MIN-COORDS ( -- x,y )
    5 5
    5 0 DO
        I NTH-COORDS@
        ROT MIN -ROT MIN SWAP
    LOOP ;

: CALIBRATE
    MIN-COORDS
    NEGATE SWAP NEGATE SWAP
    5 0 DO
        I NTH-COORDS@
        2OVER ROT + -ROT + SWAP
        I NTH-COORDS!
    LOOP 2DROP ;

: ROTATE-SHAPE-COORDS
    5 0 DO
        I NTH-COORDS@ ROTATE-COORD I NTH-COORDS!
    LOOP
    CALIBRATE ;

