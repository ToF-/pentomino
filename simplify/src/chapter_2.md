# Acquiring Shapes

What is a shape ? It's a list of square relative positions, for instance the shape :
```
  012

0 ##.
1 .#.
2 .#.
3 .#.

```
Can be defined with the list : {(0,0),(1,0),(1,1),(2,1),(3,1)} where each couple is the row and column of each square respectively.

How can we automatically capture a shape as drawn above with a forth word ? What we'd like is to encode a shape's squares in a way that gives us a list of coords in the end, like this :
```
SHAPE| ##.|
     | .#.|
     | .#.|
     | .#.|
```
and end up with a list of ten values on the stack.

`SHAPE|` would start the acquisition process.
`|` would acquire a new line for the current shape

Since row and column values varies between 0 and 4, they can easily be stored in a nibble. Thus 5 couples of coordinates can be stored in 5 bytes, which is less than than the size of a cell in gforth.

<pre style="color:#000000;background:#F2F2F2;"><span style="color:#669999; font-weight:bold;">\</span> <span style="color:#669999; font-weight:bold;">shape.fs
</span>
<span style="color:#F07F00; font-weight:bold;">VARIABLE</span> <span style="color:#336699; font-weight:bold;">COL</span>
<span style="color:#F07F00; font-weight:bold;">VARIABLE</span> <span style="color:#336699; font-weight:bold;">ROW</span>

<span style="color:#3D3D5C; font-weight:bold;">CHAR</span> <span style="color:#800000; font-weight:bold;">|</span> <span style="color:#F07F00; font-weight:bold;">CONSTANT</span> <span style="color:#336699; font-weight:bold;">BAR</span>
<span style="color:#3D3D5C; font-weight:bold;">CHAR</span> <span style="color:#3D3D5C; font-weight:bold;">#</span> <span style="color:#F07F00; font-weight:bold;">CONSTANT</span> <span style="color:#336699; font-weight:bold;">SQUARE</span>

<span style="color:#F07F00; font-weight:bold;">:</span> <span style="color:#336699; font-weight:bold;">&lt;&lt;COORD!</span> <span style="color:#669999; font-weight:bold;">(</span> <span style="color:#669999; font-weight:bold;">coords,n -- coords' )</span>
    <span style="color:#009999; font-weight:bold;">SWAP</span> <span style="color:#800000; font-weight:bold;">4</span> <span style="color:#CC6600; font-weight:bold;">LSHIFT</span> <span style="color:#CC6600; font-weight:bold;">OR</span> <span style="color:#993300; font-weight:bold;">;</span>

<span style="color:#F07F00; font-weight:bold;">:</span> <span style="color:#336699; font-weight:bold;">|</span> <span style="color:#669999; font-weight:bold;">(</span> <span style="color:#669999; font-weight:bold;">ccccc | coords -- coords' )</span>
    <span style="color:#336699; font-weight:bold;">BAR</span> <span style="color:#3D3D5C; font-weight:bold;">WORD</span>
    <span style="color:#3D3D5C; font-weight:bold;">COUNT</span> <span style="color:#009999; font-weight:bold;">OVER</span> <span style="color:#CC6600; font-weight:bold;">+</span> <span style="color:#009999; font-weight:bold;">SWAP</span> <span style="color:#993300; font-weight:bold;">DO</span>
        <span style="color:#993300; font-weight:bold;">I</span> <span style="color:#CC3300; font-weight:bold;">C@</span> <span style="color:#336699; font-weight:bold;">SQUARE</span> <span style="color:#CC6600; font-weight:bold;">=</span> <span style="color:#993300; font-weight:bold;">IF</span>
            <span style="color:#336699; font-weight:bold;">COL</span> <span style="color:#CC3300; font-weight:bold;">@</span> <span style="color:#336699; font-weight:bold;">&lt;&lt;COORD!</span>
            <span style="color:#336699; font-weight:bold;">ROW</span> <span style="color:#CC3300; font-weight:bold;">@</span> <span style="color:#336699; font-weight:bold;">&lt;&lt;COORD!</span>
        <span style="color:#993300; font-weight:bold;">THEN</span>
        <span style="color:#800000; font-weight:bold;">1</span> <span style="color:#336699; font-weight:bold;">COL</span> <span style="color:#CC3300; font-weight:bold;">+!</span>
    <span style="color:#993300; font-weight:bold;">LOOP</span>
    <span style="color:#336699; font-weight:bold;">COL</span> <span style="color:#CC3300; font-weight:bold;">OFF</span>
    <span style="color:#800000; font-weight:bold;">1</span> <span style="color:#336699; font-weight:bold;">ROW</span> <span style="color:#CC3300; font-weight:bold;">+!</span> <span style="color:#993300; font-weight:bold;">;</span>

<span style="color:#F07F00; font-weight:bold;">:</span> <span style="color:#336699; font-weight:bold;">SHAPE|</span> <span style="color:#669999; font-weight:bold;">(</span> <span style="color:#669999; font-weight:bold;">ccccc | -- coords )</span>
    <span style="color:#336699; font-weight:bold;">COL</span> <span style="color:#CC3300; font-weight:bold;">OFF</span> <span style="color:#336699; font-weight:bold;">ROW</span> <span style="color:#CC3300; font-weight:bold;">OFF</span> <span style="color:#800000; font-weight:bold;">0</span> <span style="color:#336699; font-weight:bold;">|</span> <span style="color:#993300; font-weight:bold;">;</span>
</pre>
Let's try our words: 
```
> gforth shape.fs
SHAPE| ###| ⏎ ok
     | #.#| ⏎ ok
HEX . CR 10200121 ⏎
BYE
```
The words correctly capture the coordinates (0,0),(1,0),(2,0),(0,1),(2,1).

