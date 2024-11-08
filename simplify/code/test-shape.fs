\ test-shape

REQUIRE ffl/tst.fs
REQUIRE shape.fs

." acquiring a shape coordinates"
T{

HEX
SHAPE| ##.|
     | .#.|
     | .#.|
     | .#.|

\ 1,0  1,1 1,2 1,3 
  0100010101020103 ?S

SHAPE| ##.|
     | .##|
     | .#.|

\   1,0 1,1 2,1 1,2 
   0100010102010102 ?S

}T
BYE
