\ test-init-shapes.fs

REQUIRE ffl/tst.fs
REQUIRE shapes.fs
REQUIRE display.fs
REQUIRE coords.fs

." shapes" CR
."     compile a shape with color code, dimensions, and grid" CR
T{
    7 CONSTANT CO
    8 CONSTANT NBP
    4 2 CO NBP SHAPE SNAKE
    | .###|
    | ##..|
    ;SHAPE

   SNAKE COLOR CO ?S
   SNAKE POSITION-MAX NBP ?S
   SNAKE H-SIZE 4 ?S
   SNAKE V-SIZE 2 ?S
   SNAKE SIZE 8 ?S
   SNAKE GRID
   DUP      C@ 0 ?S
   DUP  1 + C@ CO ?S
   DUP  2 + C@ CO ?S
   DUP  3 + C@ CO ?S
   DUP  4 + C@ CO ?S
   DUP  5 + C@ CO ?S
   DUP  6 + C@ 0 ?S
        7 + C@ 0 ?S
}T
."     compute the coords of the shape for every position" CR
T{
    SNAKE 0 POSITION
    DUP     C@   1 0 )C ?S
    1+ DUP  C@   2 0 )C ?S
    1+ DUP  C@   3 0 )C ?S
    1+ DUP  C@   0 1 )C ?S
    1+      C@   1 1 )C ?S
}T
