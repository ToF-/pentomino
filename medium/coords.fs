\ coords.fs

15 CONSTANT MAX-COORD

: EXPAND ( cn -- n )
    DUP 128 AND IF -256 OR THEN ;

: )@ ( addr -- x,y )
    DUP C@ EXPAND SWAP 1+ C@ EXPAND ;

: )! ( x,y,addr -- )
    ROT OVER C! 1+ C! ;

: )MIN ( x,y,i,j -- min x i, min y j )
    ROT MIN -ROT MIN SWAP ;

: ))MIN ( addr,count -- x,y )
    MAX-COORD MAX-COORD 2SWAP
    OVER + SWAP DO
        I )@ )MIN
    2 +LOOP ;

: )NEGATE ( x,y -- -x,-y )
    NEGATE SWAP NEGATE SWAP ;

: )+ ( x,y,i,j -- x+i,y+j )
    ROT + -ROT + SWAP ;

: ))+ ( x,y,addr,count -- )
    OVER + SWAP DO
        I )@ 2OVER )+ I )!
    2 +LOOP 2DROP ;

: )64 ( x,y -- y*8+x )
    8 * + ;

: ))CENTER ( addr, count -- )
    2DUP ))MIN )NEGATE 2SWAP
    OVER + SWAP DO
        I )@ 2OVER )+ I )!
    2 +LOOP
    2DROP ;

\ AB   BD
\ .D → A
: )ROTATE ( x,y -- y,-x )
    SWAP NEGATE ;

: ))ROTATE ( addr, count -- )
    OVER + SWAP DO
        I )@ )ROTATE I )!
    2 +LOOP ;

: )FLIP ( x,y -- x,-y )
    NEGATE ;

: ))FLIP ( addr, count -- )
    OVER + SWAP DO
        I )@ )FLIP I )!
    2 +LOOP ;

: )WITHIN? ( x,y -- f )
    0 8 WITHIN SWAP 0 8 WITHIN AND ;



