\ shape.fs

VARIABLE COL
VARIABLE ROW

CHAR | CONSTANT BAR
CHAR # CONSTANT SQUARE
HEX  FFFFFFFFFFFFFFF0 CONSTANT EXPAND-MASK DECIMAL

: COORD! ( coords,n -- coords' )
    15 AND OR ;

: EXPAND-SIGN ( n -- n )
    EXPAND-MASK OR ;

: COORD@ ( coords -- n )
    15 AND
    DUP 8 AND IF EXPAND-SIGN THEN ;

: << ( coords -- coords' )
    4 LSHIFT ;

: >> ( coords -- coords' )
    4 RSHIFT ;

: COORD<<XY! ( coords,x,y -- coords' )
    ROT << ROT COORD! << SWAP COORD! ;

: COORD>>XY@ ( coords -- coords',x,y )
    DUP COORD@ SWAP >> DUP COORD@ SWAP >>
    -ROT SWAP ;

: | ( ccccc | coords -- coords' )
    BAR WORD
    COUNT OVER + SWAP DO
        I C@ SQUARE = IF
            COL @ ROW @ COORD<<XY!
        THEN
        1 COL +!
    LOOP
    COL OFF
    1 ROW +! ;

: SHAPE| ( ccccc | -- coords )
    COL OFF ROW OFF 0 | ;

: EXTRACT ( coords -- x0,y0..x4,y4 )
    5 0 DO COORD>>XY@ ROT LOOP DROP ;

: XY-MIN ( x,y,i,j -- k,l )
    ROT MIN -ROT MIN SWAP ;

: MIN-COORDS ( coords -- x,y )
    EXTRACT 7 7 5 0 DO XY-MIN LOOP ;

: XY-NEGATE ( x,y -- -x,-y )
    NEGATE SWAP NEGATE SWAP ;

: XY-ADD ( x,y,i,j -- x+i,y+j )
    ROT + -ROT + SWAP ;

: (TRANSLATE) ( coords,x,y -- coords' )
    2>R EXTRACT 0 2R> 5 0 DO
        2>R -ROT 2R@ XY-ADD COORD<<XY! 2R>
    LOOP 2DROP ;

: XY-ROTATE ( x,y -- y,-x )
    SWAP NEGATE ;

: XY-FLIP ( x,y -- -x,y )
    SWAP NEGATE SWAP ;

: CALIBRATE ( coords -- coords' )
    DUP MIN-COORDS XY-NEGATE (TRANSLATE) ;

: ROTATE ( coords -- coords' )
    EXTRACT 0 5 0 DO -ROT XY-ROTATE COORD<<XY! LOOP
    CALIBRATE ;

: FLIP ( coords -- coords' )
    EXTRACT 0 5 0 DO -ROT XY-FLIP COORD<<XY! LOOP
    CALIBRATE ;

