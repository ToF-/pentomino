\ shape.fs
 4 CONSTANT NIBBLE
 15 CONSTANT VALUE-MASK

: SHAPE<<N ( n,coords -- coords' )
    NIBBLE LSHIFT SWAP VALUE-MASK AND OR ;

: SHAPE<<XY ( x,y,coords -- coords' )
    SHAPE<<N SHAPE<<N ;

0 CONSTANT EMPTY-COORDS
VARIABLE COL VARIABLE ROW
CHAR # CONSTANT SQUARE

: | ( ccccc | coords -- coords' )
    0 WORD
    COUNT OVER + SWAP DO
        I C@ SQUARE = IF
            COL @ ROW @ ROT SHAPE<<XY
        THEN
        1 COL +!
    LOOP
    COL OFF
    1 ROW +! ;

: NEW-SHAPE ( ccccc | -- coords )
    COL OFF ROW OFF EMPTY-COORDS ;

8 CONSTANT NEGATIVE-MASK
 -16 CONSTANT EXPAND-MASK

: EXPAND ( b -- n )
    DUP NEGATIVE-MASK AND IF EXPAND-MASK OR THEN ;

: SHAPE>>N  ( coords -- n,coord' )
    DUP VALUE-MASK AND EXPAND
    SWAP NIBBLE RSHIFT ;

: SHAPE>>XY ( coords -- x,y,coords' )
    SHAPE>>N SHAPE>>N ;

5 CONSTANT NBCOORDS

: XYS ( coords -- x0,y0..x4,y4 )
    NBCOORDS 0 DO SHAPE>>XY LOOP DROP ;

: XY-MIN ( x,y,i,j -- k,l )
    ROT MIN -ROT MIN SWAP ;

7 CONSTANT MAX-NIBBLE

: MINIMUM-XY ( coords -- x,y )
    XYS MAX-NIBBLE MAX-NIBBLE NBCOORDS 0 DO XY-MIN LOOP ;

: XY-NEGATE ( x,y -- -x,-y )
    NEGATE SWAP NEGATE SWAP ;

: XY-TRANSLATE ( x,y,i,j -- x+i,y+j )
    ROT + -ROT + SWAP ;

: (TRANSLATE) ( coords,x,y -- coords' )
    ROW ! COL ! XYS
    EMPTY-COORDS NBCOORDS 0 DO
        -ROT COL @ ROW @ XY-TRANSLATE
        ROT SHAPE<<XY
    LOOP ;

: XY-ROTATE ( x,y -- y,-x )
    SWAP NEGATE ;

: XY-FLIP ( x,y -- -x,y )
    SWAP NEGATE SWAP ;

: (SORT) ( coords -- coords' )
    XYS 0 5 0 DO
        -ROT 8 * + 1 SWAP LSHIFT OR
    LOOP
    EMPTY-COORDS
    63 0 DO
        OVER 1 I LSHIFT AND IF
            I 8 /MOD
            ROT SHAPE<<XY
        THEN
    LOOP NIP ;

: (CALIBRATE) ( coords -- coords' )
    DUP MINIMUM-XY XY-NEGATE (TRANSLATE) (SORT) ;

: ROTATE ( coords -- coords' )
    XYS EMPTY-COORDS NBCOORDS 0 DO
        -ROT XY-ROTATE
        ROT SHAPE<<XY
        LOOP (CALIBRATE) ;

: FLIP ( coords -- coords' )
    XYS EMPTY-COORDS NBCOORDS 0 DO
        -ROT XY-FLIP
        ROT SHAPE<<XY
    LOOP (CALIBRATE) ;

