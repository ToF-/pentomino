\ puzzle.fs

REQUIRE coords.fs

: MASK ( n -- bits )
    1 SWAP LSHIFT ;

: PUZZLE-XY? ( puzzle,xy -- b )
    ASSERT( DUP CHECK-COORDS )
    COORDS 8 * + MASK AND ;

: PUZZLE-XY! ( puzzle,xy -- )
    ASSERT( DUP CHECK-COORDS )
    COORDS 8 * + MASK OR ;

: PUZZLE-XY-FIT? ( puzzle,xy -- f )
    DUP CHECK-COORDS IF
        PUZZLE-XY? 0=
    ELSE
        2DROP FALSE
    THEN  ;

: SOLVED? ( puzzle -- f )
    0 SWAP
    8 0 DO
        8 0 DO
            DUP J I XY PUZZLE-XY? IF
                SWAP 1+ SWAP
            THEN
        LOOP
    LOOP
    DROP 60 >= ;
