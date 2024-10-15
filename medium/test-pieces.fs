\ test-pieces.fs

REQUIRE ffl/tst.fs
REQUIRE pieces.fs

." pieces" CR

."    CROSS has color 1, 1 orientation only, and coords" CR
T{
    CROSS COLOR 1 ?S
    CROSS ORIENT-MAX 1 ?S
    CROSS 0 COORDS
        DUP )@ SWAP  1 ?S 0 ?S
    2 + DUP )@ SWAP  0 ?S 1 ?S
    2 + DUP )@ SWAP  1 ?S 1 ?S
    2 + DUP )@ SWAP  2 ?S 1 ?S
    2 +     )@ SWAP  1 ?S 2 ?S

    CROSS 0 COORDS COORDS% DUMP
}T
