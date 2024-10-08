0 CONSTANT BEAM        \ #####

                       \    #
1 CONSTANT UPPERL      \ ####

                       \  #
2 CONSTANT LOWERT      \ ####

                       \   ##
3 CONSTANT SNAKE       \ ###

                       \ ###
4 CONSTANT BRIDGE      \ # #

                       \  ##
                       \  #
5 CONSTANT LOWERS      \ ##

                       \  ##
                       \ ##
6 CONSTANT BIRD        \  #

                       \ ###
                       \  #
7 CONSTANT UPPERT      \  #

                       \ #
                       \ #
8 CONSTANT CORNER      \ ###

                       \  #
                       \ ###
9 CONSTANT CROSS       \  #

                       \ #
                       \ ##
10 CONSTANT HOUSE      \ ##

                       \ ##
                       \  ##
11 CONSTANT STAIRS     \   #

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

: .DEMO ( addr )
    DUP C@ 0 DO
        DUP I POSITION FIRST-COORDS SWAP I 8 * 1 AT-XY . .
        DUP I POSITION I 8 * 10 .POSITION
        I 8 * 16 I + AT-XY 
        DUP I POSITION .COORDS,
    LOOP DROP ;

2 SHAPE BEAM-SHAPE
HERE
| #####|
|      |
|      |
|      |
|      |
ROTATE,

PAGE ." beam" BEAM-SHAPE .DEMO cr key drop
8 SHAPE UPPERL-SHAPE
HERE
| #    |
| #    |
| #    |
| ##   |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,
PAGE ." upperl" UPPERL-SHAPE .DEMO cr key drop

8 SHAPE LOWERT-SHAPE
HERE
| #    |
| ##   |
| #    |
| #    |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,
PAGE ." lowert" LOWERT-SHAPE .DEMO cr key drop

8 SHAPE SNAKE-SHAPE
HERE
|   ## |
| ###  |
|      |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,
PAGE ." snake" SNAKE-SHAPE .DEMO cr key drop

4 SHAPE BRIDGE-SHAPE
HERE
| ###  |
| # #  |
|      |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,
PAGE ." bridge" BRIDGE-SHAPE .DEMO cr key drop

4 SHAPE LOWERS-SHAPE
HERE
|  ##  |
|  #   |
| ##   |
|      |
|      |
HERE SWAP ROTATE,
HERE SWAP FLIP, ROTATE,
PAGE ." lowers" LOWERS-SHAPE .DEMO cr key drop

8 SHAPE BIRD-SHAPE
HERE
|  ##  |
| ##   |
|  #   |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,
PAGE ." bird" BIRD-SHAPE .DEMO cr key drop

4 SHAPE UPPERT-SHAPE
HERE
| ###  |
|  #   |
|  #   |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,
PAGE ." uppert" UPPERT-SHAPE .DEMO cr key drop

4 SHAPE CORNER-SHAPE
HERE
| ###  |
| #    |
| #    |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,
PAGE ." corner" CORNER-SHAPE .DEMO cr key drop

1 SHAPE CROSS-SHAPE
HERE
|  #   |
| ###  |
|  #   |
|      |
|      |
PAGE ." cross" CROSS-SHAPE .DEMO cr key drop

4 SHAPE HOUSE-SHAPE
HERE
| ##   |
| ###  |
| ###  |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,
PAGE ." house" HOUSE-SHAPE .DEMO cr key drop

4 SHAPE STAIRS-SHAPE
HERE
| ##   |
|  ##  |
|   #  |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,
PAGE ." stairs" STAIRS-SHAPE .DEMO cr key drop
BYE
