\ shape.fs

CHAR | CONSTANT BAR
CHAR # CONSTANT SQUARE
HEX  FFFFFFFFFFFFFFF0 CONSTANT EXPAND-MASK
     000000000000000F CONSTANT VALUE-MASK

VARIABLE COL
VARIABLE ROW

: NEGATIVE? ( b -- f )
    8 AND ;

: SHAPE<<! ( n,coords -- coords' )
    4 LSHIFT SWAP VALUE-MASK AND OR ;

: EXPAND-SIGN ( n -- n )
    EXPAND-MASK AND ;

: EXPAND ( b -- n )
    DUP EXPAND-SIGN IF EXPAND-MASK OR THEN ;

: SHAPE>>@  ( coords -- n,coord' )
    DUP VALUE-MASK AND EXPAND
    SWAP 4 RSHIFT ;

: SHAPE>>XY ( coords -- x,y,coords' )
    SHAPE>>@ SHAPE>>@ ;

: SHAPE<<XY ( x,y,coords -- coords' )
    SHAPE<<! SHAPE<<! ;

: | ( ccccc | coords -- coords' )
    BAR WORD
    COUNT OVER + SWAP DO
        I C@ SQUARE = IF
            COL @ ROW @ ROT SHAPE<<XY
        THEN
        1 COL +!
    LOOP
    COL OFF
    1 ROW +! ;

: SHAPE| ( ccccc | -- coords )
    COL OFF ROW OFF 0 | ;

: EXTRACT ( coords -- x0,y0..x4,y4 )
    5 0 DO SHAPE>>XY LOOP DROP ;

: XY-MIN ( x,y,i,j -- k,l )
    ROT MIN -ROT MIN SWAP ;

: MINIMUM ( coords -- x,y )
    EXTRACT 7 7 5 0 DO XY-MIN LOOP ;

: XY-NEGATE ( x,y -- -x,-y )
    NEGATE SWAP NEGATE SWAP ;

: XY-ADD ( x,y,i,j -- x+i,y+j )
    ROT + -ROT + SWAP ;

: (TRANSLATE) ( coords,x,y -- coords' )
    2>R EXTRACT 0 2R> 5 0 DO
        2>R -ROT 2R@ XY-ADD SHAPE<<XY 2R>
    LOOP 2DROP ;

: XY-ROTATE ( x,y -- y,-x )
    SWAP NEGATE ;

: XY-FLIP ( x,y -- -x,y )
    SWAP NEGATE SWAP ;

: CALIBRATE ( coords -- coords' )
    DUP MINIMUM XY-NEGATE (TRANSLATE) ;

: ROTATE ( coords -- coords' )
    EXTRACT 0 5 0 DO -ROT XY-ROTATE SHAPE<<XY LOOP
    CALIBRATE ;

: FLIP ( coords -- coords' )
    EXTRACT 0 5 0 DO -ROT XY-FLIP SHAPE<<XY LOOP
    CALIBRATE ;

