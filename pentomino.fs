\ pentomino.fs

REQUIRE coords.fs
REQUIRE shapes.fs
REQUIRE puzzle.fs

: CAN-FIT? ( puz,pos,x,y -- f )
    2>R TRUE -ROT 2R>                   \ 1,puz,pos,x,y
    ROT DUP 5 + SWAP DO                 \ 1,puz,x,y,
        ROT DUP 2OVER                   \ 1,x,y,puz,puz,x,y
        I C@ -ROT TRANSLATE-COORDS      \ 1,x,y,puz,puz,px,py
        PUZZLE-XY-FIT? 0= IF            \ 1,x,y,puz
            ." leaving with " .s cr
            2>R >R DROP FALSE R> 2R>    \ 0,x,y,puz
            LEAVE
        THEN
        .s cr
        -ROT                            \ 1,puz,x,y
    LOOP
    2DROP DROP ;
