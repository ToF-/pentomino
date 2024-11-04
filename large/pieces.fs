\ pieces.fs

 1 CONSTANT CROSS
 2 CONSTANT UPPERI
 3 CONSTANT LOWERS
 4 CONSTANT UPPERT
 5 CONSTANT BRIDGE
 6 CONSTANT CORNER
 7 CONSTANT STAIRS
 8 CONSTANT LOWERT
 9 CONSTANT UPPERL
10 CONSTANT BIRD
11 CONSTANT SNAKE
12 CONSTANT HOUSE

\ encode a shape : category and orientation
: SHAPE, ( categ,number -- )
    SWAP 4 LSHIFT OR C, ;

\ encode shapes from 0 to max-1 for the category
: SHAPES, ( categ,max -- )
    0 DO DUP I SHAPE, LOOP DROP ;

\ table of all shapes [category,orientation]
CREATE SHAPES
    CROSS 0 SHAPE,
   UPPERI 2 SHAPES,
   LOWERS 4 SHAPES,
   UPPERT 4 SHAPES,
   BRIDGE 4 SHAPES,
   CORNER 4 SHAPES,
   STAIRS 4 SHAPES,
   LOWERT 8 SHAPES,
   UPPERL 8 SHAPES,
     BIRD 8 SHAPES,
    SNAKE 8 SHAPES,
    HOUSE 8 SHAPES,

\ shapes are indexed from 1 to 12
: NTH-SHAPE ( n -- sh )
    SHAPES 1- + C@ ;

: CATEGORY ( sh -- n )
    4 RSHIFT 15 AND ;

: ORIENTATION ( sh -- n )
    15 AND ;

HEX
FFFFFFFFFFFFFF00 CONSTANT EXPAND-MASK
00000000000000FF CONSTANT BYTE-MASK
DECIMAL

\ expand a byte to a number
: EXPAND ( c -- n )
    DUP 128 AND
    IF EXPAND-MASK OR THEN ;

10  CONSTANT LINE-WIDTH

VARIABLE ORIGIN
VARIABLE ORIGIN-SET

: SHAPE-LINE| ( cccccc| )
    [CHAR] | WORD
    0 SWAP COUNT OVER + SWAP DO
        I C@ [CHAR] # = IF
            ORIGIN-SET @ IF
                DUP ORIGIN @ + C,
            ELSE
                DUP NEGATE ORIGIN !
                ORIGIN-SET ON
            THEN
        THEN
        1+
    LOOP DROP
    LINE-WIDTH ORIGIN +! ;

: | ( ccccc| )
    SHAPE-LINE| ;

: SHAPE| ( cccccc| )
    ORIGIN OFF ORIGIN-SET OFF | ;
    
CREATE SHAPE-COORDS
    SHAPE| .#.|
         | ###|
         | .#.|

    SHAPE| #####|

    SHAPE| #|
         | #|
         | #|
         | #|
         | #|

    SHAPE| .##|
         | .#.|
         | ##.|

    SHAPE| #..|
         | ###|
         | ..#|

    SHAPE| ##.|
         | .#.|
         | .##|

    SHAPE| ..#|
         | ###|
         | #..|

    SHAPE| ###|
         | .#.|
         | .#.|

    SHAPE| #..|
         | ###|
         | #..|

    SHAPE| .#.|
         | .#.|
         | ###|

    SHAPE| ..#|
         | ###|
         | ..#|

    SHAPE| ###|
         | #.#|

    SHAPE| ##|
         | #.|
         | ##|

    SHAPE| #.#|
         | ###|

    SHAPE| ##|
         | .#|
         | ##|

    SHAPE| ###|
         | #..|
         | #..|

    SHAPE| #..|
         | #..|
         | ###|

    SHAPE| ..#|
         | ..#|
         | ###|

    SHAPE| ###|
         | ..#|
         | ..#|

    SHAPE| .##|
         | ##.|
         | #..|

    SHAPE| #..|
         | ##.|
         | .##|

    SHAPE| ..#|
         | .##|
         | ##.|

    SHAPE| ##.|
         | .##|
         | ..#|

    SHAPE| #.|
         | ##|
         | #.|
         | #.|

    SHAPE| .#..|
         | ####|

    SHAPE| .#|
         | .#|
         | ##|
         |  #|

    SHAPE| ####|
         | ..#.|

    SHAPE| .#|
         | ##|
         | .#|
         | .#|

    SHAPE| ####|
         | .#..|

    SHAPE| #.|
         | #.|
         | ##|
         | #.|

    SHAPE| ..#.|
         | ####|

    SHAPE| #.|
         | #.|
         | #.|
         | ##|

    SHAPE| ...#|
         | ####|

    SHAPE| ##|
         | .#|
         | .#|
         | .#|

    SHAPE| ####|
         | #...|

    SHAPE| .#|
         | .#|
         | .#|
         | ##|

    SHAPE| ####|
         | ...#|

    SHAPE| ##|
         | #.|
         | #.|
         | #.|

    SHAPE| #...|
         | ####|

    SHAPE| .##|
         | ##.|
         | .#.|

    SHAPE| #..|
         | ###|
         | .#.|

    SHAPE| .#.|
         | .##|
         | ##.|

    SHAPE| .#.|
         | ###|
         | ..#|

    SHAPE| ##.|
         | .##|
         | .#.|

    SHAPE| .#.|
         | ###|
         | #..|

    SHAPE| .#.|
         | ##.|
         | .##|

    SHAPE| ..#|
         | ###|
         | .#.|

    SHAPE| ###.|
         | ..##|

    SHAPE| .#|
         | ##|
         | #.|
         | #.|

    SHAPE| ##..|
         | .###|

    SHAPE| .#|
         | .#|
         | ##|
         | #.|

    SHAPE| .###|
         | ##..|

    SHAPE| #.|
         | #.|
         | ##|
         | .#|

    SHAPE| ..##|
         | ###.|

    SHAPE| #.|
         | ##|
         | .#|
         | .#|

    SHAPE| #.|
         | ##|
         | ##|

    SHAPE| .##|
         | ###|

    SHAPE| ##|
         | ##|
         | .#|

    SHAPE| ###|
         | ##.|

    SHAPE| .#|
         | ##|
         | ##|

    SHAPE| ###|
         | .##|

    SHAPE| ##|
         | ##|
         | #.|

    SHAPE| ##.|
         | ###|

4 CONSTANT COORDS-PER-SHAPE

\ coords address of nth shape
: NTH-COORDS ( n -- addr )
    1- COORDS-PER-SHAPE * SHAPE-COORDS + ;

\ coords of nth shape
: COORDS ( n -- c1,c2,c3,c4 )
    NTH-COORDS DUP COORDS-PER-SHAPE + SWAP
    DO I C@ EXPAND LOOP ;

