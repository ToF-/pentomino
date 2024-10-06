  1 CONSTANT POINT-1   \ #
  2 CONSTANT POINT-2   \ #
  3 CONSTANT POINT-3   \ #
  4 CONSTANT POINT-4   \ #
  5 CONSTANT BEAM      \ #####

                       \    #
  6 CONSTANT L-LETTER  \ ####

                       \   #
  7 CONSTANT LOWER-T   \ ####

                       \   ##
 8 CONSTANT SNAKE      \ ###

                       \ ##
                       \  ##
 9 CONSTANT STAIRS     \   #

                       \   #
                       \ ###
 10 CONSTANT S-LETTER  \ #

                       \ # #
 11 CONSTANT U-LETTER  \ ###

                       \  ##
                       \ ##
 12 CONSTANT BIRD      \  #

                       \ ###
                       \  #
 13 CONSTANT UPPER-T   \  #

                       \  #
                       \ ###
 14 CONSTANT CROSS     \  #


                       \ #
                       \ #
 15 CONSTANT CORNER    \ ###

                       \ #
                       \ ##
 16 CONSTANT HOUSE     \ ##


: SHAPE ( k,n -- <name> )
    CREATE C, C, ;

: | ( addr <ccccc|> -- )
    124 WORD
    COUNT OVER + SWAP
    DO I C@ C, LOOP ;

\ 012
\ 345
\ 678
\ ←    →
\ 258  630
\ 147  741
\ 036  852

VARIABLE DIMENSION
: DIM ( -- n )
    DIMENSION @ ;

: ROTATE ( srce,dest,n )
    DIMENSION !
    2 + SWAP 2 + SWAP
    DIM 0 DO
        DIM 0 DO
            OVER J DIM * I + + C@
            OVER DIM I - 1- DIM  * J + + C!
        LOOP
    LOOP
    2DROP ;

: FLIP-VERT ( srce,dest,n )
    DIMENSION !
    2 + SWAP 2 + SWAP
    DIM 0 DO
        DIM 0 DO
            OVER J DIM * I + + C@
            OVER J DIM * DIM I - 1- + + C!
        LOOP
    LOOP
    2DROP ;

: ADD-COORDS ( x,y,i,j -- x+i,y+j )
    ROT +
    -ROT +
    SWAP ;

: .SHAPE ( addr,x,y -- )
    ROT DUP C@ DIMENSION !
    2 + DIM 0 DO
        DIM 0 DO
           DUP J DIM * I + + C@  \ x,y,addr,c
           2OVER I J ADD-COORDS AT-XY EMIT
        LOOP
    LOOP DROP ;
            

POINT-1 1 SHAPE POINT-1-SHAPE | @|
POINT-2 1 SHAPE POINT-2-SHAPE | @|
POINT-3 1 SHAPE POINT-3-SHAPE | @|
POINT-4 1 SHAPE POINT-4-SHAPE | @|

BEAM 5 SHAPE BEAM-SHAPE-VERT
| @    |
| #    |
| #    |
| #    |
| #    |
BEAM 5 SHAPE BEAM-SHAPE-HORZ 25 ALLOT
BEAM-SHAPE-VERT BEAM-SHAPE-HORZ 5 ROTATE

L-LETTER 4 SHAPE L-LETTER-SHAPE-L1
| @   |
| #   |
| #   |
| ##  |
L-LETTER 4 SHAPE L-LETTER-SHAPE-L2 16 ALLOT
L-LETTER-SHAPE-L1 L-LETTER-SHAPE-L2 4 ROTATE
L-LETTER 4 SHAPE L-LETTER-SHAPE-L3 16 ALLOT
L-LETTER-SHAPE-L2 L-LETTER-SHAPE-L3 4 ROTATE
L-LETTER 4 SHAPE L-LETTER-SHAPE-L4 16 ALLOT
L-LETTER-SHAPE-L3 L-LETTER-SHAPE-L4 4 ROTATE
L-LETTER 4 SHAPE L-LETTER-SHAPE-R1 16 ALLOT
L-LETTER-SHAPE-L1 L-LETTER-SHAPE-R1 4 FLIP-VERT
L-LETTER 4 SHAPE L-LETTER-SHAPE-R2 16 ALLOT
L-LETTER-SHAPE-R1 L-LETTER-SHAPE-R2 4 ROTATE
L-LETTER 4 SHAPE L-LETTER-SHAPE-R3 16 ALLOT
L-LETTER-SHAPE-R2 L-LETTER-SHAPE-R3 4 ROTATE
L-LETTER 4 SHAPE L-LETTER-SHAPE-R4 16 ALLOT
L-LETTER-SHAPE-R3 L-LETTER-SHAPE-R4 4 ROTATE


L-LETTER-SHAPE-L1 0 0 .SHAPE 
L-LETTER-SHAPE-L2 5 0 .SHAPE 
L-LETTER-SHAPE-L3 10 0 .SHAPE 
L-LETTER-SHAPE-L4 15 0 .SHAPE 
L-LETTER-SHAPE-R1 0 5 .SHAPE 
L-LETTER-SHAPE-R2 5 5 .SHAPE 
L-LETTER-SHAPE-R3 10 5 .SHAPE 
L-LETTER-SHAPE-R4 15 5 .SHAPE 

BYE
BEAM 5 SHAPE BEAM-SHAPE-HORZ
| @####|
|      |
|      |
|      |
|      |
L-LETTER 4 SHAPE L-LETTER-SHAPE-L1
| @   |
| #   |
| #   |
| ##  |
L-LETTER 4 SHAPE L-LETTER-SHAPE-L2
|     |
|     |
|    #|
| @###|
L-LETTER 4 SHAPE L-LETTER-SHAPE-L3
|   ##|
|    #|
|    #|
|    @|
L-LETTER 4 SHAPE L-LETTER-SHAPE-L4
| @###|
| #   |
|     |
|     |
L-LETTER 4 SHAPE L-LETTER-SHAPE-R1
|    #|
|    #|
|    #|
|   @#|
L-LETTER 4 SHAPE L-LETTER-SHAPE-R2
| @###|
|    #|
|     |
|     |
L-LETTER 4 SHAPE L-LETTER-SHAPE-R3
| @#  |
| #   |
| #   |
| #   |
L-LETTER 4 SHAPE L-LETTER-SHAPE-R4
|     |
|     |
| @   |
| ####|
LOWER-T 4 SHAPE LOWER-T-SHAPE-L1
| @   |
| ##  |
| #   |
| #   |
S-LETTER 4 SHAPE SNAKE-SHAPE
| *   |
| ##  |
|  #  |
|  #  |
STAIRS 3 SHAPE STAIRS-SHAPE
| *# |
|  ##|
|   #|
S-LETTER 3 SHAPE S-LETTER-SHAPE
| *# |
|  # |
|  ##|
U-LETTER 3 SHAPE U-LETTER-SHAPE
| * #|
| ###|
|    |
BIRD 3 SHAPE BIRD-SHAPE
| *# |
|  ##|
|  # |
UPPER-T 3 SHAPE UPPER-T-SHAPE
| *##|
|  # |
|  # |
CROSS 3 SHAPE CROSS-SHAPE
|  * |
| ###|
|  # |
CORNER 3 SHAPE CORNER-SHAPE
| *  |
| #  |
| ###|
HOUSE 3 SHAPE HOUSE-SHAPE
| *  |
| ## |
| ## |



