\ test-coords.fs

REQUIRE ffl/tst.fs
REQUIRE coords.fs

." coords" CR

."    can be added to x,y with check" CR
T{
     0 7 0 COORDS+XY? ?TRUE SWAP 7 ?S 0 ?S
     1 7 0 COORDS+XY? ?FALSE
     2 7 0 COORDS+XY? ?FALSE
     3 7 0 COORDS+XY? ?FALSE
     10 7 0 COORDS+XY? ?TRUE SWAP 7 ?S 1 ?S
     21 5 0 COORDS+XY? ?TRUE SWAP 6 ?S 2 ?S
     7 7 0 COORDS+XY? ?TRUE 2DROP
     6 7 0 COORDS+XY? ?TRUE 2DROP
    -1 7 0 COORDS+XY? ?TRUE SWAP 6 ?S 0 ?S
    -10 7 0 COORDS+XY? ?FALSE
    -7 7 0 COORDS+XY? ?FALSE
    -6 7 0 COORDS+XY? ?FALSE
    -5 7 0 COORDS+XY? ?TRUE SWAP 2 ?S 0 ?S
    -9 7 0 COORDS+XY? ?FALSE
     1 7 7 COORDS+XY? ?FALSE
     8 7 7 COORDS+XY? ?FALSE
    -10 7 7 COORDS+XY? ?TRUE SWAP 7 ?S 6 ?S
}T

."    can be checked in a group" CR
T{
    0 1 2 3 4  3 3 SHAPE-XY? ?TRUE
    0 1 2 3 4  7 0 SHAPE-XY? ?FALSE
    0 10 20 30 40 7 0 SHAPE-XY? ?TRUE
    0 10 20 30 40 7 6 SHAPE-XY? ?FALSE
}T

