# Perlin Noise Terrain
Developed as an end-of-course project for my Computer Graphics course. 

A small program showing the usage of the Perlin Noise algorithm, applied to Unity Cube objects, which allow the user to generate and manipulate a Minecraft-style terrain with mountains, valleys, and water bodies. 

![My Image](images/MainUI.jpg)

For this project, I chose to make a very basic replication of Minecraft-style terrain generation using the Perlin Noise algorithm. Developed by Ken Perlin in 1983 for CGI use on Tron (won an Academy Award for it too), Perlin Noise creates a plane of pseudo-randomized floating point numbers. Perlin Noise’s pseudo-random generation ensures that two neighbouring points will have logical, gradual transitions between them (unlike randomly generated noise values). That’s why most games with procedural generation (including Minecraft) will use Perlin Noise, or some derivative of it like Simplex Noise, to create terrain. 

To create the terrain, a grid of blocks spanning the x and z planes has a Perlin Noise value calculated for each row and column. This Perlin Noise value is applied to a xyz vector in the y-coordinate, and each instantiated block has this transformation vector applied. Essentially, every individual row (x) has a wavelength that is gradually consistent with neighbouring rows. Every individual column (z) has a wavelength that is gradually consistent with neighbouring columns. Every row and column is gradually consistent with each other.  This creates the illusion of a 3D Perlin Noise heightmap, when in reality it is a 2D grid where the y-axis is elevated with transformations based on calculated Perlin Noise. This isn’t how Minecraft does it, but it creates a somewhat reminiscent effect (not so much anymore, Minecraft has improved their Perlin Noise algorithms to have more dramatic height maps). 

Within the program:
The Rotate Angle slider controls the angle of rotation around the terrain.
The Perlin Scale slider controls the height of the calculated noise wavelengths.
The Perlin Frequency slider controls the number of noise wavelengths.
The X Size slider controls the width of the calculated noise wavelengths.
The Z Size slider controls the depth of the calculated noise wavelengths.
The X Offset slider controls x-axis ‘navigation’ of the terrain. 
The Z Offset slider controls the z-axis ‘navigation’ of the terrain. 
The Light Direction slider controls the angle of rotation of the lighting on the x-axis.

There is also background music, a song titled Aria Math produced by C418 exclusively for Minecraft.
