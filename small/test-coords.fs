\ test-coords.fs

REQUIRE ffl/tst.fs
REQUIRE coords.fs

." coords" CR
."    can be stored on one byte and expanded" CR
T{
    3 2 )C  HEX 32 ?S DECIMAL
    3 2 )C  XY  SWAP 3 ?S 2 ?S

    -1 2 )C  XY SWAP -1 ?S 2 ?S
    2 -1 )C  XY SWAP 2 ?S -1 ?S
}T

."    add two coords" CR
T{
    3 -1 )C   -1 4 )C  )+  2 3 )C ?S
}T

."    negate a coord" CR
T{
    3 -1 )C )NEGATE  -3 1 )C ?S
}T

."    find the minimun of two coords" CR
T{
    3 -1 )C   2 4 )C  )MIN  2 -1 )C ?S
}T

."    find the minima of an array of coords" CR
T{
    CREATE my-coords
    3 -1 )C, -2 0 )C, 2 -1 )C,
    my-coords 3 ))MIN  -2 -1 )C ?S
}T

."    center an array of coords on 0 0" CR
T{
    CREATE other-coords 3 ALLOT
    my-coords other-coords 3 CMOVE
    other-coords 3 ))MIN -2 -1 )C ?S
    other-coords 3 ))CENTER
    other-coords DUP    C@ 5 0 )C ?S
                 1+ DUP C@ 0 1 )C ?S
                 1+     C@ 4 0 )C ?S
}T

."    rotate left an array of coords" CR
T{
    CREATE upperl
    0 3 )C, 0 2 )C, 0 1 )C, 0 0 )C, 1 0 )C,
    upperl 5 ))ROTATE
    upperl  DUP    C@  0 0 )C ?S
            1+ DUP C@  1 0 )C ?S
            1+ DUP C@  2 0 )C ?S
            1+ DUP C@  3 0 )C ?S
            1+     C@  3 1 )C ?S
}T

."    flip vertically an array of coords" CR
T{
    CREATE uppert
    0 0 )C, 1 0 )C, 2 0 )C, 1 1 )C, 1 2 )C,
    uppert 5 ))FLIP
    uppert  DUP    C@  0 2 )C ?S
            1+ DUP C@  1 2 )C ?S
            1+ DUP C@  2 2 )C ?S
            1+ DUP C@  1 1 )C ?S
            1+     C@  1 0 )C ?S
}T
