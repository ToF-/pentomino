\ display.fs

REQUIRE coords.fs
REQUIRE pieces.fs

CREATE COLOR-CODES
HERE
 0 C, 1 C, 2 C, 3 C, 4 C, 5 C, 6 C, 7 C,
 12 C, 24 C, 28 C, 99 C, 208 C, 213 C, 220 C, 193 C,
HERE SWAP - CONSTANT COLOR-MAX

: .COLOR-CODE ( n -- )
    ESC[ ." 38;5;" 0 .R ." m" ;

: .NORMAL
    ESC[ ." 0m" ;

: .COLOR ( c -- )
    COLOR-CODES + C@ .COLOR-CODE ;

: .COLORS-DEMO
    COLOR-MAX 0 DO I .COLOR I . I COLOR-CODES + C@ . CR LOOP ;

: .PIECE ( piece,orient,x,y -- )
    2OVER DROP COLOR .COLOR
    2SWAP COORDS DUP COORDS% + SWAP DO
        I )@ 2OVER )+ AT-XY SHARP EMIT
    2 +LOOP
    2DROP ;



