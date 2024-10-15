\ pieces.fs

REQUIRE coords.fs

2 5 * CONSTANT COORDS%

: PIECE ( <name> color,orient -- )
    CREATE
    C, DUP C,
    COORDS% * ALLOT ;

: COLOR ( piece -- color )
    C@ ;

: ORIENT-MAX ( piece -- n )
    1+ C@ ;

: COORDS ( piece, n -- offset )
    COORDS% * 2 + + ;

: | ( <cccc|> addr,y,x -- addr,y',x' )
    [CHAR] | WORD COUNT
    OVER + SWAP DO
        I C@ [CHAR] # = IF
            ROT >R
            2DUP SWAP R@ )!
            R> 2 + -ROT
        THEN
        1+
    LOOP
    DROP 1+ 0 ;


: ;SHAPE ( piece,y,x,addr -- )
    DROP 2DROP
    0 COORDS COORDS% ))CENTER ;

: SHAPE| ( <cccc|> piece -- piece )
    DUP 0 COORDS 0 0 | ;

: >COORDS ( piece,n,m -- )
    ROT DUP 2SWAP
    -ROT COORDS -ROT COORDS
    COORDS% CMOVE ;

: >ROTATE ( piece,n,m -- )
    ROT DUP 2SWAP DUP >R
    >COORDS
    R> COORDS DUP COORDS% ))ROTATE
    COORDS% ))CENTER ;

1 1 PIECE CROSS

CROSS SHAPE| .#.|
           | ###|
           | .#.|
           ;SHAPE

2 2 PIECE UPPERI

UPPERI SHAPE| #####|
            ;SHAPE
UPPERI 0 1 >ROTATE

4 3 PIECE BRIDGE

BRIDGE SHAPE| ###|
            | #.#|
            ;SHAPE
BRIDGE 0 1 >ROTATE
BRIDGE 1 2 >ROTATE
BRIDGE 2 3 >ROTATE


\ 0: CROSS
\ 1: UPPERI
\ 2: BRIDGE 3: CORNER 4: STAIRS 5: UPPERT
\ 6: LOWERS
\ 7: LOWERT 8: UPPERL 9: BIRD 10: SNAKE 11: HOUSE


