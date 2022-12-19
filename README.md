# Perlin Noise Minecraft Sim
A fully functional WebGL build of the project can be accessed at https://ataverascrespo.itch.io/minecraft-perlin-noise. 

Developed as an end-of-course project for my Computer Graphics course. 

A small program showing the usage of the Perlin Noise algorithm, applied to Unity Cube objects, which allow the user to generate and manipulate a Minecraft-style terrain with mountains, valleys, and water bodies. 

To create the terrain, a grid of blocks spanning the x and z planes has a Perlin Noise value calculated for each row and column. This Perlin Noise value is applied to a xyz vector in the y-coordinate, and each instantiated block has this transformation vector applied. 

Essentially, every individual row (x) has a wavelength that is gradually consistent with neighbouring rows. Every individual column (z) has a wavelength that is gradually consistent with neighbouring columns. Every row and column is gradually consistent with each other.  This creates the illusion of a 3D Perlin Noise heightmap, when in reality it is a 2D grid where the y-axis is elevated with transformations based on calculated Perlin Noise. 

Within the program:
* The Rotate Angle slider controls the angle of rotation around the terrain.
* The Perlin Scale slider controls the height of the calculated noise wavelengths.
* The Perlin Frequency slider controls the number of noise wavelengths.
* The Map Width slider controls the width of the calculated noise wavelengths.
* The Map Depth slider controls the depth of the calculated noise wavelengths.
* The Width Offset slider controls x-axis ‘navigation’ of the terrain. 
* The Depth Offset slider controls the z-axis ‘navigation’ of the terrain. 
* The Light Position slider controls the angle of rotation of the lighting on the x-axis.

There is also background music, a song titled Aria Math produced by C418 exclusively for Minecraft.
