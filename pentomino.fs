: ), ( r,c -- )
    SWAP , ;

: POINT,
    5 0 DO 0 , 0 , LOOP ;

\ categories of pieces
\ the puzzle can contain only 1 piece per category

HEX
     1 CONSTANT POINT-1   \ #
     2 CONSTANT POINT-2   \ #
     4 CONSTANT POINT-3   \ #
     8 CONSTANT POINT-4   \ #
     10 CONSTANT I-LETTER  \ #####
                           \    #
     20 CONSTANT L-LETTER  \ ####
       
                           \   #
     40 CONSTANT LOWER-T   \ ####
    
                           \   #
                           \ ###
     80 CONSTANT S-LETTER  \ #
    
                           \   ##
    100 CONSTANT SNAKE     \ ###
   
                           \ # #
    200 CONSTANT U-LETTER  \ ###
   
                           \  ##
                           \ ##
    400 CONSTANT BIRD      \  #
    
                           \ ###
                           \  #
    800 CONSTANT UPPER-T   \  #
   
                           \ ##
                           \  ##
   1000 CONSTANT STAIRS    \   #

                           \  #
                           \ ###
   2000 CONSTANT CROSS     \  #


                           \ #
                           \ #
   4000 CONSTANT CORNER    \ ###

                           \ #
                           \ ##
   8000 CONSTANT HOUSE     \ ##

DECIMAL
CREATE SHAPES

POINT-1 ,  POINT,
POINT-2 ,  POINT,
POINT-3 ,  POINT,
POINT-4 ,  POINT,
I-LETTER , 0 0 ), 0 1 ), 0 2 ), 0 3 ), 0 4 ),              \ #####

I-LETTER , 0 0 ), 1 0 ), 2 0 ), 3 0 ), 4 0 ),              \ #
                                                           \ #
                                                           \ #
                                                           \ #
                                                           \ #

L-LETTER ,  0  0 ),  0  1 ),  0  2 ),  0  3 ), -1  3 ),    \    #
                                                           \ ####

L-LETTER ,  0  0 ),   1 0 ),  2  0 ),  3  0 ),  3  1 ),    \ #
                                                           \ #
                                                           \ #
                                                           \ ##

L-LETTER ,  0  0 ),  0  1 ),  0  2 ),  0  3 ),  1  0 ),    \ ####
                                                           \ #

L-LETTER ,  0  0 ),  0  1 ),  1  1 ),  2  1 ),  3  1 ),    \ ##
                                                           \  #
                                                           \  #
                                                           \  #

L-LETTER ,  0  0 ),  0  1 ),  0  2 ),  0  3 ),  1  3 ),    \ ####
                                                           \    #

I-LETTER ,  0  0 ),  1  0 ),  2  0 ),  3  0 ),  3 -1 ),    \  #
                                                           \  #
                                                           \  #
                                                           \ ##

I-LETTER ,  0  0 ),  1  0 ),  1  1 ),  1  2 ),  1  3 ),    \ #
                                                           \ ####

: NTH-SHAPE ( n -- addr )
    11 CELLS * SHAPES + ;

: .BLOCK ( x,y,c -- )
    \ -ROT AT-XY EMIT ;
    -ROT SWAP . . EMIT CR ;

: ADD-COORDS ( x,y,r,c -- x+c,y+r )
    -ROT + -ROT + SWAP ;

: .SHAPE ( x,y,c,addr -- )
    CELL+ DUP 10 CELLS + SWAP DO
        I 2@
        >R 2DUP ADD-COORDS
        R@ .BLOCK
        R>
        2 CELLS
    +LOOP
    DROP 2DROP ;

: DUMP-SHAPE
    11 CELLS * SHAPES + 11 CELLS DUMP ;

: DEMO
    5 0 DO I DUMP-SHAPE key drop cr LOOP ;

DEMO
    \ PAGE 10 10 42 5 NTH-SHAPE dbg .SHAPE 


