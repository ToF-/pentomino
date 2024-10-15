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
}T

."    UPPERI has color 2, 2 orientations" CR
T{
    UPPERI COLOR 2 ?S
    UPPERI ORIENT-MAX 2 ?S
    UPPERI 0 COORDS
        DUP )@ SWAP  0 ?S 0 ?S
    2 + DUP )@ SWAP  1 ?S 0 ?S
    2 + DUP )@ SWAP  2 ?S 0 ?S
    2 + DUP )@ SWAP  3 ?S 0 ?S
    2 +     )@ SWAP  4 ?S 0 ?S
    UPPERI 1 COORDS
        DUP )@ SWAP  0 ?S 4 ?S
    2 + DUP )@ SWAP  0 ?S 3 ?S
    2 + DUP )@ SWAP  0 ?S 2 ?S
    2 + DUP )@ SWAP  0 ?S 1 ?S
    2 +     )@ SWAP  0 ?S 0 ?S
}T

."    BRIDGE has color 3, 4 orientations" CR
T{
    BRIDGE COLOR 3 ?S
    BRIDGE ORIENT-MAX 4 ?S
    BRIDGE 0 COORDS
        DUP )@ SWAP  0 ?S 0 ?S
    2 + DUP )@ SWAP  1 ?S 0 ?S
    2 + DUP )@ SWAP  2 ?S 0 ?S
    2 + DUP )@ SWAP  0 ?S 1 ?S
    2 +     )@ SWAP  2 ?S 1 ?S
    BRIDGE 1 COORDS
        DUP )@ SWAP  0 ?S 2 ?S
    2 + DUP )@ SWAP  0 ?S 1 ?S
    2 + DUP )@ SWAP  0 ?S 0 ?S
    2 + DUP )@ SWAP  1 ?S 2 ?S
    2 +     )@ SWAP  1 ?S 0 ?S
    BRIDGE 2 COORDS
        DUP )@ SWAP  2 ?S 1 ?S
    2 + DUP )@ SWAP  1 ?S 1 ?S
    2 + DUP )@ SWAP  0 ?S 1 ?S
    2 + DUP )@ SWAP  2 ?S 0 ?S
    2 +     )@ SWAP  0 ?S 0 ?S
    BRIDGE 3 COORDS
        DUP )@ SWAP  1 ?S 0 ?S
    2 + DUP )@ SWAP  1 ?S 1 ?S
    2 + DUP )@ SWAP  1 ?S 2 ?S
    2 + DUP )@ SWAP  0 ?S 0 ?S
    2 +     )@ SWAP  0 ?S 2 ?S
}T


