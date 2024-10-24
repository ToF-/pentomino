\ coords.fs

\ each shape has 4 relative coords
\ eg UPPERI  : 1,2,3,4
\ eg HOUSE   : 10,11,20,21
\ Q: how to control a shape is fitting at a position ?
\ eg: UPPERI in 7,0
\ a) convert relative coords : 1,0 2,0 3,0 4,0
\ b) add to destination coords : 8,0, 9,0 3,0 4,0

: COORDS>XY ( co -- x,y )
      8 /MOD OVER 4 > IF SWAP 8 - SWAP 1+ THEN ;

: COORD-WITHIN? ( n -- f )
    0 8 WITHIN ;

: COORDS-WITHIN? ( x,y -- f )
    COORD-WITHIN?
    SWAP COORD-WITHIN? AND ;

: REL-COORDS-WITHIN? ( rc -- f )
    COORDS>XY COORDS-WITHIN? ;

: +XY ( i,j,x,y -- i+x,j+y )
    ROT + -ROT + SWAP ;

: COORDS+XY? ( rc,x,y -- i,j,1|0 )
    ROT COORDS>XY +XY 2DUP
    COORDS-WITHIN? DUP
    0= IF -ROT 2DROP THEN ;

VARIABLE RESULT

: RESULT!++ ( x,y -- )
    SWAP
    RESULT @ C!  1 RESULT +!
    RESULT @ C!  1 RESULT +! ;

2VARIABLE TARGET

: TARGET-XY ( -- x,y )
    TARGET 2@ ;

: SHAPE-XY? ( c0,c1,c2,c3,c4,x,y -- f )
    TARGET 2!  TRUE
    5 0 DO
        SWAP TARGET-XY COORDS+XY? IF
            2DROP TRUE
        ELSE
            FALSE
        THEN
        AND
    LOOP ;
