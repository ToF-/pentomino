\ test-binary.fs

REQUIRE ffl/tst.fs
REQUIRE binary.fs

." binary" CR
."     masking and shifting to store values" CR
T{
    HEX FF 9 4 dbg << FF9 ?S
}T
