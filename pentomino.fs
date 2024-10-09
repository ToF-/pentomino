\ pentomino.fs

REQUIRE coords.fs
REQUIRE shapes.fs
REQUIRE puzzle.fs

: CAN-FIT? ( puz,pos,xy -- f )
    >R TRUE -ROT R>
    OVER 5 + ROT DO                     \ 1,puz,xy
        2DUP I C@                       \ 1,puz,xy,puz,xy,ij
        TRANSLATE? IF                   \ 1,puz,xy,puz,lk
            PUZZLE-XY-FIT? IF           \ 1,puz,xy
            ELSE
                ROT DROP FALSE -ROT
                LEAVE
            THEN
        ELSE
            DROP ROT DROP FALSE -ROT
            LEAVE
        THEN
    LOOP
    2DROP ;

: PLACE ( puz,pos,xy -- f)
    OVER 5 + ROT DO
        2DUP I C@ TRANSLATE? IF
            PUZZLE-XY!
            -ROT NIP
        THEN
    LOOP DROP ;

: PLACE? ( puz,pos,xy -- puz',1| 0 )
    ROT DUP >R -ROT 2DUP R> -ROT
    CAN-FIT? IF
        PLACE TRUE
    ELSE
        2DROP DROP FALSE
    THEN ;

: .PUZZLE ( puz -- )
    8 0 DO
        8 0 DO
            J I AT-XY
            DUP J I XY
            PUZZLE-XY? IF 42 ELSE 46 THEN
            EMIT
        LOOP
    LOOP CR ;

