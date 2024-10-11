\ test-init-shapes.fs

REQUIRE ffl/tst.fs
REQUIRE init-shapes.fs

PAGE
." constants" CR
T{
    5 PIECE-LENGTH ?S
    25 PIECE-AREA ?S
}T

." compiling a shape" CR
T{
    8 SHAPE MY-SHAPE
    | #.#..|
    | ###..|
    | .....|
    | .....|
    | .....|

    MY-SHAPE C@ 8 ?S
    MY-SHAPE 1 + C@  CHAR # ?S
    MY-SHAPE 2 + C@  CHAR . ?S
    MY-SHAPE 3 + C@  CHAR # ?S
    MY-SHAPE 5 + C@  CHAR . ?S
    MY-SHAPE 6 + C@  CHAR # ?S
}T

." extracting shape coords for a position" CR
T{
    MY-SHAPE 0 POSITION COORDS
    0 ?S  0 ?S
    0 ?S  2 ?S
    1 ?S  0 ?S
    1 ?S  1 ?S
    1 ?S  2 ?S
}T
BYE




