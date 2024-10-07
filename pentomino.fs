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


: ROTATE ( srce,dest )
    SL 0 DO
        SL 0 DO
            OVER J SL * I + + C@
            OVER SL I - 1- SL  * J + + C!
        LOOP
    LOOP
    2DROP ;

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

: FLIP-VERT ( srce,dest,n )
    SL 0 DO
        SL 0 DO
            OVER J SL * I + + C@
            OVER J SL * SL I - 1- + + C!
        LOOP
    LOOP
    2DROP ;

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
           2OVER I J ADD-COORDS AT-XY EMIT
        LOOP
    LOOP 2DROP DROP ;

: .DEMO ( addr )
    DUP C@ 0 DO
        DUP I POSITION I 8 * 10 .POSITION
    LOOP DROP ;

2 SHAPE BEAM-SHAPE
HERE
| #####|
|      |
|      |
|      |
|      |
ROTATE,

page BEAM-SHAPE .DEMO cr key drop
8 SHAPE UPPERL-SHAPE
HERE
| #    |
| #    |
| #    |
| ##   |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,
page UPPERL-SHAPE .DEMO cr key drop

8 SHAPE LOWERT-SHAPE
HERE
| #    |
| ##   |
| #    |
| #    |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,
page LOWERT-SHAPE .DEMO cr key drop

8 SHAPE SNAKE-SHAPE
HERE
|   ## |
| ###  |
|      |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, HERE SWAP ROTATE,
HERE SWAP FLIP, HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,
page SNAKE-SHAPE .DEMO cr key drop

4 SHAPE BRIDGE-SHAPE
HERE
| ###  |
| # #  |
|      |
|      |
|      |
HERE SWAP ROTATE, HERE SWAP ROTATE, ROTATE,
page BRIDGE-SHAPE .DEMO cr key drop

4 SHAPE LOWERS-SHAPE
HERE
|  ##  |
|  #   |
| ##   |
|      |
|      |
HERE SWAP ROTATE,
HERE SWAP FLIP, ROTATE,
page LOWERS-SHAPE .DEMO cr key drop

BYE
