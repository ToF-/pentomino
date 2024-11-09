\ shape.fs

VARIABLE COL
VARIABLE ROW

CHAR | CONSTANT BAR
CHAR # CONSTANT SQUARE

: <<XY! ( coords,x,y -- coords' )
    ROT 4 LSHIFT
    ROT OR
    4 LSHIFT OR ;

: | ( ccccc | coords -- coords' )
    BAR WORD
    COUNT OVER + SWAP DO
        I C@ SQUARE = IF
            COL @ ROW @ <<XY!
        THEN
        1 COL +!
    LOOP
    COL OFF
    1 ROW +! ;

: SHAPE| ( ccccc | -- coords )
    COL OFF ROW OFF 0 | ;

CREATE XYS 10 CELLS ALLOT

: #XY@ ( n -- x,y )
    2* CELLS XYS + 2@ SWAP ;

: #XY! ( x,y,n -- )
    2* CELLS XYS + 2! ;

: XYS! ( n -- )
    5 0 DO
        DUP 5 I 1+ -
        8 * RSHIFT 255 AND
        DUP 15 AND SWAP 4 RSHIFT
        I #XY!
    LOOP DROP ;

: ROTATE-XY ( x,y -- -y,x )
    NEGATE SWAP ;

: +XY ( x,y,i,j -- x+i,y+j )
    ROT + -ROT + SWAP ;

: MIN-XYS ( -- x,y )
    5 5
    5 0 DO
        I #XY@
        ROT MIN -ROT MIN SWAP
    LOOP ;

: NEGATE-XY ( x,y -- -x,-y )
    NEGATE SWAP NEGATE sWAP ;

: CALIBRATE
    MIN-XYS NEGATE-XY
    5 0 DO
        I #XY@ 2OVER +XY I #XY!
    LOOP 2DROP ;

: ROTATE-XYS
    5 0 DO
        I #XY@
        ROTATE-XY
        I #XY!
    LOOP
    CALIBRATE ;

