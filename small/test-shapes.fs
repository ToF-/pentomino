\ test-init-shapes.fs

REQUIRE ffl/tst.fs
REQUIRE shapes.fs

." compile a shape with color code, dimensions, and grid" CR
T{
    7 5 2 SHAPE SNAKE
    | ..###|
    | ###..|
    ;SHAPE

   SNAKE COLOR 7 ?S
   SNAKE H-SIZE 5 ?S
   SNAKE V-SIZE 2 ?S
   SNAKE 15 10 .SHAPE  \ should display the shape in 15,10
}T
