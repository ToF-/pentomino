\ bitfields.fs

: LSHIFT! ( cell,value,size,pos -- cell' )
    ROT OVER LSHIFT
    -ROT 1 ROT LSHIFT 1-
    SWAP LSHIFT -1 XOR
    ROT AND OR ;

: RSHIFT@ ( cell,size,pos -- value )
    ROT SWAP RSHIFT
    SWAP 1 SWAP LSHIFT 1- AND ;
