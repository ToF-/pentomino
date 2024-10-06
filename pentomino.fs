

: ROW-COL>COORD ( r,c -- ch )
    SWAP 4 LSHIFT OR ;

: COORD>ROW-COL ( ch -- r,c )
    DUP 4 RSHIFT SWAP 15 AND ;

: ), ( r,c -- )
    ROW-COL>COORD C, ;

128 CONSTANT POINT
: POINT,
    POINT C, 0 C, 0 C, 0 C, 0 C, ;

CREATE PIECES
POINT, POINT, POINT, POINT,
0 0 ),  0 1 ),  0 2 ),  0 3 ),  1 3 ),
0 0 ),  0 1 ),  1 0 ),  1 1 ),  2 1 ),
0 0 ),  1 0 ),  1 1 ),  1 2 ),  2 0 ),
0 1 ),  1 0 ),  1 1 ),  1 2 ),  2 1 ),
0 0 ),  0 2 ),  1 0 ),  1 1 ),  1 2 ),
0 0 ),  1 0 ),  2 0 ),  3 0 ),  4 0 ),
0 0 ),  1 0 ),  2 0 ),  2 1 ),  2 2 ),
0 0 ),  1 0 ),  1 1 ),  1 2 ),  2 2 ),
0 1 ),  1 0 ),  1 1 ),  1 2 ),  1 3 ),
0 1 ),  1 0 ),  1 1 ),  2 1 ),  2 2 ),
0 0 ),  1 0 ),  1 1 ),  2 1 ),  2 2 ),
0 0 ),  1 0 ),  1 1 ),  2 1 ),  2 1 ),

: NTH-PIECE ( n -- addr )
    5 * PIECES + ;

DEFER .(POINT)

: .(COORD) ( x,y -- )
    ." (" SWAP . ." ," . ." )" ;

: .(SHARP) ( x,y -- )
    AT-XY 35 EMIT ;

' .(SHARP) IS .(POINT) 

: .(PIECE) ( x,y,addr -- )
    DUP 5 + SWAP DO
        2DUP I C@ COORD>ROW-COL 
        ROT + -ROT +
        .(POINT)
    LOOP 2DROP ;

: .PIECE ( x,y,addr -- )
    DUP C@ 128 AND IF
        DROP .(POINT)
    ELSE
        .(PIECE)
    THEN ;

: DEMO
    16 0 DO
        PAGE I . CR
        25 25 I NTH-PIECE .PIECE
        CR CR CR
        KEY DROP
    LOOP ;

