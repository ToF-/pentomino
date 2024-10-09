\ pentomino.fs

REQUIRE coords.fs
REQUIRE shapes.fs
REQUIRE puzzle.fs

: CAN-FIT? ( puz,pos,xy -- f )
    >R TRUE -ROT R>
    OVER 5 + ROT DO                     \ 1,puz,xy
        2DUP I C@                       \ 1,puz,xy,puz,xy,ij
        TRANSLATE? IF PUZZLE-XY-FIT? IF
        ELSE
            ROT DROP FALSE -ROT
            LEAVE
        THEN THEN
    LOOP
    2DROP ;

: PLACE ( puz,pos,xy -- f)
    OVER 5 + ROT DO
        2DUP I C@ TRANSLATE? IF 
            PUZZLE-XY!
            -ROT NIP
        THEN
    LOOP DROP ;

: .PUZZLE ( puz -- )
    8 0 DO
        8 0 DO
            J I AT-XY
            DUP J I XY
            PUZZLE-XY? IF 42 ELSE 46 THEN
            EMIT
        LOOP
    LOOP CR ;

