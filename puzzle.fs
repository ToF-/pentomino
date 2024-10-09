\ puzzle.fs

REQUIRE coords.fs
REQUIRE shapes.fs

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

: PUZZLE-PLACE-SHAPE ( puzzle,xy,shape -- )
    ASSERT( DUP 2OVER ROT PUZZLE-SHAPE-FIT? )
    -ROT SWAP ROT
    DUP SHAPE-LENGTH + SWAP DO
        OVER I C@ TRANSLATE
        PUZZLE-XY!
    LOOP NIP ;

: .PUZZLE ( puz -- )
    8 0 DO
        8 0 DO
            J I AT-XY
            DUP J I XY
            PUZZLE-XY? IF 42 ELSE 46 THEN
            EMIT
        LOOP
    LOOP CR ;

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
