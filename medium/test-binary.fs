\ test-binary.fs

REQUIRE ffl/tst.fs
REQUIRE binary.fs

HEX
." binary" CR
."     masking and shifting to store values" CR
T{
    0001 8 8 << 000108 ?S
    00FF 9 4 << 000FF9 ?S
    000FF9 2 8 << 0FF902 ?S
}T

."     shifting and masking to retrieve values" CR
T{
    000108 8 >> SWAP 1 ?S 8 ?S
    0FF902 8 >> SWAP FF9 ?S 2 ?S
}T

."     shifting and masking to replace values" CR
T{
    0FF902 7 4 8 <<! 0FF702 ?S
    0FF902 0 2 C <<! 0FC902 ?S
    0FF902 1 1 37 <<! 800000000FF902 ?S
}T
DECIMAL
