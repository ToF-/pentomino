# Capturing a shape

To capture a shape from lines of forth code, we can use `WORD` : given a character code _C_ on the stack, `WORD` will scan the characters that follow until _C_ is met. The result on the stack is the address of chars that has just been read, starting with the length of the string. Let's try this :
```
> gforth
46 WORD FOO BAR. ⏎  ok
.S <1> 5402534688 ⏎  ok
COUNT ⏎  ok
.S <2> 5402534689 7 ⏎  ok
TYPE CR FOO BAR ⏎
ok
BYE
```
`WORD ( n <cccc> -- addr )` : read characters in the source flow until the char with ascii code _n_ is met. Return the address of the buffer where the chars are stored.

`COUNT ( addr -- addr+1, count )` : given the address of a string, return the address of the first char and the length.

`TYPE ( addr, count -- )` : display _count_ characters from _addr_.

The idea here is to capture a shape line after line, tracking the row and column values and inserting them in a cell as we go.

<pre style="color:#000000;background:000000;"><span style="color:#669999; font-weight:bold;">\</span> <span style="color:#669999; font-weight:bold;">shape.fs
<span style="color:#800000; font-weight:bold;">0</span> <span style="color:#F07F00; font-weight:bold;">CONSTANT</span> <span style="color:#336699; font-weight:bold;">EMPTY-COORDS</span>
<span style="color:#F07F00; font-weight:bold;">VARIABLE</span> <span style="color:#336699; font-weight:bold;">COL</span> <span style="color:#F07F00; font-weight:bold;">VARIABLE</span> <span style="color:#336699; font-weight:bold;">ROW</span>
<span style="color:#3D3D5C; font-weight:bold;">CHAR</span> <span style="color:#800000; font-weight:bold;">|</span> <span style="color:#F07F00; font-weight:bold;">CONSTANT</span> <span style="color:#336699; font-weight:bold;">BAR</span> <span style="color:#3D3D5C; font-weight:bold;">CHAR</span> <span style="color:#3D3D5C; font-weight:bold;">#</span> <span style="color:#F07F00; font-weight:bold;">CONSTANT</span> <span style="color:#336699; font-weight:bold;">SQUARE</span>

<span style="color:#F07F00; font-weight:bold;">:</span> <span style="color:#336699; font-weight:bold;">|</span> <span style="color:#669999; font-weight:bold;">(</span> <span style="color:#669999; font-weight:bold;">ccccc | coords -- coords' )</span>
    <span style="color:#336699; font-weight:bold;">BAR</span> <span style="color:#3D3D5C; font-weight:bold;">WORD</span>
    <span style="color:#3D3D5C; font-weight:bold;">COUNT</span> <span style="color:#009999; font-weight:bold;">OVER</span> <span style="color:#CC6600; font-weight:bold;">+</span> <span style="color:#009999; font-weight:bold;">SWAP</span> <span style="color:#993300; font-weight:bold;">DO</span>
        <span style="color:#993300; font-weight:bold;">I</span> <span style="color:#CC3300; font-weight:bold;">C@</span> <span style="color:#336699; font-weight:bold;">SQUARE</span> <span style="color:#CC6600; font-weight:bold;">=</span> <span style="color:#993300; font-weight:bold;">IF</span>
            <span style="color:#336699; font-weight:bold;">COL</span> <span style="color:#CC3300; font-weight:bold;">@</span> <span style="color:#336699; font-weight:bold;">ROW</span> <span style="color:#CC3300; font-weight:bold;">@</span> <span style="color:#009999; font-weight:bold;">ROT</span> <span style="color:#336699; font-weight:bold;">SHAPE&lt;&lt;XY</span>
        <span style="color:#993300; font-weight:bold;">THEN</span>
        <span style="color:#800000; font-weight:bold;">1</span> <span style="color:#336699; font-weight:bold;">COL</span> <span style="color:#CC3300; font-weight:bold;">+!</span>
    <span style="color:#993300; font-weight:bold;">LOOP</span>
    <span style="color:#336699; font-weight:bold;">COL</span> <span style="color:#CC3300; font-weight:bold;">OFF</span>
    <span style="color:#800000; font-weight:bold;">1</span> <span style="color:#336699; font-weight:bold;">ROW</span> <span style="color:#CC3300; font-weight:bold;">+!</span> <span style="color:#993300; font-weight:bold;">;</span>

<span style="color:#F07F00; font-weight:bold;">:</span> <span style="color:#336699; font-weight:bold;">NEW-SHAPE</span> <span style="color:#669999; font-weight:bold;">(</span> <span style="color:#669999; font-weight:bold;">ccccc | -- coords )</span>
    <span style="color:#336699; font-weight:bold;">COL</span> <span style="color:#CC3300; font-weight:bold;">OFF</span> <span style="color:#336699; font-weight:bold;">ROW</span> <span style="color:#CC3300; font-weight:bold;">OFF</span> <span style="color:#336699; font-weight:bold;">EMPTY-COORDS</span> <span style="color:#993300; font-weight:bold;">;</span>
</pre>
