\ test-situation.fs

REQUIRE ffl/tst.fs
REQUIRE situation.fs

." puzzle" CR

."    a piece with a given orientation and location as puzzle sitution" CR
T{
    CROSS 0 0 0 SITUATION 
    2 BASE ! 100000011100000010 ?S DECIMAL
    NIP HEX 8 ?S DECIMAL
}T
