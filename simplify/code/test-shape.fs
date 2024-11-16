\ test-shape

REQUIRE ffl/tst.fs
REQUIRE shape.fs

REQUIRE ffl/tst.fs
REQUIRE shape.fs
HEX
1 1 2 1 3 1 3 2 3 3 0 SHAPE<<XY SHAPE<<XY SHAPE<<XY SHAPE<<XY SHAPE<<XY
3323131211 ?S
BYE
." acquiring a shape" CR
T{
HEX
NEW-SHAPE
 | ##.|
 | .#.|
 | .#.|
 | .#.|
XYS
\ row  col
   0 ?S 0 ?S
   0 ?S 1 ?S
   1 ?S 1 ?S
   2 ?S 1 ?S
   3 ?S 1 ?S

NEW-SHAPE
 | ##.|
 | .##|
 | .#.|
XYS
\ row  col
   0 ?S 0 ?S
   0 ?S 1 ?S
   1 ?S 1 ?S
   1 ?S 2 ?S
   2 ?S 1 ?S
}T
." translating" CR
T{
NEW-SHAPE
 | ##.|
 | .##|
 | .#.|
1 2 (TRANSLATE) XYS
\ row  col
   2 ?S 1 ?S   \ ....
   2 ?S 2 ?S   \ ....
   3 ?S 2 ?S   \ .##.
   3 ?S 3 ?S   \ ..##
   4 ?S 2 ?S   \ ..#.
}T
." rotating" CR
T{
NEW-SHAPE
 | ##.|
 | .##|
 | .#.|
ROTATE XYS
\ row  col
   2 ?S 0 ?S
   1 ?S 0 ?S  \ .#.
   1 ?S 1 ?S  \ ###
   0 ?S 1 ?S  \ #..
   1 ?S 2 ?S
}T
." flipping" CR
T{
NEW-SHAPE
 | ##.|
 | .##|
 | .#.|
FLIP XYS
\ row  col
   0 ?S 2 ?S
   0 ?S 1 ?S  \ .##
   1 ?S 1 ?S  \ ##.
   1 ?S 0 ?S  \ .#.
   2 ?S 1 ?S
}T
BYE
