\ coords.fs

HEX FFFFFFFFFFFFFFF0 CONSTANT NEG-MASK DECIMAL 

: )C ( x,y -- coords )
    15 AND SWAP 15 AND 4 LSHIFT OR ;

: )C, ( x,y -- )
    )C C, ;

: EXPAND ( coord -> n )
    DUP 8 AND IF NEG-MASK OR THEN ;

: XY ( coords -- x,y )
    DUP 4 RSHIFT EXPAND
    SWAP 15 AND EXPAND ;

: )+ ( ab,cd -- a+c b+d )
    XY ROT XY ROT + -ROT + SWAP )C ;

: )NEGATE ( xy -- -x-y )
    XY NEGATE SWAP NEGATE SWAP )C ;

: )<0 ( xy -- f )
    DUP 8 AND SWAP 128 AND OR ;

: )MIN ( ab,cd -- min a c min bd )
    XY ROT XY ROT MIN -ROT MIN SWAP )C ;

: ))MIN ( addr,count -- coord )
    7 7 )C -ROT
    OVER + SWAP DO I C@ )MIN LOOP ;

: ))CENTER ( addr,count -- )
    2DUP ))MIN )NEGATE -ROT
    OVER + SWAP DO I C@ OVER )+ I C! LOOP
    DROP ;

\  3,1 → -1,3
: )ROTATE ( xy -- -yx )
    XY NEGATE SWAP )C ;

: ))ROTATE ( addr,count -- )
    2DUP
    OVER + SWAP DO I C@ )ROTATE I C! LOOP
    ))CENTER ;

\  3,1 → 3,-1
: )FLIP ( xy -- x-y )
    XY NEGATE )C ;

: ))FLIP ( addr,count -- )
    2DUP
    OVER + SWAP DO I C@ )FLIP I C! LOOP
    ))CENTER ;
