REQUIRE shapes.fs

: .POS ( adr -- )
    PAGE
    DUP 5 + SWAP DO
        I C@ COORDS>XY
        10 + SWAP 10 + SWAP
        AT-XY 42 EMIT
    LOOP
    0 20 AT-XY
    KEY DROP ;

: .DEMO
    12 0 DO
        SHAPES I CELLS + @
        DUP C@ 0 DO
            DUP 1+ I 5 * + .POS
        LOOP DROP
    LOOP ;

.DEMO BYE

