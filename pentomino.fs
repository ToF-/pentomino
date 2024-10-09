\ pentomino.fs

REQUIRE shapes.fs

: SQUARE-FIT? ( puzzle,x,y -- f )
    DUP CHECK-COORDS >R
    8* + + C@ 0= R> AND ;
    
: CAN-FIT? ( puzzle,pos,x,y -- f )
;
