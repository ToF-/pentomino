\ init-shapes.fs

5 CONSTANT PIECE-LENGTH
25 CONSTANT PIECE-AREA

: SHAPE ( n <name> -- )
    CREATE C, ;

: | ( <cccccc|> -- )
    [CHAR] | WORD
    COUNT OVER + SWAP
    DO I C@ C, LOOP ;
