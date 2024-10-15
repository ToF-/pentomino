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

VARIABLE Y
VARIABLE X
VARIABLE COORDS^

: | ( <cccc|> x,y,addr --  )
    [CHAR] | WORD COUNT
    OVER + SWAP DO
        I C@ [CHAR] # = IF
            DUP 2OVER ROT )! 2 + 
        THEN
        SWAP 1+ SWAP
    LOOP
    -ROT DROP 1+ 0 ROT ;


: ;SHAPE ( piece,x,y,addr -- )
    DROP 2DROP 0 COORDS COORDS% )CENTER ;

: SHAPE| ( <cccc|> piece -- piece )
    DUP 0 COORDS 0 0 ROT | ;


1 1 PIECE CROSS

CROSS SHAPE| .#.|
           | ###|
           | .#.|
           ;SHAPE

