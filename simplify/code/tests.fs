\ tests.fs

: SUITE ( <cccc> | )
    0 WORD
    COUNT TYPE CR ;

: TEST ( <ccccc> | )
    9 EMIT SUITE ;

REQUIRE test-shape.fs
REQUIRE test-piece.fs

BYE


