\ pieces.fs

REQUIRE shapes.fs

5 2 1 2 SHAPE UPPERI | #####| ;SHAPE

3 3 2 8 SHAPE BIRD     | .##|
                       | ##.|
                       | .#.| ;SHAPE

4 2 3 8 SHAPE UPPERL  | ...#|
                      | ####| ;SHAPE

3 3 4 4 SHAPE BRIDGE   | ###|
                       | #.#| ;SHAPE

4 2 6 8 SHAPE LOWERT  | .#..|
                      | ####| ;SHAPE

4 2 7 8 SHAPE SNAKE   | ..##|
                      | ###.| ;SHAPE

3 3 9 4 SHAPE UPPERT   | ###|
                       | .#.|
                       | .#.| ;SHAPE

3 3 10 20 SHAPE LOWERS | .##|
                       | .#.|
                       | ##.| ;SHAPE

3 3 11 4 SHAPE CORNER  | ###|
                       | #..|
                       | #..| ;SHAPE

3 2 12 8 SHAPE HOUSE   | ##.|
                       | ###| ;SHAPE

3 3 13 4 SHAPE STAIRS  | ##.|
                       | .##|
                       | ..#| ;SHAPE

3 3 14 1 SHAPE CROSS   | .#.|
                       | ###|
                       | .#.| ;SHAPE

CREATE PIECES 
UPPERI , SNAKE  , UPPERL , LOWERT , HOUSE  , BRIDGE ,
CORNER , STAIRS , BIRD   , LOWERS , UPPERT , CROSS  ,
12 CONSTANT MAX-PIECES

: PIECE ( n -- shape )
    CELLS PIECES + @ ;

\ ##### #                                           XXX   XXX     X   X
\       #                                           X       X     X   X
\       #                                           X       X   XXX   XXX
\       #
\       #
\   ##  #      ###  #     ###    #    ##     #      XX      X   X      XX
\ ###   #     ##    ##      ##   #     ###  ##       XX    XX   XX    XX
\       ##           #          ##          #         X   XX     XX   X
\        #           #          #           #
\ 
\    #  #     ####  ##    ####   #    #     ##       ##    #     #    #      #     #    ##      #
\ ####  #     #      #       #   #    ####  #       ##    ###    ##   ###   ##    ###    ##   ###
\       #            #           #          #        #      #   ##     #     ##   #      #     #
\       ##           #          ##          #
\ 
\  #    #     ####   #    ####   #      #   #        XX   X     XX      X
\ ####  ##      #    #     #    ##    ####  #        X    XXX    X    XXX
\       #           ##           #          ##      XX      X    XX   X
\       #            #           #          #
\ 
\ XX    XX    XXX    X    XXX   XX     XX   X       XXX     X    X    X
\ XXX   XX     XX   XX    XX    XX    XXX   XX       X    XXX    X    XXX
\       X           XX           X          XX       X      X   XXX   X
\ 
\ 
\ ###   ##    # #   ##                               X
\ # #    #    ###   #                               XXX
\       ##          ##                               X
