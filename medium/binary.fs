\ binary.fs

: MASK ( value,n -- value' )
    1 SWAP LSHIFT 1- AND ;

: >> ( cell,n -- cell',value )
    2DUP RSHIFT -ROT MASK ;

: << ( cell,value,n -- cell' )
    2DUP MASK -ROT LSHIFT OR ;

