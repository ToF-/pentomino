\ puzzle.fs

REQUIRE coords.fs
REQUIRE shapes.fs

64 CONSTANT PUZZLE-LENGTH

: PUZZLE-XY@ ( puzzle,xy -- k )
    ASSERT( DUP CHECK-COORDS )
    COORDS 8 * + + C@ ;

: PUZZLE-XY! ( k,puzzle,xy -- )
    ASSERT( DUP CHECK-COORDS )
    COORDS 8 * + + C! ;

: PUZZLE-XY-FIT? ( puzzle,xy -- f )
    DUP CHECK-COORDS IF
        PUZZLE-XY@ 0=
    ELSE
        2DROP FALSE
    THEN  ;

: SHAPE-WITHIN? ( xy,shape -- f )
    0 -ROT
    DUP SHAPE-LENGTH + SWAP DO
        DUP I C@ TRANSLATE? IF
            DROP SWAP 1+ SWAP
        THEN
    LOOP DROP
    SHAPE-LENGTH = ;

: SHAPE-FIT? ( puzzle, xy, shape -- f )
    >R 0 -ROT R>
    DUP SHAPE-LENGTH + SWAP DO
        2DUP I C@ TRANSLATE
        PUZZLE-XY-FIT? IF
            ROT 1+ -ROT
        THEN
    LOOP 2DROP
    SHAPE-LENGTH = ;

: PUZZLE-SHAPE-FIT? ( puzzle, xy, shape -- f )
    2DUP SHAPE-WITHIN? IF
        SHAPE-FIT?
    ELSE
        2DROP DROP FALSE
    THEN ;

: 3DUP ( a,b,c -- a,b,c,a,b,c )
    DUP 2OVER ROT ;

: PUZZLE-PLACE-SHAPE ( k,puzzle,xy,shape -- )
    ASSERT( 3DUP PUZZLE-SHAPE-FIT? )
    DUP SHAPE-LENGTH + SWAP DO
        3DUP I C@ TRANSLATE
        PUZZLE-XY!
    LOOP DROP 2DROP ;

: .PUZZLE ( puz -- )
    8 0 DO
        8 0 DO
            DUP J I XY PUZZLE-XY@
            ?DUP IF 64 + ELSE 46 THEN
            J I AT-XY
            EMIT
        LOOP
    LOOP CR ;

: SOLVED? ( puzzle -- f )
    0 SWAP
    8 0 DO
        8 0 DO
            DUP J I XY PUZZLE-XY@ IF
                SWAP 1+ SWAP
            THEN
        LOOP
    LOOP
    DROP 60 >= ;
