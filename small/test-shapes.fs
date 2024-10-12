\ test-init-shapes.fs

REQUIRE ffl/tst.fs
REQUIRE shapes.fs

PAGE
." compile a shape with color code, dimensions, and grid" CR
T{
    5 2 1 SHAPE SNAKE
    | ..###|
    | ###..|
    ;SHAPE

   SNAKE COLOR 1 ?S
   SNAKE H-SIZE 5 ?S
   SNAKE V-SIZE 2 ?S
   SNAKE 1 1 .SHAPE

    3 3 2 SHAPE CROSS
    | .#.|
    | ###|
    | .#.|
    ;SHAPE

   CROSS 3 2 .SHAPE

    3 3 12 SHAPE HOUSE
    | .#.|
    | ##.|
    | ##.|
    ;SHAPE

   HOUSE 1 3 .SHAPE
}T

BYE
