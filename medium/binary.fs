\ binary.fs

: MASKED ( value,n -- value' )
    1 SWAP LSHIFT 1- AND ;

: NEG-MASK ( m,n -- mask )
    1 SWAP LSHIFT 1-
    SWAP LSHIFT -1 XOR ;

: >> ( cell,n -- cell',value )
    2DUP RSHIFT -ROT MASKED ;

: << ( cell,value,n -- cell' )
    TUCK MASKED -ROT LSHIFT OR ;

: <<! ( cell,value,n,m -- cell' )
    2DUP SWAP NEG-MASK       \ cell,value,n,m,k
    2SWAP MASKED             \ cell,m,k,v'
    ROT LSHIFT               \ cell,k,v
    -ROT AND OR ;
