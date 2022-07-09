# Play-with-Graphics-and-Fractals

C# version of almost all the program examples from prof. Hans Lauwerier's book "Spelen met Graphics en Fractals" from 1994.

The programs are published on a 3.5" diskette  "© H.Lauwerier, 1994 ISBN 90 395 0092 4". Prof. Lauwerier died many years ago, the publisher "Academic Services" apparently no longer exists, or else I am unable to find them on the internet. For this project I claim the "fair use" right to use the source as a base on which I develloped my version of the programs. If a copyright holder exists, please contact me to allow this pubblication or to remove it, as requested. At the time of uploading this project a pdf version of the book (in Dutch) was available on https://ia902908.us.archive.org/30/items/spelenmetgraphicsenfractalshanslauwerier1994/Spelen%20met%20Graphics%20en%20Fractals%20-%20Hans%20Lauwerier%20-%201994.pdf



The project is actually for Visual Studio 2019.
It consists of 
* 1 module (pc,cs) with a form and a picturebox, that displays the graphics created by the various programs. This module selects a GWBasic program, one at a time;
* 1 module (gw.cs), that contains the C# code to implement the GWbasic functions such as WINDOW, LINE, PSET, CLS, PRINT, etc, so stay as close as possible to the basic source;
* 1 module for each of the 80 programs that Prof Lauwerier created and explained in the book. 

I omited the programs to introduce you to GWbasic on a 8088 or 80286.
I also omitted the programs about Conway's "game of life" for which there exist too many copies on the internet already.

To understand the programs, you will have to read the book. It explains how functions are used, and which parameters are chosen as the are. 

A DIR-list of the diskette and what I did with it.
* 12/10/1993  17:26 ANIMA.BAS    omitted, computer animation, GET and PUT non implemented
* 17/01/1994  14:37 ARTBLOK.BAS  pattern of colored block that changes continuously
* 21/01/1994  17:04 ARTBLOKQ.BAS omitted, PALETTE not implemented
* 15/01/1994  17:40 ASCPRINT.BAS omitted,to explain GWBASIC
* 15/01/1994  17:49 ASCRIJ.BAS   omitted,to explain GWBASIC
* 24/12/1993  19:08 ASTROIDE.BAS moving line to create an envelope
* 09/10/1993  01:16 BLAD.BAS     Fractal of a leaf
* 15/01/1994  17:03 CAUSTIC.BAS  reflection in a caustic mirror
* 24/12/1993  19:02 CIRKELB.BAS  compound circular motion
* 18/01/1994  12:16 CONWAY1.BAS  omitted, exists on internet
* 14/03/1994  13:45 CONWAY2.BAS  omitted
* 13/10/1993  19:07 CONWAYR.BAS  omitted
* 27/12/1993  14:39 CONWAYS.BAS  omitted
* 15/10/1993  12:00 CYCLO1.BAS   cycloid curve
* 21/01/1994  17:05 CYCLO2.BAS   cycloid curve, Steiner's hypercycliod
* 17/01/1994  16:34 DYNSYSX1.BAS Peitgen's dynamic system, explosion
* 17/01/1994  16:36 DYNSYSX2.BAS Peitgen's chaotic trace
* 21/01/1994  17:05 EGACOL1.BAS  omitted,to explain GWBASIC
* 21/01/1994  17:05 EGACOL2.BAS  omitted,to explain GWBASIC
* 15/01/1994  16:49 FOURIER.BAS  Fourier approximation of a sawtooth
* 08/10/1993  19:40 FRACMC1.BAS  Fractal of 2 rotations
* 08/10/1993  19:43 FRACMC2.BAS  Fractal of 2 rotations, shrinking
* 08/10/1993  19:49 FRACMC3.BAS  Fractal of 2 rotations, shrinking spiral
* 08/10/1993  19:53 FRACMC4.BAS  Fractal of 2 mirrorings
* 15/10/1993  01:33 FRACMC5.BAS  Triangle sieve of Sierpinski
* 17/01/1994  13:56 FRACMC6.BAS  Colored triangle sieve of Sierpinski
* 17/01/1994  13:35 FRACMC7.BAS  Squared sieve of Sierpinski
* 17/01/1994  16:30 GROEIM1.BAS  atracting growing population model
* 17/10/1993  00:45 GROEIM2.BAS  Colored atracting growing population model
* 14/10/1993  16:16 HENON1.BAS   Henon's quadratic system
* 20/11/1993  17:15 HENON2.BAS   Chaotic Henon system
* 14/03/1994  13:47 JULBSC.BAS   Julia set, Douady's rabbit  
* 14/03/1994  13:47 JULDIST.BAS  Julia set with distance calculation
* 13/10/1993  23:27 JULFILL.BAS  Julia set z * z + c, colored enclosed area
* 14/03/1994  14:02 JULFILLX.BAS Julia set z * z + c, 8 examples
* 13/10/1993  19:45 JULIAMC.BAS  Julia set, Monte Carlo method 
* 20/11/1993  15:59 JULIAP.BAS   quadratic Julia set for -.55
* 15/11/1993  20:12 JULIAPX.BAS  quadratic Julia set 6 examples
* 19/01/1994  18:31 JULIAT.BAS   tiles with Julia sets
* 16/01/1994  16:47 KALEIDO.BAS   kaleidoscopic colored lines
* 07/10/1993  19:20 KANT.BAS      regular polygon with all diagonals
* 15/01/1994  22:48 KATTEN.BAS    a tile wall of cats in the M.C. Escher way
* 20/11/1993  18:43 LISSA.BAS     harmonic movement of Lissajous
* 15/01/1994  16:52 LISSAV.BAS    goniometric harmonic movements of Lissajous
* 21/01/1994  17:07 LISSAX.BAS    3 harmonic movements of Lissajous
* 14/03/1994  13:48 MANDELX1.BAS  basic Mandelbrot set in colors
* 14/03/1994  13:49 MANDELX2.BAS  Mandelbrot set of sinus function
* 14/03/1994  13:49 MANDELX3.BAS  Mandelbrot set quartet
* 14/03/1994  13:50 MANDET.BAS    omitted, unclear how it produces results
* 14/03/1994  13:50 MANDIST.BAS   Mandelbrot set using distance calculation
* 14/03/1994  13:50 MANDISTM.BAS  omitted, same as X1
* 17/01/1994  16:38 MIRADSX1.BAS  Christian Mira's model in 0.3
* 17/01/1994  16:44 MIRADSX2.BAS  Christian Mira's model in 0.3 0.5 or 0.18
* 17/10/1993  01:13 MIRAMUS.BAS   omitted, PLAY not implemented
* 15/01/1994  22:41 MIXER.BAS     omitted, PALETTE not implemented
* 21/01/1994  16:59 MZOOML.BAS    Mandelbrot set with zooming
* 15/10/1993  12:42 OMHUL.BAS     rotating a line of given length over a Lissajoux
* 20/11/1993  17:27 PATROON1.BAS  symetric patterns
* 17/01/1994  00:58 PATROON2.BAS  tiling a floor
* 20/11/1993  17:31 PATROON3.BAS  cross stitching pattern
* 26/10/1993  13:19 PATROON4.BAS  pattern of coloured block
* 17/01/1994  13:39 SQUAREF.BAS   fractal of squares in a square
* 20/11/1993  18:45 STARMOVE.BAS  omitted, computer animation, GET and PUT non implemented
* 21/01/1994  17:08 STEMPEL.BAS   stamping a simple motive
* 21/01/1994  17:09 STEMPELX.BAS  omitted, equal to previous one.
* 15/01/1994  22:56 STERPQ.BAS    star form polygon with diagonals
* 26/10/1993  18:00 TRUCHET.BAS   stamping a Truchet figure
* 07/10/1993  19:45 TURNLINE.BAS  rotating a line of given length, 3 in one figure
* 21/01/1994  17:09 TURTLE.BAS    basic turlte with manual path 
* 11/11/1993  16:18 TURTLEA.BAS   Mandelbrot's archipel
* 25/12/1993  15:55 TURTLEK.BAS   Koch's line
* 18/01/1994  12:44 TURTLEK1.BAS  quadratic approximation of a Koch line 
* 18/01/1994  12:43 TURTLEK2.BAS  Koch's snowflake
* 09/11/1993  12:18 TURTLEK3.BAS  Tile with Koch's line
* 10/11/1993  18:32 TURTLEK4.BAS  Tiled wall of Kochs' tiles
* 28/10/1993  01:06 TURTLEM.BAS   Kinkowski's line
* 13/08/1992  12:34 TURTLES.BAS   Sierpinski's square
* 09/10/1993  01:09 VAREN.BAS     Fractal of a fern
* 14/10/1993  20:07 WEB.BAS       web of lines
* 16/01/1994  16:30 WERVEL.BAS    expanding square travelling on a circle
* 16/01/1994  15:11 WOORD.BAS     omitted,,to explain GWBASIC


