\ pieces.fs

 1 CONSTANT CROSS-SHAPES
 2 CONSTANT UPPERI-SHAPES
 3 CONSTANT LOWERS-SHAPES
 4 CONSTANT UPPERT-SHAPES
 5 CONSTANT BRIDGE-SHAPES
 6 CONSTANT CORNER-SHAPES
 7 CONSTANT STAIRS-SHAPES
 8 CONSTANT LOWERT-SHAPES
 9 CONSTANT UPPERL-SHAPES
10 CONSTANT BIRD-SHAPES
11 CONSTANT SNAKE-SHAPES
12 CONSTANT HOUSE-SHAPES

: SH ( categ,shape -- n )
    SWAP 4 LSHIFT OR ;

CREATE SHAPES
   CROSS-SHAPES 0 SH C,

   UPPERI-SHAPES 0 SH C, UPPERI-SHAPES 1 SH C,

   LOWERS-SHAPES 0 SH C, LOWERS-SHAPES 1 SH C, LOWERS-SHAPES 2 SH C, LOWERS-SHAPES 3 SH C,
   UPPERT-SHAPES 0 SH C, UPPERT-SHAPES 1 SH C, UPPERT-SHAPES 2 SH C, UPPERT-SHAPES 3 SH C,
   BRIDGE-SHAPES 0 SH C, BRIDGE-SHAPES 1 SH C, BRIDGE-SHAPES 2 SH C, BRIDGE-SHAPES 3 SH C,
   CORNER-SHAPES 0 SH C, CORNER-SHAPES 1 SH C, CORNER-SHAPES 2 SH C, CORNER-SHAPES 3 SH C,
   STAIRS-SHAPES 0 SH C, STAIRS-SHAPES 1 SH C, STAIRS-SHAPES 2 SH C, STAIRS-SHAPES 3 SH C,

   LOWERT-SHAPES 0 SH C, LOWERT-SHAPES 1 SH C, LOWERT-SHAPES 2 SH C, LOWERT-SHAPES 3 SH C,
   LOWERT-SHAPES 4 SH C, LOWERT-SHAPES 5 SH C, LOWERT-SHAPES 6 SH C, LOWERT-SHAPES 7 SH C,
   UPPERL-SHAPES 0 SH C, UPPERL-SHAPES 1 SH C, UPPERL-SHAPES 2 SH C, UPPERL-SHAPES 3 SH C,
   UPPERL-SHAPES 4 SH C, UPPERL-SHAPES 5 SH C, UPPERL-SHAPES 6 SH C, UPPERL-SHAPES 7 SH C,
     BIRD-SHAPES 0 SH C,   BIRD-SHAPES 1 SH C,   BIRD-SHAPES 2 SH C,   BIRD-SHAPES 3 SH C,
     BIRD-SHAPES 4 SH C,   BIRD-SHAPES 5 SH C,   BIRD-SHAPES 6 SH C,   BIRD-SHAPES 7 SH C,
    SNAKE-SHAPES 0 SH C,  SNAKE-SHAPES 1 SH C,  SNAKE-SHAPES 2 SH C,  SNAKE-SHAPES 3 SH C,
    SNAKE-SHAPES 4 SH C,  SNAKE-SHAPES 5 SH C,  SNAKE-SHAPES 6 SH C,  SNAKE-SHAPES 7 SH C,
    HOUSE-SHAPES 0 SH C,  HOUSE-SHAPES 1 SH C,  HOUSE-SHAPES 2 SH C,  HOUSE-SHAPES 3 SH C,
    HOUSE-SHAPES 4 SH C,  HOUSE-SHAPES 5 SH C,  HOUSE-SHAPES 6 SH C,  HOUSE-SHAPES 7 SH C,

: NTH-SHAPE ( n -- sh )
    SHAPES 1- + C@ ;

: PIECE ( sh -- n )
    4 RSHIFT 15 AND ;

: ORIENTATION ( sh -- n )
    15 AND ;

HEX
FFFFFFFFFFFFFF00 CONSTANT EXP-MASK
FF CONSTANT BYTE-MASK
DECIMAL

: EXPAND ( c -- n )
    DUP 128 AND IF EXP-MASK OR THEN ;

: ), ( n -- c )
    BYTE-MASK AND C, ;

: )@ ( addr -- c )
    C@ EXPAND ;

1000 CONSTANT UNKNOWN-MAX
UNKNOWN-MAX 15 - CONSTANT UNKNOWN-MIN

VARIABLE ORIGIN

: UNKNOWN-ORIGIN?
    ORIGIN @ UNKNOWN-MIN > ;

: UPDATE-ORIGIN
    UNKNOWN-ORIGIN? IF -1 ORIGIN +! THEN ;

: SET-ORIGIN
    -1000 ORIGIN +! ;

: | ( cccccc| )
    [CHAR] | WORD
    0 SWAP COUNT OVER + SWAP DO
        I C@ [CHAR] # = IF
            UNKNOWN-ORIGIN? IF
                SET-ORIGIN
            ELSE
                DUP ORIGIN @ + C,
            THEN
        THEN
        1+
        UPDATE-ORIGIN
    LOOP DROP
    10 ORIGIN +! ;

: SHAPE| ( cccccc| )
    UNKNOWN-MAX ORIGIN ! | ;
    
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
 
: COORDS ( n -- c1,c2,c3,c4 )
    1- 4 * SHAPE-COORDS + DUP 4 + SWAP DO I )@ LOOP ;

: COORDS@ ( n,i -- c )
    SWAP 1- 4 * SHAPE-COORDS + + )@ ;
    
