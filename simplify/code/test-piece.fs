\ test-piece.fs

REQUIRE ffl/tst.fs
REQUIRE piece.fs

SUITE piece
TEST defining pieces
T{
0 NTH-PIECE DUP @ 1 ?S CELL+ @ @
NEW-SHAPE
| .#.
| ###
| .#.
?S
1 NTH-PIECE DUP @ 2 ?S CELL+ @ CELL+ @
NEW-SHAPE
| #
| #
| #
| #
| #
HEX
?S
DECIMAL
11 NTH-PIECE DUP @ 8 ?S CELL+ @ @ 
NEW-SHAPE
| #.
| ##
| ##
?S
}T

: .SHAPE ( x,y -- )
    ROW ! COL !
    XYS 5 0 DO
        ROW @ + SWAP COL @ + SWAP
        AT-XY [CHAR] # EMIT
    LOOP ;

: FOO
    PAGE
    63 0 DO
        I NTH-SHAPE @
        I 10 /MOD 6 * 1+ SWAP 8 * SWAP
        .SHAPE
        I 10 /MOD 6 * SWAP 8 * SWAP
        AT-XY I . CR CR CR
    LOOP ;

