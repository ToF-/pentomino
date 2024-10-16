\ situation.fs

REQUIRE pieces.fs

2 BASE ! 100000011100000010 CONSTANT FAKE DECIMAL
: SITUATION ( piece,orientation,x,y -- situation,board )
    2DROP 2DROP
    0 8 FAKE
    ; 
