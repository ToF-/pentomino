: ), ( r,c -- )
    15 AND SWAP
    15 AND 4 LSHIFT
    OR C, ;

: POINT,
    5 0 DO 0 0 ), LOOP ;

\ categories of pieces
\ the puzzle can contain only 1 piece per category

  1 CONSTANT POINT-1   \ #
  2 CONSTANT POINT-2   \ #
  3 CONSTANT POINT-3   \ #
  4 CONSTANT POINT-4   \ #
  5 CONSTANT I-LETTER  \ #####

                       \    #
  6 CONSTANT L-LETTER  \ ####

                       \   #
  7 CONSTANT LOWER-T   \ ####

                       \   #
                       \ ###
  8 CONSTANT S-LETTER  \ #

                       \   ##
 9 CONSTANT SNAKE      \ ###

                       \ # #
 10 CONSTANT U-LETTER  \ ###

                       \  ##
                       \ ##
 11 CONSTANT BIRD      \  #

                       \ ###
                       \  #
12 CONSTANT UPPER-T    \  #

                       \ ##
                       \  ##
13 CONSTANT STAIRS     \   #

                       \  #
                       \ ###
14 CONSTANT CROSS      \  #


                       \ #
                       \ #
15 CONSTANT CORNER     \ ###

                       \ #
                       \ ##
16 CONSTANT HOUSE      \ ##

DECIMAL
CREATE SHAPES
HERE
POINT-1 C,  POINT,
POINT-2 C,  POINT,
POINT-3 C,  POINT,
POINT-4 C,  POINT,
I-LETTER C, 0 0 ), 0 1 ), 0 2 ), 0 3 ), 0 4 ),              \ #####

I-LETTER C, 0 0 ), 1 0 ), 2 0 ), 3 0 ), 4 0 ),              \ #
                                                            \ #
                                                            \ #
                                                            \ #
                                                            \ #

L-LETTER C,  0  0 ),  0  1 ),  0  2 ),  0  3 ), -1  3 ),    \    #
                                                            \ ####

L-LETTER C,  0  0 ),   1 0 ),  2  0 ),  3  0 ),  3  1 ),    \ #
                                                            \ #
                                                            \ #
                                                            \ ##

L-LETTER C,  0  0 ),  0  1 ),  0  2 ),  0  3 ),  1  0 ),    \ ####
                                                            \ #

L-LETTER C,  0  0 ),  0  1 ),  1  1 ),  2  1 ),  3  1 ),    \ ##
                                                            \  #
                                                            \  #
                                                            \  #

L-LETTER C,  0  0 ),  0  1 ),  0  2 ),  0  3 ),  1  3 ),    \ ####
                                                            \    #

L-LETTER C,  0  0 ),  1  0 ),  2  0 ),  3  0 ),  3 -1 ),    \  #
                                                            \  #
                                                            \  #
                                                            \ ##

L-LETTER C,  0  0 ),  1  0 ),  1  1 ),  1  2 ),  1  3 ),   \ #
                                                           \ ####

L-LETTER C,  0  0 ),  0  1 ),  1  0 ),  2  0 ),  3  0 ),   \ ##
                                                           \ #
                                                           \ #
                                                           \ #

HERE SWAP - 6 / CONSTANT MAX-SHAPE
: NTH-SHAPE ( n -- addr )
    6 * SHAPES + ;

HEX FFFFFFFFFFFFFFF0 CONSTANT NEG-MASK DECIMAL
: NIBBLE>COORD ( b -- n )
    15 AND DUP 8 AND IF NEG-MASK OR THEN ;

: BYTE>XY ( b -- x,y )
    DUP   NIBBLE>COORD
    SWAP  4 RSHIFT NIBBLE>COORD ;

: .BLOCK ( c,x,y -- )
AT-XY EMIT ;

: ADD-COORDS ( x,y,r,c -- x+c,y+r )
    -ROT + -ROT + SWAP ;

: .SHAPE ( x,y,c,addr -- )
    1+ DUP 5 + SWAP DO
        I C@
        2OVER
        ROT BYTE>XY
        ADD-COORDS
        ROT DUP
        2SWAP .BLOCK
    LOOP
    DROP 2DROP ;

: DEMO 
    MAX-SHAPE 0 DO PAGE I . 10 10 64 I NTH-SHAPE DUP C@ ROT + SWAP .SHAPE CR KEY DROP LOOP ;

