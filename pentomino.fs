0 CONSTANT BEAM        \ #####

                       \    #
1 CONSTANT UPPER-L     \ ####

                       \  #
2 CONSTANT LOWER-T     \ ####

                       \   ##
3 CONSTANT SNAKE       \ ###

                       \ ###
4 CONSTANT BRIDGE      \ # #

                       \  ##
                       \  #
5 CONSTANT LOWER-S     \ ##

                       \  ##
                       \ ##
6 CONSTANT BIRD        \  #

                       \ ###
                       \  #
7 CONSTANT UPPER-T     \  #

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

5 CONSTANT SIZE-LENGTH 
SIZE-LENGTH DUP * CONSTANT SHAPE-AREA

: SHAPE ( npos -- <name> )
    CREATE
    DUP C, HERE
    SWAP SHAPE-AREA * DUP ALLOT
    ERASE ;

: POSITION ( adr,p -- adr )
    SHAPE-AREA * SWAP 1+ + ;

: | ( addr <ccccc|> )
    124 WORD
    COUNT OVER + SWAP
    DO I C@ C, LOOP ;


: ROTATE ( srce,dest )
    SIZE-LENGTH 0 DO
        SIZE-LENGTH 0 DO
            OVER J SIZE-LENGTH * I + + C@
            OVER SIZE-LENGTH I - 1- SIZE-LENGTH  * J + + C!
        LOOP
    LOOP
    2DROP ;

: FLIP-VERT ( srce,dest,n )
    SIZE-LENGTH 0 DO
        SIZE-LENGTH 0 DO
            OVER J SIZE-LENGTH * I + + C@
            OVER J SIZE-LENGTH * SIZE-LENGTH I - 1- + + C!
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
    SIZE-LENGTH 0 DO
        SIZE-LENGTH 0 DO
           DUP J SIZE-LENGTH * I + + C@
           2OVER I J ADD-COORDS AT-XY EMIT
        LOOP
    LOOP DROP ;

2 SHAPE BEAM-SHAPE
BEAM-SHAPE 0 POSITION 
| @#####|
|       |
|       |
|       |
|       |
BEAM-SHAPE 0 POSITION
BEAM-SHAPE 0 POSITION 50 DUMP bye
PAGE 0 0  .POSITION
BYE
BEAM-SHAPE DUP C@ .s SWAP 0 NTH-POSITION SWAP 0 0 .SHAPE

 \ BEAM 5 SHAPE BEAM-SHAPE-VERT
 \ | @    |
 \ | #    |
 \ | #    |
 \ | #    |
 \ | #    |
 \ BEAM 5 SHAPE BEAM-SHAPE-HORZ 25 ALLOT
 \ BEAM-SHAPE-VERT BEAM-SHAPE-HORZ 5 ROTATE
 \ 
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-L1
 \ | @   |
 \ | #   |
 \ | #   |
 \ | ##  |
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-L2 16 ALLOT
 \ L-LETTER-SHAPE-L1 L-LETTER-SHAPE-L2 4 ROTATE
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-L3 16 ALLOT
 \ L-LETTER-SHAPE-L2 L-LETTER-SHAPE-L3 4 ROTATE
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-L4 16 ALLOT
 \ L-LETTER-SHAPE-L3 L-LETTER-SHAPE-L4 4 ROTATE
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-R1 16 ALLOT
 \ L-LETTER-SHAPE-L1 L-LETTER-SHAPE-R1 4 FLIP-VERT
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-R2 16 ALLOT
 \ L-LETTER-SHAPE-R1 L-LETTER-SHAPE-R2 4 ROTATE
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-R3 16 ALLOT
 \ L-LETTER-SHAPE-R2 L-LETTER-SHAPE-R3 4 ROTATE
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-R4 16 ALLOT
 \ L-LETTER-SHAPE-R3 L-LETTER-SHAPE-R4 4 ROTATE
 \ 
 \ 
 \ L-LETTER-SHAPE-L1 0 0 .SHAPE 
 \ L-LETTER-SHAPE-L2 5 0 .SHAPE 
 \ L-LETTER-SHAPE-L3 10 0 .SHAPE 
 \ L-LETTER-SHAPE-L4 15 0 .SHAPE 
 \ L-LETTER-SHAPE-R1 0 5 .SHAPE 
 \ L-LETTER-SHAPE-R2 5 5 .SHAPE 
 \ L-LETTER-SHAPE-R3 10 5 .SHAPE 
 \ L-LETTER-SHAPE-R4 15 5 .SHAPE 
 \ 
 \ BYE
 \ BEAM 5 SHAPE BEAM-SHAPE-HORZ
 \ | @####|
 \ |      |
 \ |      |
 \ |      |
 \ |      |
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-L1
 \ | @   |
 \ | #   |
 \ | #   |
 \ | ##  |
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-L2
 \ |     |
 \ |     |
 \ |    #|
 \ | @###|
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-L3
 \ |   ##|
 \ |    #|
 \ |    #|
 \ |    @|
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-L4
 \ | @###|
 \ | #   |
 \ |     |
 \ |     |
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-R1
 \ |    #|
 \ |    #|
 \ |    #|
 \ |   @#|
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-R2
 \ | @###|
 \ |    #|
 \ |     |
 \ |     |
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-R3
 \ | @#  |
 \ | #   |
 \ | #   |
 \ | #   |
 \ L-LETTER 4 SHAPE L-LETTER-SHAPE-R4
 \ |     |
 \ |     |
 \ | @   |
 \ | ####|
 \ LOWER-T 4 SHAPE LOWER-T-SHAPE-L1
 \ | @   |
 \ | ##  |
 \ | #   |
 \ | #   |
 \ S-LETTER 4 SHAPE SNAKE-SHAPE
 \ | *   |
 \ | ##  |
 \ |  #  |
 \ |  #  |
 \ STAIRS 3 SHAPE STAIRS-SHAPE
 \ | *# |
 \ |  ##|
 \ |   #|
 \ S-LETTER 3 SHAPE S-LETTER-SHAPE
 \ | *# |
 \ |  # |
 \ |  ##|
 \ U-LETTER 3 SHAPE U-LETTER-SHAPE
 \ | * #|
 \ | ###|
 \ |    |
 \ BIRD 3 SHAPE BIRD-SHAPE
 \ | *# |
 \ |  ##|
 \ |  # |
 \ UPPER-T 3 SHAPE UPPER-T-SHAPE
 \ | *##|
 \ |  # |
 \ |  # |
 \ CROSS 3 SHAPE CROSS-SHAPE
 \ |  * |
 \ | ###|
 \ |  # |
 \ CORNER 3 SHAPE CORNER-SHAPE
 \ | *  |
 \ | #  |
 \ | ###|
 \ HOUSE 3 SHAPE HOUSE-SHAPE
 \ | *  |
 \ | ## |
 \ | ## |
 \ 
 \ 
 \ 
