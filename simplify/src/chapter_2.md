# Shape coordinates

What is a shape ? It's a list of square relative positions, for instance the shape :
```
  012

0 ##.
1 .#.
2 .#.
3 .#.

```
Can be defined with the list : {(0,0),(1,0),(1,1),(2,1),(3,1)} where each couple is the row and column of each square respectively. Since row and column values vary between 0 and 4, they can easily be stored in a 4 bit nibble, and 5 couples of coordinates can be stored 40 bits, which is less than than the size of a cell in gforth.

To insert a 4 bit value in a cell, we shift this cell 4 bits on the left, apply a 4 bit mask on the value, and do a bitwise or between the cell and the value. An x,y coord can be inserted by repeating this operation.

<pre style="color:#000000;background:#000000;"><span style="color:#669999; font-weight:bold;">\</span> <span style="color:#669999; font-weight:bold;">shape.fs
</span> <span style="color:#800000; font-weight:bold;">4</span> <span style="color:#F07F00; font-weight:bold;">CONSTANT</span> <span style="color:#336699; font-weight:bold;">NIBBLE</span>
 <span style="color:#800000; font-weight:bold;">15</span> <span style="color:#F07F00; font-weight:bold;">CONSTANT</span> <span style="color:#336699; font-weight:bold;">VALUE-MASK</span>

<span style="color:#F07F00; font-weight:bold;">:</span> <span style="color:#336699; font-weight:bold;">SHAPE&lt;&lt;N</span> <span style="color:#669999; font-weight:bold;">(</span> <span style="color:#669999; font-weight:bold;">n,coords -- coords' )</span>
    <span style="color:#336699; font-weight:bold;">NIBBLE</span> <span style="color:#CC6600; font-weight:bold;">LSHIFT</span> <span style="color:#009999; font-weight:bold;">SWAP</span> <span style="color:#336699; font-weight:bold;">VALUE-MASK</span> <span style="color:#CC6600; font-weight:bold;">AND</span> <span style="color:#CC6600; font-weight:bold;">OR</span> <span style="color:#993300; font-weight:bold;">;</span>

<span style="color:#F07F00; font-weight:bold;">:</span> <span style="color:#336699; font-weight:bold;">SHAPE&lt;&lt;XY</span> <span style="color:#669999; font-weight:bold;">(</span> <span style="color:#669999; font-weight:bold;">x,y,coords -- coords' )</span>
    <span style="color:#336699; font-weight:bold;">SHAPE&lt;&lt;N</span> <span style="color:#336699; font-weight:bold;">SHAPE&lt;&lt;N</span> <span style="color:#993300; font-weight:bold;">;</span>
</pre>
Let's check our words:
<pre style="color:#000000;background:#F2F2F2;"><span style="color:#669999; font-weight:bold;">\</span> <span style="color:#669999; font-weight:bold;">test-shape
</span>
<span style="color:#3D3D5C; font-weight:bold;">REQUIRE</span> <span style="color:#800000; font-weight:bold;">ffl/tst.fs</span>
<span style="color:#3D3D5C; font-weight:bold;">REQUIRE</span> <span style="color:#800000; font-weight:bold;">shape.fs</span>
<span style="color:#3D3D5C; font-weight:bold;">HEX</span>
<span style="color:#800000; font-weight:bold;">1</span> <span style="color:#800000; font-weight:bold;">1</span> <span style="color:#800000; font-weight:bold;">2</span> <span style="color:#800000; font-weight:bold;">1</span> <span style="color:#800000; font-weight:bold;">3</span> <span style="color:#800000; font-weight:bold;">1</span> <span style="color:#800000; font-weight:bold;">3</span> <span style="color:#800000; font-weight:bold;">2</span> <span style="color:#800000; font-weight:bold;">3</span> <span style="color:#800000; font-weight:bold;">3</span> <span style="color:#800000; font-weight:bold;">0</span> <span style="color:#800000; font-weight:bold;">SHAPE&lt;&lt;XY</span> <span style="color:#800000; font-weight:bold;">SHAPE&lt;&lt;XY</span> <span style="color:#800000; font-weight:bold;">SHAPE&lt;&lt;XY</span> <span style="color:#800000; font-weight:bold;">SHAPE&lt;&lt;XY</span> <span style="color:#800000; font-weight:bold;">SHAPE&lt;&lt;XY</span>
<span style="color:#800000; font-weight:bold;">3323131211</span> <span style="color:#800000; font-weight:bold;">?S</span>
<span style="color:#3D3D5C; font-weight:bold;">BYE</span>
</pre>
