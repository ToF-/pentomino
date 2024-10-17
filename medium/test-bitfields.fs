\ test-bitfields.fs

REQUIRE ffl/tst.fs
REQUIRE bitfields.fs

HEX

." bitfields" CR
."   replace a value of size s at position p" CR
T{
    1234 A 4 8 LSHIFT! 1A34 ?S
    0 7 3 6 LSHIFT! 1C0 ?S
}T
."   extract a value of size s from position p" CR
T{
    F1234 C 4 RSHIFT@ 123 ?S
    54321 7 8 RSHIFT@ 43  ?S
    54321 4 8 RSHIFT@ 3  ?S
}T
DECIMAL

