\ test-pieces.fs

REQUIRE ffl/tst.fs
REQUIRE pieces.fs

." pieces" CR

."    have shapes and positions that are iterated over" CR 
T{
    -1 -1 SHAPE-INDEX 2!
    NEXT-SHAPE-INDEX SHAPE-INDEX 2@ SWAP PIECE UPPERI ?S 0 ?S
    NEXT-SHAPE-INDEX SHAPE-INDEX 2@ SWAP PIECE UPPERI ?S 1 ?S
    NEXT-SHAPE-INDEX SHAPE-INDEX 2@ SWAP PIECE SNAKE  ?S 0 ?S
    NEXT-SHAPE-INDEX SHAPE-INDEX 2@ SWAP PIECE SNAKE  ?S 1 ?S
    NEXT-SHAPE-INDEX SHAPE-INDEX 2@ SWAP PIECE SNAKE  ?S 2 ?S
    NEXT-SHAPE-INDEX SHAPE-INDEX 2@ SWAP PIECE SNAKE  ?S 3 ?S
    NEXT-SHAPE-INDEX SHAPE-INDEX 2@ SWAP PIECE SNAKE  ?S 4 ?S
    NEXT-SHAPE-INDEX SHAPE-INDEX 2@ SWAP PIECE SNAKE  ?S 5 ?S
    NEXT-SHAPE-INDEX SHAPE-INDEX 2@ SWAP PIECE SNAKE  ?S 6 ?S
    NEXT-SHAPE-INDEX SHAPE-INDEX 2@ SWAP PIECE SNAKE  ?S 7 ?S
    NEXT-SHAPE-INDEX SHAPE-INDEX 2@ SWAP PIECE UPPERL ?S 0 ?S
    11 0 SHAPE-INDEX 2!
}T

."    a piece in a position (0…7: 3 bits) can be put (bit 7=1) on a square (0…64: 6 bits) or not (bit 7 = 0)" CR
T{
    CREATE MY-PUZZLE-KEY PUZZLE-KEY% ALLOT
    MY-PUZZLE-KEY PUZZLE-KEY% ERASE
    0 0 0 0 )C MY-PUZZLE-KEY STORE-KEY
    HEX 0080 DECIMAL 0 0 0 0 )C PUZZLE-KEY ?S
}T
    \          presence bits
    \ CROSS  : 0
    \ UPPERI : 1
    \ STAIRS : 2
    \ UPPERT : 3
    \ BRIDGE : 4
    \ CORNER : 5
    \ LOWERS : 6
    \ UPPERT : 7
    \ BIRD   : 8
    \ UPPERL : 9
    \ LOWERT : 10
    \ SNAKE  : 11
    \          position bits
    \ CROSS  : no bits
    \ UPPERI : 12
    \ STAIRS : 13…14
    \ UPPERT : 15…16
    \ BRIDGE : 17…18
    \ CORNER : 19…20
    \ LOWERS : 21…22
    \ UPPERT : 23…24
    \ BIRD   : 25…27
    \ UPPERL : 28…30
    \ LOWERT : 31…33
    \ SNAKE  : 34…36
