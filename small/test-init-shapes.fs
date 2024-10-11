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
    | .....|
    | .....|
    | .#.#.|
    | .###.|
    | .....|

    MY-SHAPE C@ 8 ?S
    MY-SHAPE 0 POSITION
    DUP 11 + C@  CHAR # ?S
    DUP 12 + C@  CHAR . ?S
    DUP 13 + C@  CHAR # ?S
    DUP 16 + C@  CHAR # ?S
    DUP 17 + C@  CHAR # ?S
    DUP 18 + C@  CHAR # ?S
    DROP
}T

." finding first coords in a shape position" CR
T{
    MY-SHAPE 0 POSITION
    FIRST-COORDS SWAP 1 ?S 2 ?S
}T

." calibrating a shape position" CR
T{
    MY-SHAPE 0 POSITION CALIBRATE
    MY-SHAPE 0 POSITION
    DUP 0 + C@  CHAR # ?S
    DUP 1 + C@  CHAR . ?S
    DUP 2 + C@  CHAR # ?S
    DUP 5 + C@  CHAR # ?S
    DUP 6 + C@  CHAR # ?S
    DUP 7 + C@  CHAR # ?S
    DROP
}T
." extracting shape coords for a position, calibrated" CR
T{
    MY-SHAPE 0 POSITION DUP CALIBRATE COORDS
    0 ?S  0 ?S
    0 ?S  2 ?S
    1 ?S  0 ?S
    1 ?S  1 ?S
    1 ?S  2 ?S
}T
BYE




