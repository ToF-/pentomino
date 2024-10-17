\ pieces.fs

REQUIRE coords.fs

CHAR # CONSTANT SHARP
CHAR . CONSTANT POINT
2 5 * CONSTANT COORDS%

: PIECE ( <name> color,orient -- )
    CREATE
    C, DUP C,
    COORDS% * ALLOT ;

: COLOR ( piece -- color )
    C@ ;

: ORIENT-MAX ( piece -- n )
    1+ C@ ;

: COORDS ( piece, n -- offset )
    COORDS% * 2 + + ;

: ACQUIRE ( <cccc|> -- end,start )
    [CHAR] | WORD COUNT
    OVER + SWAP ;

: | ( <cccc|> addr,y,x -- addr',y',x' )
    ACQUIRE DO
        I C@ SHARP = IF
            2>R DUP 2R@ SWAP ROT )!
            2 + 2R>
        THEN
        1+
    LOOP
    DROP 1+ 0 ;


: ;SHAPE ( piece,y,x,addr -- )
    DROP 2DROP
    0 COORDS COORDS% ))CENTER ;

: SHAPE| ( <cccc|> piece -- piece )
    DUP 0 COORDS 0 0 | ;

: >COORDS ( piece,n,m -- )
    ROT DUP 2SWAP
    -ROT COORDS -ROT COORDS
    COORDS% CMOVE ;

: >ROTATE ( piece,n,m -- )
    ROT DUP 2SWAP DUP >R
    >COORDS
    R> COORDS DUP COORDS% ))ROTATE
    COORDS% ))CENTER ;

: >>ROTATE ( piece,n -- )
    DUP 1+ >ROTATE ;

: >FLIP ( piece,n,m -- )
    ROT DUP 2SWAP DUP >R
    >COORDS
    R> COORDS DUP COORDS% ))FLIP
    COORDS% ))CENTER ;

: )WITHIN? ( x,y -- f )
   0 8 WITHIN SWAP 0 8 WITHIN AND ;

: ))WITHIN? ( piece,n,i,j -- f )
    2SWAP COORDS >R TRUE -ROT R>
    DUP COORDS% + SWAP DO
        I )@ 2OVER )+ )WITHIN?
        >R ROT R> AND -ROT
    2 +LOOP 2DROP ;

1 1 PIECE CROSS
CROSS SHAPE| .#.|
           | ###|
           | .#.| ;SHAPE

2 2 PIECE UPPERI
UPPERI SHAPE| #####| ;SHAPE
UPPERI 0 >>ROTATE

4 3 PIECE BRIDGE
BRIDGE SHAPE| ###|
            | #.#| ;SHAPE
BRIDGE DUP 0 >>ROTATE DUP 1 >>ROTATE 2 >>ROTATE

4 4 PIECE CORNER
CORNER SHAPE| ###|
            | #..|
            | #..| ;SHAPE
CORNER DUP 0 >>ROTATE DUP 1 >>ROTATE 2 >>ROTATE

4 5 PIECE STAIRS
STAIRS SHAPE| .##|
            | ##.|
            | #..| ;SHAPE
STAIRS DUP 0 >>ROTATE DUP 1 >>ROTATE 2 >>ROTATE

4 6 PIECE UPPERT
UPPERT SHAPE| ###|
            | .#.|
            | .#.| ;SHAPE
UPPERT DUP 0 >>ROTATE DUP 1 >>ROTATE 2 >>ROTATE

4 7 PIECE LOWERS
LOWERS SHAPE| .##|
            | .#.|
            | ##.| ;SHAPE
LOWERS DUP 0 >>ROTATE DUP 0 2 >FLIP 2 >>ROTATE

8 8 PIECE LOWERT
LOWERT SHAPE| ####|
            | .#..| ;SHAPE
LOWERT DUP 0 >>ROTATE DUP 1 >>ROTATE DUP 2 >>ROTATE
DUP 0 4 >FLIP DUP 4 >>ROTATE DUP 5 >>ROTATE 6 >>ROTATE

8 9 PIECE UPPERL
UPPERL SHAPE| ####|
            | #...| ;SHAPE
UPPERL DUP 0 >>ROTATE DUP 1 >>ROTATE DUP 2 >>ROTATE
DUP 0 4 >FLIP DUP 4 >>ROTATE DUP 5 >>ROTATE 6 >>ROTATE

8 10 PIECE BIRD
BIRD SHAPE| .##|
          | ##.|
          | .#.| ;SHAPE
BIRD DUP 0 >>ROTATE DUP 1 >>ROTATE DUP 2 >>ROTATE
DUP 0 4 >FLIP DUP 4 >>ROTATE DUP 5 >>ROTATE 6 >>ROTATE

8 11 PIECE SNAKE
SNAKE SHAPE| ###.|
           | ..##| ;SHAPE
SNAKE DUP 0 >>ROTATE DUP 1 >>ROTATE DUP 2 >>ROTATE
DUP 0 4 >FLIP DUP 4 >>ROTATE DUP 5 >>ROTATE 6 >>ROTATE

8 12 PIECE HOUSE
HOUSE SHAPE| ###|
           | ##.| ;SHAPE
HOUSE DUP 0 >>ROTATE DUP 1 >>ROTATE DUP 2 >>ROTATE
DUP 0 4 >FLIP DUP 4 >>ROTATE DUP 5 >>ROTATE 6 >>ROTATE

CREATE PIECES
HERE
CROSS , UPPERI , BRIDGE , CORNER , STAIRS , UPPERT ,
LOWERS , LOWERT , UPPERL , BIRD , SNAKE , HOUSE ,
HERE SWAP - CELL / CONSTANT PIECE-MAX

: NTH-PIECE ( n -- piece )
    CELLS PIECES + @ ;

: PNO ( piece -- n )
    -1 SWAP
    PIECE-MAX 0 DO
        PIECES I CELLS + @ OVER = IF
            NIP I SWAP LEAVE
        THEN
    LOOP DROP ;
