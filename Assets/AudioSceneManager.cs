using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSceneManager : MonoBehaviour
{
    public GameObject[] audioSources;
    void Start()
    {

        foreach(var source in audioSources){
            if(PlayerPrefs.GetInt("!sound")==0){

                source.GetComponent<AudioSource>().enabled=true;

            }
            else{
                source.GetComponent<AudioSource>().enabled=false;
            }
        }
        
    }

}
