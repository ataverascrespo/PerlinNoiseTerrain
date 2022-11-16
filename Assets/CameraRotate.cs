using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class handles rotation of the camera over a fixed point
public class CameraRotate : MonoBehaviour
{
    //Unity slider holding rotation value
    public Slider mapRotate;
    //Unity text holder displaying rotation value
    public Text mapRotateText;
 
    // Update is called once per frame
    void Update(){
        //Set the slider text to the slider value
        mapRotateText.text = mapRotate.value.ToString();
        //Create a new xyz vector coordinate, set y to slider value
        Vector3 rotateValue = new Vector3(0, mapRotate.value, 0);
        //Transform the GameObject * 60fps (delta time of the program is every frame)
        transform.Rotate(rotateValue * Time.deltaTime);
    }
}
