\ piece.fs

REQUIRE shape.fs

CREATE SHAPES
63 CELLS ALLOT

: NTH-SHAPE ( n -- addr )
    CELLS SHAPES + ;

VARIABLE SHAPE^
SHAPES SHAPE^ !

: SHAPE, ( coords -- )
    SHAPE^ @ ! CELL SHAPE^ +! ;

: ROTATE-FLIP-ROTATE, ( n -- )
    DUP SHAPE,
    DUP DUP ROTATE SHAPE,
    FLIP DUP SHAPE,
    ROTATE SHAPE, ;

: 4-ROTATE, ( n -- )
    DUP SHAPE,
    ROTATE DUP SHAPE,
    ROTATE DUP SHAPE,
    ROTATE SHAPE, ;

: 8-ROTATE, ( n -- )
    DUP 4-ROTATE,
    FLIP 4-ROTATE, ;

: NEW-SHAPE, ( n -- )
    , SHAPE^ @ , NEW-SHAPE ;

CREATE PIECES
1 NEW-SHAPE,
| .#.|
| ###|
| .#.|
SHAPE,
2 NEW-SHAPE,
| #####|
DUP SHAPE,
ROTATE SHAPE,
4 NEW-SHAPE,
| .##|
| .#.|
| ##.| 
ROTATE-FLIP-ROTATE,
4 NEW-SHAPE,
| ###|
| .#.|
| .#.|
4-ROTATE,
4 NEW-SHAPE,
| ###|
| #.#|
4-ROTATE,
4 NEW-SHAPE,
| ###|
| #..|
| #..|
4-ROTATE,
4 NEW-SHAPE,
| .##|
| ##.|
| #..|
4-ROTATE,
8 NEW-SHAPE,
| #.|
| ##|
| #.|
| #.|
8-ROTATE,
8 NEW-SHAPE,
| #.|
| #.|
| #.|
| ##|
8-ROTATE,
8 NEW-SHAPE,
| .##|
| ##.|
| .#.|
8-ROTATE,
8 NEW-SHAPE,
| ###.|
| ..##|
8-ROTATE,
8 NEW-SHAPE,
| .#|
| ##|
| ##|
8-ROTATE,
PIECES 13 2* CELLS DUMP

KEY DROP

: .SHAPE 
    XYS 5 0 DO
        AT-XY [CHAR] # EMIT
    LOOP ;

: TEST
    63 0 DO
        I NTH-SHAPE @
        PAGE .SHAPE
        0 10 AT-XY I . CR
        KEY DROP
    LOOP ;

TEST
BYE




