using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class handles light rotation
public class DirectionalLightPosition : MonoBehaviour
{
    //Unity slider holding light direction value
    public Slider directionalLight;
    //Unity text holder displaying rotation value
    public Text directionalLightText;
 
    // Update is called once per frame
    void Update(){
        //Set the slider text to the slider value
        directionalLightText.text = directionalLight.value.ToString();
        //Create a new xyz vector coordinate, set y to slider value
        Vector3 directionValue = new Vector3(directionalLight.value, 0, 0);
        //Set the rotation transformation with the Quarternion Euler value of the direction value
        //This essentially makes it so that the rotation value is not applied constantly, but only by the set value
        transform.rotation = Quaternion.Euler(directionValue);
    } 
}
