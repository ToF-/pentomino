5 CONSTANT SL
SL DUP * CONSTANT PIECE-AREA

: PIECE ( npos -- <name> )
    CREATE C, ;

: SHAPE ( shape,p -- adr )
    PIECE-AREA * SWAP 1+ + ;

: | ( addr <ccccc|> )
    124 WORD
    COUNT OVER + SWAP
    DO I C@ C, LOOP ;


\ 012   258
\ 345 → 147
\ 678   036

: ROTATE, ( srce -- )
    SL 0 DO
        SL 0 DO
            DUP SL I * +
            SL J - 1- +
            C@ C,
    LOOP LOOP DROP ;

\ 012   210
\ 345 → 543
\ 678   876

: FLIP, ( srce -- )
    SL 0 DO
        SL 0 DO
            DUP SL J * +
            SL I - 1- +
            C@ C,
    LOOP LOOP DROP ;

: FIRST-COORDS ( addr -- r,c )
    SL DUP * 0 DO
        DUP I + C@ 32 <> IF
            I SL / I SL MOD
            LEAVE
        THEN
    LOOP ROT DROP ;

: ADD-COORDS ( x,y,i,j -- x+i,y+j )
    ROT +
    -ROT +
    SWAP ;


VARIABLE PATTERN

: .SHAPE ( addr,x,y -- )
    ROT
    SL 0 DO
        SL 0 DO
           DUP J SL * I + + C@
           DUP 32 = IF DROP 46 THEN
           2OVER I J ADD-COORDS AT-XY EMIT
        LOOP
    LOOP 2DROP DROP ;

2VARIABLE ORIGIN

: .COORD, ( x,y -- )
    SWAP 3 .R 32 EMIT 3 .R 32 EMIT ." ), " ;

: .COORDS, ( addr -- )
    DUP FIRST-COORDS
    NEGATE SWAP NEGATE SWAP
    ORIGIN 2!
    SL 0 DO
        SL 0 DO
            DUP J SL * I + + C@
            32 <> IF
                J I ORIGIN 2@ ADD-COORDS
                .COORD,
            THEN
        LOOP
    LOOP DROP ;

: .\SHAPE ( addr -- )
    CR
    SL 0 DO
        92 EMIT 32 EMIT
        SL 0 DO
            DUP J SL * I + + C@
            32 = IF 46  ELSE 35 THEN EMIT
        LOOP CR
    LOOP DROP ;

: .PIECE ( addr, str,c  -- )
    ROT DUP C@ . ." PIECE " -ROT TYPE
    DUP 0 SHAPE .\SHAPE
    DUP C@
    0 DO
        DUP I SHAPE .COORDS, CR
    LOOP DROP ;
      

: .DEMO ( addr )
    DUP C@ 0 DO
        DUP I SHAPE FIRST-COORDS SWAP I 8 * 1 AT-XY . .
        DUP I SHAPE I 8 * 10 .SHAPE
        I 8 * 16 I + AT-XY
        DUP I SHAPE .COORDS,
    LOOP DROP ;


2 PIECE BEAM
HERE
| #####|
|      |
|      |
|      |
|      |
ROTATE,

8 PIECE UPPERL
HERE
| #    |
| #    |
| #    |
| ##   |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


8 PIECE LOWERT
HERE
| #    |
| ##   |
| #    |
| #    |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


8 PIECE SNAKE
HERE
|   ## |
| ###  |
|      |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


4 PIECE BRIDGE
HERE
| ###  |
| # #  |
|      |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


4 PIECE LOWERS
HERE
|  ##  |
|  #   |
| ##   |
|      |
|      |
HERE SWAP ROTATE,
HERE SWAP FLIP, ROTATE,


8 PIECE BIRD
HERE
|  ##  |
| ##   |
|  #   |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


4 PIECE UPPERT
HERE
| ###  |
|  #   |
|  #   |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


4 PIECE CORNER
HERE
| ###  |
| #    |
| #    |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


1 PIECE CROSS
HERE
|  #   |
| ###  |
|  #   |
|      |
|      |


4 PIECE HOUSE
HERE
| ##   |
| ###  |
| ###  |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


4 PIECE STAIRS
HERE
| ##   |
|  ##  |
|   #  |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,

." \ shapes.fs" CR CR
." 5 CONSTANT SHAPE-LENGTH" CR CR
." REQUIRE coords.fs" CR CR
." : PIECE ( n -- )" CR
."     CREATE C, ; " CR CR
." : SHAPE ( shape,n -- adr )" CR
."     SHAPE-LENGTH * 1+ + ;" CR CR
BEAM   S" BEAM"   .PIECE CR
UPPERL S" UPPERL" .PIECE CR
LOWERT S" LOWERT" .PIECE CR
SNAKE  S" SNAKE " .PIECE CR
BRIDGE S" BRIDGE" .PIECE CR
LOWERS S" LOWERS" .PIECE CR
BIRD   S" BIRD  " .PIECE CR
UPPERT S" UPPERT" .PIECE CR
CORNER S" CORNER" .PIECE CR
CROSS  S" CROSS " .PIECE CR
HOUSE  S" HOUSE " .PIECE CR
STAIRS S" STAIRS" .PIECE CR
." CREATE PIECES" CR
." BEAM   ," CR
." UPPERL ," CR
." LOWERT ," CR
." SNAKE  ," CR
." BRIDGE ," CR
." LOWERS ," CR
." BIRD   ," CR
." UPPERT ," CR
." CORNER ," CR
." CROSS  ," CR
." HOUSE  ," CR
." STAIRS ," CR
." 12 CONSTANT MAX-PIECES" CR
BYE
