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
    DUP 2DUP
    SHAPE,
    ROTATE SHAPE,
    FLIP SHAPE,
    FLIP ROTATE SHAPE, ;

: 4-ROTATE, ( n -- )
    DUP 2DUP
    SHAPE,
    ROTATE SHAPE,
    ROTATE ROTATE SHAPE,
    ROTATE ROTATE ROTATE SHAPE, ;

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
| #.|
| ##|
| ##|
8-ROTATE,

: NTH-PIECE ( n -- addr )
    2* CELLS PIECES + ;


