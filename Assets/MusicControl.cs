using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class handles background Minecraft music
public class MusicControl : MonoBehaviour
{
    //MusicControl object
    public static MusicControl music; 

    private void Awake() 
    {
        //Set this object to never be destroyed on defalt
        DontDestroyOnLoad(this.gameObject); 

        //If there is no instanced music currently playing
        if (music == null) 
        {
            //Set music instance
            music = this; 
        }
        //If there is instanced music currently playing
        else 
        {
            //Destroy the music
            Destroy(gameObject); 
        }
    }
}

