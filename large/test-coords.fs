\ test-coords.fs

REQUIRE ffl/tst.fs
REQUIRE coords.fs

." coords" CR

."    can be added to x,y with check" CR
T{
    7 0  0 COORDS+XY? ?TRUE SWAP 7 ?S 0 ?S
    7 0  1 COORDS+XY? ?FALSE
    7 0  2 COORDS+XY? ?FALSE
    7 0  3 COORDS+XY? ?FALSE
    7 0  8 COORDS+XY? ?TRUE SWAP 7 ?S 1 ?S
    7 0  7 COORDS+XY? ?TRUE 2DROP
    7 0  6 COORDS+XY? ?TRUE 2DROP
    7 0 -1 COORDS+XY? ?TRUE 2DROP
    7 0 -8 COORDS+XY? ?FALSE
    7 0 -7 COORDS+XY? ?FALSE
    7 0 -6 COORDS+XY? ?FALSE
    7 0 -5 COORDS+XY? ?FALSE
    7 0 -9 COORDS+XY? ?FALSE
    7 7  1 COORDS+XY? ?FALSE
    7 7  8 COORDS+XY? ?FALSE
    7 7 -8 COORDS+XY? ?TRUE SWAP 7 ?S 6 ?S
}T
