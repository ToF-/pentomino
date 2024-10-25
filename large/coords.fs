\ coords.fs

\ each shape has 4 relative coords
\ eg UPPERI  : 1,2,3,4
\ eg HOUSE   : 10,11,20,21
\ Q: how to control a shape is fitting at a position ?
\ eg: UPPERI in 7,0
\ a) convert relative coords : 1,0 2,0 3,0 4,0
\ b) add to destination coords : 8,0, 9,0 3,0 4,0

8 CONSTANT SIZE
10 CONSTANT XMAX
5 CONSTANT HALF

: -XY ( x,y -- -x,-y )
    NEGATE SWAP NEGATE SWAP ;

: XY-+ ( x,y -- 10-x,y+1 )
    SWAP 10 - SWAP 1+ ;

: COORDS>XY ( co -- x,y )
    DUP 0 < SWAP
    ABS XMAX /MOD
    OVER HALF > IF XY-+ THEN
    ROT IF -XY THEN ;

: COORD-WITHIN? ( n -- f )
    0 SIZE WITHIN ;

: COORDS-WITHIN? ( x,y -- f )
    COORD-WITHIN? SWAP
    COORD-WITHIN? AND ;

: +XY ( i,j,x,y -- i+x,j+y )
    ROT + -ROT + SWAP ;

: COORDS+XY ( rc,x,y -- i,j )
    ROT COORDS>XY +XY ;

: COORDS+XY? ( rc,x,y -- i,j,1|0 )
    COORDS+XY 2DUP
    COORDS-WITHIN? DUP
    0= IF -ROT 2DROP THEN ;


