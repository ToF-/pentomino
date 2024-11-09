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

0010111213 ?S

SHAPE| ##.|
     | .##|
     | .#.|

0010112112 ?S
}T
CR
BYE
