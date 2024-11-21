\ board.fs

3 CELLS CONSTANT BOARD-SIZE

CREATE BOARDS
BOARD-SIZE 16 * ALLOT

VARIABLE BOARD-MAX

: INIT-BOARDS
    BOARDS BOARD-SIZE ERASE
    BOARD-MAX OFF ;

: CURRENT-BOARD ( -- addr )
    BOARD-MAX @ BOARD-SIZE * BOARDS + ;

: NEW-BOARD
    BOARD-MAX IF
        CURRENT-BOARD
        DUP BOARD-SIZE +
        BOARD-SIZE CMOVE
    THEN
    1 BOARD-MAX +! ;

: POP-BOARD
    BOARD-MAX IF -1 BOARD-MAX +!  THEN ;

