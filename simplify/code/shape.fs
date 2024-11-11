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

: XY-MIN ( x,y,i,j -- k,l )
    ROT MIN -ROT MIN SWAP ;

: MIN-COORDS ( coords -- x,y )
    7 7 ROT 5 0 DO
        COORD>>XY@ ROT >R
        XY-MIN R>
    LOOP DROP ;

: XY-NEGATE ( x,y -- -x,-y )
    NEGATE SWAP NEGATE SWAP ;

: XY-ADD ( x,y,i,j -- x+i,y+j )
    ROT + -ROT + SWAP ;

: CALIBRATE ( coords,x,y -- coords' )
    ROT 0 5 0 DO
        SWAP COORD>>XY@ 2>R SWAP
        2OVER 2R> XY-ADD COORD<<XY!
    LOOP NIP -ROT 2DROP ;

: XY-ROTATE ( x,y -- y,-x )
    SWAP NEGATE ;

: XY-FLIP ( x,y -- -x,y )
    SWAP NEGATE SWAP ;

: ROTATE ( coords -- coords' )
    0 5 0 DO
        SWAP COORD>>XY@ 2>R SWAP
        2R> XY-ROTATE COORD<<XY!
    LOOP NIP
    DUP MIN-COORDS XY-NEGATE CALIBRATE ;

: FLIP ( coords -- coords' )
    0 5 0 DO
        SWAP COORD>>XY@ 2>R SWAP
        2R> XY-FLIP COORD<<XY!
    LOOP NIP
    DUP MIN-COORDS XY-NEGATE CALIBRATE ;

