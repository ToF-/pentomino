\ pentomino.fs

REQUIRE coords.fs
REQUIRE shapes.fs
REQUIRE puzzle.fs

: CAN-FIT? ( puz,pos,xy -- f )
    >R TRUE -ROT R>
    OVER 5 + ROT DO                     \ 1,puz,xy
        2DUP I C@                       \ 1,puz,xy,puz,xy,ij
        TRANSLATE-COORDS                \ 1,puz,xy,puz,pxy
        PUZZLE-XY-FIT? 0= IF
            ROT DROP FALSE -ROT LEAVE
        THEN
        SWAP
    LOOP
    2DROP ;

: PLACE ( puz,pos,xy -- f)
    OVER 5 + ROT DO
        2DUP I C@ TRANSLATE-COORDS
        PUZZLE-XY!
    LOOP 2DROP ;

: .PUZZLE ( puz -- )
    8 0 DO
        8 0 DO
            J I AT-XY
            DUP J I XY>COORDS
            PUZZLE-XY? IF 42 ELSE 46 THEN
            EMIT
        LOOP
    LOOP CR ;

