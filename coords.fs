\ coords.fs

HEX FFFFFFFFFFFFFFF0 CONSTANT NEGMASK DECIMAL

: XY ( x,y -- xy )
    ASSERT( 2DUP -7 8 WITHIN SWAP -7 8 WITHIN AND ) 
    15 AND SWAP 15 AND
    4 LSHIFT OR ;

: EXPAND ( nibble -- n )
    DUP 8 AND IF NEGMASK OR THEN ;

: X-COORD ( xy -- x )
    4 RSHIFT 15 AND EXPAND ;

: Y-COORD ( xy -- y )
    15 AND EXPAND ;

: COORDS ( xy -- x,y )
    DUP X-COORD SWAP Y-COORD ;

: ), ( r,c -- )
    XY C, ;

: WITHIN? ( n -- f )
    0 8 WITHIN ;

: TRANSLATE? ( xy, ij -- kl,t | f )
    COORDS ROT COORDS   \ i,j,x,y
    ROT + -ROT + SWAP
    2DUP WITHIN? SWAP WITHIN? AND IF
        XY TRUE
    ELSE
        2DROP FALSE
    THEN ; 

: CHECK-COORDS ( xy -- f )
    COORDS
    0 8 WITHIN SWAP
    0 8 WITHIN AND ;
