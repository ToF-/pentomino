\ test-init-shapes.fs

REQUIRE ffl/tst.fs
REQUIRE init-shapes.fs

PAGE
." constants" CR
T{
    5 PIECE-LENGTH ?S
    25 PIECE-AREA ?S
}T

." finding first coords in a shape position" CR
T{
    PAD
         | .....|
         | .....|
         | .....|
         | ....#|
         | .####|
    DROP
    PAD FIRST-COORDS SWAP 1 ?S 3 ?S
}T

." calibrating a shape position" CR
T{
    CREATE A-SHAPE
    A-SHAPE
         | .....|
         | .....|
         | .#.#.|
         | .###.|
         | .....|
    DROP
    A-SHAPE CALIBRATE
    A-SHAPE
    DUP 0 + C@  CHAR # ?S
    DUP 1 + C@  CHAR . ?S
    DUP 2 + C@  CHAR # ?S
    DUP 5 + C@  CHAR # ?S
    DUP 6 + C@  CHAR # ?S
    DUP 7 + C@  CHAR # ?S
    DROP
}T
." extracting shape coords" CR
T{
    CREATE ANOTHER-SHAPE PIECE-AREA ALLOT
    ANOTHER-SHAPE
         | .....|
         | .....|
         | .#.#.|
         | .###.|
         | .....|
    DROP
    ANOTHER-SHAPE COORDS
    2 ?S  1 ?S
    2 ?S  3 ?S
    3 ?S  1 ?S
    3 ?S  2 ?S
    3 ?S  3 ?S
}T

." rotating a shape" CR
T{
    CREATE YET-ANOTHER-SHAPE PIECE-AREA ALLOT
    YET-ANOTHER-SHAPE
         | #....|
         | #....|
         | #....|
         | ##...|
         | .....|
    DROP
    YET-ANOTHER-SHAPE ROTATE
    YET-ANOTHER-SHAPE COORDS
    3 ?S  3 ?S  \    | .....|
    4 ?S  0 ?S  \    | .....|
    4 ?S  1 ?S  \    | .....|
    4 ?S  2 ?S  \    | ...#.|
    4 ?S  3 ?S  \    | ####.|
}T

." flpping a shape" CR
T{
    CREATE YET-YET-ANOTHER-SHAPE PIECE-AREA ALLOT
    YET-YET-ANOTHER-SHAPE
         | .#...|
         | .#...|
         | .#...|
         | .##..|
         | .....|
    DROP
    YET-YET-ANOTHER-SHAPE FLIP
    YET-YET-ANOTHER-SHAPE COORDS
    0 ?S  3 ?S  \    | ...#.|
    1 ?S  3 ?S  \    | ...#.|
    2 ?S  3 ?S  \    | ...#.|
    3 ?S  2 ?S  \    | ..##.|
    3 ?S  3 ?S  \    | .....|
}T
." compiling a shape" CR
T{
    8 SHAPE MY-SHAPE
    MY-SHAPE C@ 8 ?S
    MY-SHAPE
    MODEL{
         | #....|
         | #....|
         | #....|
         | ##...|
         | .....|
    }MODEL
    MY-SHAPE 0 POSITION 10 10 .SHAPE
    MY-SHAPE 1 POSITION 16 10 .SHAPE
    MY-SHAPE 2 POSITION 22 10 .SHAPE
    MY-SHAPE 3 POSITION 28 10 .SHAPE
    MY-SHAPE 4 POSITION 34 10 .SHAPE
    MY-SHAPE 5 POSITION 40 10 .SHAPE
    MY-SHAPE 6 POSITION 46 10 .SHAPE
    MY-SHAPE 7 POSITION 52 10 .SHAPE
    CR
}T

BYE




