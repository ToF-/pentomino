\ puzzle.fs

REQUIRE coords.fs

: MASK ( n -- bits )
    1 SWAP LSHIFT ;

: PUZZLE-XY? ( puzzle,x,y -- b )
    ASSERT( 2DUP CHECK-COORDS )
    8 * + MASK AND ;

: PUZZLE-XY! ( puzzle,x,y -- )
    ASSERT( 2DUP CHECK-COORDS )
    8 * + MASK OR ;

: PUZZLE-XY-FIT? ( puzzle,x,y -- f )
    2DUP CHECK-COORDS IF
        PUZZLE-XY? 0=
    ELSE
        FALSE
    THEN ;
