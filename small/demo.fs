\ demo.fs

REQUIRE shapes.fs
REQUIRE display.fs

4 2 3 8 SHAPE SNAKE
    | .###|
    | ##..|
    ;SHAPE

CREATE SNAKE-POSITION 0 0 )C, 1 0 )C, 1 1 )C, 2 1 )C, 3 1 )C,

PAGE
SNAKE SNAKE-POSITION 0 10 .SHAPE-POSITION CR
SNAKE-POSITION 5 ))ROTATE
SNAKE SNAKE-POSITION 10 10 .SHAPE-POSITION CR
SNAKE-POSITION 5 ))ROTATE
SNAKE SNAKE-POSITION 20 10 .SHAPE-POSITION CR
SNAKE-POSITION 5 ))ROTATE
SNAKE SNAKE-POSITION 30 10 .SHAPE-POSITION CR
SNAKE-POSITION 5 ))FLIP 
SNAKE SNAKE-POSITION 40 10 .SHAPE-POSITION CR
SNAKE-POSITION 5 ))ROTATE
SNAKE SNAKE-POSITION 50 10 .SHAPE-POSITION CR
SNAKE-POSITION 5 ))ROTATE
SNAKE SNAKE-POSITION 60 10 .SHAPE-POSITION CR
SNAKE-POSITION 5 ))ROTATE
SNAKE SNAKE-POSITION 70 10 .SHAPE-POSITION CR
CR CR CR
BYE





