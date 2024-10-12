\ test-init-shapes.fs

REQUIRE ffl/tst.fs
REQUIRE shapes.fs
REQUIRE display.fs

PAGE
." compile a shape with color code, dimensions, and grid" CR
T{
    4 2 1 SHAPE SNAKE
    | .###|
    | ##..|
    ;SHAPE

   SNAKE COLOR 1 ?S
   SNAKE H-SIZE 4 ?S
   SNAKE V-SIZE 2 ?S
   SNAKE 1 1 .SHAPE

    3 3 2 SHAPE CROSS
    | .#.|
    | ###|
    | .#.|
    ;SHAPE

   CROSS 2 2 .SHAPE

    3 3 12 SHAPE HOUSE
    | #..|
    | ##.|
    | ##.|
    ;SHAPE

   HOUSE 1 3 .SHAPE
}T

BYE
