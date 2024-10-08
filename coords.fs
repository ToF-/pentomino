\ coords.fs

: XY>COORDS ( x,y -- c )
   15 AND
   SWAP 15 AND
   4 LSHIFT OR ;

HEX FFFFFFFFFFFFFFF0 CONSTANT NEGMASK DECIMAL
: COORD ( nibble -- n )
    DUP 8 AND IF NEGMASK OR THEN ;

: COORDS>XY ( c -- x,y )
    DUP 4 RSHIFT 15 AND COORD
    SWAP 15 AND COORD ;

: ), ( r,c -- )
    XY>COORDS C, ;

: TRANSLATE-COORDS ( x,y,c-- x+cx,y+cy )
    COORDS>XY
    ROT + -ROT + SWAP ;

: CHECK-COORDS ( x,y -- f )
    0 8 WITHIN SWAP
    0 8 WITHIN AND ;
