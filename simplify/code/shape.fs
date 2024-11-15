\ shape.fs

CHAR | CONSTANT BAR CHAR # CONSTANT SQUARE
-16 CONSTANT EXPAND-MASK 15 CONSTANT VALUE-MASK
8 CONSTANT NEGATIVE-MASK 4 CONSTANT NIBBLE
7 CONSTANT MAX-NIBBLE 0 CONSTANT EMPTY-COORDS
5 CONSTANT NBCOORDS
VARIABLE COL VARIABLE ROW

: SHAPE<<N ( n,coords -- coords' )
    NIBBLE LSHIFT SWAP VALUE-MASK AND OR ;

: EXPAND ( b -- n )
    DUP NEGATIVE-MASK AND IF EXPAND-MASK OR THEN ;

: SHAPE<<XY ( x,y,coords -- coords' )
    SHAPE<<N SHAPE<<N ;

: ++! ( addr -- )
    1 SWAP +! ;

: | ( ccccc | coords -- coords' )
    BAR WORD
    COUNT OVER + SWAP DO
        I C@ SQUARE = IF
            COL @ ROW @ ROT SHAPE<<XY
        THEN
        COL ++!
    LOOP
    COL OFF
    ROW ++! ;

: NEW-SHAPE ( ccccc | -- coords )
    COL OFF ROW OFF EMPTY-COORDS ;

: SHAPE>>N  ( coords -- n,coord' )
    DUP VALUE-MASK AND EXPAND
    SWAP NIBBLE RSHIFT ;

: SHAPE>>XY ( coords -- x,y,coords' )
    SHAPE>>N SHAPE>>N ;

: XYS ( coords -- x0,y0..x4,y4 )
    NBCOORDS 0 DO SHAPE>>XY LOOP DROP ;

: XY-MIN ( x,y,i,j -- k,l )
    ROT MIN -ROT MIN SWAP ;

: MINIMUM-XY ( coords -- x,y )
    XYS MAX-NIBBLE MAX-NIBBLE NBCOORDS 0 DO XY-MIN LOOP ;

: XY-NEGATE ( x,y -- -x,-y )
    NEGATE SWAP NEGATE SWAP ;

: XY-ADD ( x,y,i,j -- x+i,y+j )
    ROT + -ROT + SWAP ;

: (TRANSLATE) ( coords,x,y -- coords' )
    ROW ! COL ! XYS
    EMPTY-COORDS NBCOORDS 0 DO
        -ROT COL @ ROW @ XY-ADD
        ROT SHAPE<<XY
    LOOP ;

: XY-ROTATE ( x,y -- y,-x )
    SWAP NEGATE ;

: XY-FLIP ( x,y -- -x,y )
    SWAP NEGATE SWAP ;

: (CALIBRATE) ( coords -- coords' )
    DUP MINIMUM-XY XY-NEGATE (TRANSLATE) ;

: ROTATE ( coords -- coords' )
    XYS EMPTY-COORDS NBCOORDS 0 DO
        -ROT XY-ROTATE
        ROT SHAPE<<XY
        LOOP
    (CALIBRATE) ;

: FLIP ( coords -- coords' )
    XYS EMPTY-COORDS NBCOORDS 0 DO
        -ROT XY-FLIP
        ROT SHAPE<<XY
    LOOP
    (CALIBRATE) ;

