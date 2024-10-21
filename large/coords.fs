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
    RESULT @ C!
    1 RESULT +!
    RESULT @ C! 
    1 RESULT +! ;

: SHAPE+XY? ( 0,a,b,c,d,x,y -- x0,y0 … x4,y4,1 | 0 )
    PAD RESULT !
    TRUE -ROT
    5 0 DO                    \ 0,a,b,c,d,f,x,y
        2SWAP 2OVER           \ 0,a,b,c,x,y,d,f,x,y
        ROT IF                \ 0,a,b,c,x,y,d,x,y
            COORDS+XY? IF     \ 0,a,b,c,x,y,i,j,f
                RESULT!++
                TRUE          \ 0,a,b,c,x,y,f
            ELSE
                FALSE         \ 0,a,b,c,x,y,f
            THEN
            -ROT              \ 0,a,b,c,f,x,y
        THEN
    LOOP
    IF 10 0 DO PAD I + C@ LOOP TRUE ELSE FALSE THEN ;



    
