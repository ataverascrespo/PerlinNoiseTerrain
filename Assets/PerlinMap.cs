using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class handles creation of Minecraft-inspired terrain
public class PerlinMap : MonoBehaviour
{
    //Cube game object
    public GameObject Block;
    //List of cube game objects
    private List<GameObject> blockList = new List<GameObject>();
    //Sliders holding the value of different map variables
    public Slider xSize, zSize, perlinScale, perlinFrequency, xOffset, zOffset;
    //Text objects displaying the values of map sliders
    public Text xSizeText, zSizeText, perlinScaleText, perlinFrequencyText, xOffsetText, zOffsetText;

    //Method generates and returns a xyz vector based on map size, perlin frequency, x and z offset and perlin scale
    private Vector3 GeneratePerlinTerrain(int x, int z, int xSize, int zSize){
        //Calculate noise on the x axis
        float xNoise = (float)x / xSize * perlinFrequency.value + xOffset.value;
        //Calculate noise on the z axis
        float zNoise = (float)z / zSize * perlinFrequency.value + zOffset.value;
       
        //Calculate the 2D perlin noise using x and z noise parameters, and multiply the perlinScale value 
        float perlinNoise = Mathf.PerlinNoise(xNoise, zNoise) * perlinScale.value;
        
        //The calculated perlin noise is returned in the y co-ordinate because it becomes the height map for our 3D terrain
        //Essentially, x and z are determined at Start(), so the perlin noise that is generated must be calculated for the y value...
        //...as this determines the positions of where the blocks get instantiated
        return new Vector3(x, perlinNoise, z);
    }

    // Start is called before the first frame update
    void Start() {
        //Loop through map width
        for (int x = 0; x < xSize.value; x++) {
            //Loop through map depth
            for (int y = 0; y < zSize.value; y++) {
                //Calculate a new vector calling generatePerlinTerrain(
                //x and y = map width and size (does not change)
                //xSize and ySize = function as perlin wavelength
                Vector3 blockHeightMap = GeneratePerlinTerrain(x, y, (int)xSize.value, (int)zSize.value);
                //Instantiate a new Block object, and add it to the list of blocks
                blockList.Add(Instantiate(Block, blockHeightMap, Quaternion.identity, transform));
            }
        }
    }

    // Update is called once per frame
    void Update() {
        //Update the displayed slider values for all sliders
        xSizeText.text = xSize.value.ToString();
        zSizeText.text = zSize.value.ToString();
        perlinScaleText.text = perlinScale.value.ToString();
        perlinFrequencyText.text = perlinFrequency.value.ToString();
        xOffsetText.text = xOffset.value.ToString();
        zOffsetText.text = zOffset.value.ToString();

        //Loop through every block in the list
        foreach (GameObject block in blockList) {
            //Re-generate the calculated perlin noise for each block, and transform it with that new calculated vector
            block.transform.localPosition =  GeneratePerlinTerrain(
                                                            (int)block.transform.localPosition.x, 
                                                            (int)block.transform.localPosition.z, 
                                                            (int)xSize.value, 
                                                            (int)zSize.value);
            //Call function to determine map colour
            setColour(block);
        }
    }

    //Determine colour of instantianted block
    void setColour(GameObject block){
        //Water colour
        Color water = new Color(0.02353f,  0.22353f,  0.43922f);
        //Sand colour
        Color sand = new Color(0.96471f, 0.80784f, 0.61569f);
        //Grass colour
        Color grass = new Color(0.12549f,  0.28627f,  0.16078f);
        //Stone colour
        Color stone = new Color(0.75f, 0.75f, 0.75f);
          
        //This is going to be simulated somewhat like Minecraft (loosely, as in without the random block generations)
        //If the y position of the placed block is below y=13, it is a water block
        if (block.transform.position.y < 13){
            block.GetComponent<Renderer>().material.SetColor("_Color", water);
        }
        //If the y position of the placed block is between 13 and 15, it is a sand block adjacent to water
        else if (block.transform.position.y >= 13 && block.transform.position.y < 15){
            block.GetComponent<Renderer>().material.SetColor("_Color", sand);
        }
        //If the y position of the placed block is between 15 and 25, it is a grass block, which mainly comprises Minecraft's hills
        else if (block.transform.position.y >= 15 && block.transform.position.y < 25){
            block.GetComponent<Renderer>().material.SetColor("_Color", grass);
        }
        //If the y position of the placed block is 25 or higher, it is a stone peak on top of the hills
        else if (block.transform.position.y >= 25){
            block.GetComponent<Renderer>().material.SetColor("_Color", stone);
        }
    }

}
