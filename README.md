# **Smoke Rings**
##A program to draw Smoke Rings in C# and evolve them over time.

This program was developed as part of my Msc thesis. The goal of the program was to do exactly what it says on the tin, draw and evolve smoke rings.

Smoke rings are closed curves which evolve according to the vortex filament equation. These curves are defined by a function called the curvature function. To put it simply, this function defines the shape that the curve makes in space.

The program is a windows forms application written in C#. It allows the user to either input a curvature function using a calculator style input or choose from seven preset functions. Once the selection has been made, the program draws the curve and then evolves it according to the vortex filament equation.

##Problems to be fixed

While this is a moderately working program there are a few problems that still need to be fixed.

 1. ***Mathematica* integration**
	 Currently *Mathematica* is used for input and initial drawing of the curve. This is less than ideal as you need to have the *Mathematica* kernel installed and also the processing is slowed down drastically by this.
	 My reasoning for doing this at the time was that the user should be able to use this program to analyze any curve not just those that were hard-coded as test functions. 
	 Implementing this in C# is technically possible using a binary tree of delegates but due to the time constraints of the project I have not yet been able to do this as yet.
	 
 2.   **Drawing Function**
    Related to the first point, this also has to do with the drawing of the initial curve. The function at the moment in C# uses the differential form of the curve equation rather than the integral form.
    Unfortunately the differential system is a special one called a stiff system which means that it can't be solved easily using the standard differential solvers.
    The integral system doesn't have this problem and should be used instead. The *Mathematica* implementation doesn't have this problem as it uses the integral system.
