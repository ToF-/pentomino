\ test-init-shapes.fs

REQUIRE ffl/tst.fs
REQUIRE shapes.fs

PAGE
." compile a shape with color code, dimensions, and grid" CR
T{
    7 5 2 SHAPE SNAKE
    | ..###|
    | ###..|
    ;SHAPE

   SNAKE COLOR 7 ?S
   SNAKE H-SIZE 5 ?S
   SNAKE V-SIZE 2 ?S
   SNAKE 1 1 .SHAPE

    6 3 3 SHAPE CROSS
    | .#.|
    | ###|
    | .#.|
    ;SHAPE

   CROSS 3 2 .SHAPE

    5 3 3 SHAPE HOUSE
    | .#.|
    | ###|
    | ###|
    ;SHAPE

   HOUSE 1 3 .SHAPE
}T

BYE
