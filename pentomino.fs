5 CONSTANT SL 
SL DUP * CONSTANT SHAPE-AREA

: SHAPE ( npos -- <name> )
    CREATE C, ;

: POSITION ( shape,p -- adr )
    SHAPE-AREA * SWAP 1+ + ;

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

: .POSITION ( addr,x,y -- )
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

: .\POSITION ( addr -- )
    CR
    SL 0 DO
        92 EMIT 32 EMIT
        SL 0 DO
            DUP J SL * I + + C@
            32 = IF 46  ELSE 35 THEN EMIT
        LOOP CR
    LOOP DROP ;

: .SHAPE ( addr -- )
    32 EMIT
    DUP C@ . ." ,"
    DUP 0 POSITION .\POSITION
    DUP C@
    0 DO
        DUP I POSITION .COORDS, CR
    LOOP DROP ;
        

: .DEMO ( addr )
    DUP C@ 0 DO
        DUP I POSITION FIRST-COORDS SWAP I 8 * 1 AT-XY . .
        DUP I POSITION I 8 * 10 .POSITION
        I 8 * 16 I + AT-XY 
        DUP I POSITION .COORDS,
    LOOP DROP ;


2 SHAPE BEAM
HERE
| #####|
|      |
|      |
|      |
|      |
ROTATE,

8 SHAPE UPPERL
HERE
| #    |
| #    |
| #    |
| ##   |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


8 SHAPE LOWERT
HERE
| #    |
| ##   |
| #    |
| #    |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


8 SHAPE SNAKE
HERE
|   ## |
| ###  |
|      |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


4 SHAPE BRIDGE
HERE
| ###  |
| # #  |
|      |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


4 SHAPE LOWERS
HERE
|  ##  |
|  #   |
| ##   |
|      |
|      |
HERE SWAP ROTATE,
HERE SWAP FLIP, ROTATE,


8 SHAPE BIRD
HERE
|  ##  |
| ##   |
|  #   |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


4 SHAPE UPPERT
HERE
| ###  |
|  #   |
|  #   |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


4 SHAPE CORNER
HERE
| ###  |
| #    |
| #    |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


1 SHAPE CROSS
HERE
|  #   |
| ###  |
|  #   |
|      |
|      |


4 SHAPE HOUSE
HERE
| ##   |
| ###  |
| ###  |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,


4 SHAPE STAIRS
HERE
| ##   |
|  ##  |
|   #  |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,

." SHAPE BEAM" BEAM   .SHAPE
." SHAPE UPPERL" UPPERL .SHAPE
." SHAPE LOWERT" LOWERT .SHAPE
." SHAPE SNAKE " SNAKE  .SHAPE
." SHAPE BRIDGE" BRIDGE .SHAPE
." SHAPE LOWERS" LOWERS .SHAPE
." SHAPE BIRD  " BIRD   .SHAPE
." SHAPE UPPERT" UPPERT .SHAPE
." SHAPE CORNER" CORNER .SHAPE
." SHAPE CROSS " CROSS  .SHAPE
." SHAPE HOUSE " HOUSE  .SHAPE
." SHAPE STAIRS" STAIRS .SHAPE

BYE
