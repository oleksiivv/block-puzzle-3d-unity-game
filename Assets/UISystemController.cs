using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystemController : MonoBehaviour
{
    public GameObject[] icons;

    public GameObject[] coord;
    void Start()
    {
        if(PlayerPrefs.GetInt("coord")==0){

            foreach(var c in coord){
                c.SetActive(false);
            }

            foreach(var i in icons){
                i.SetActive(true);
            }


        }
        else{

            foreach(var c in coord){
                c.SetActive(true);
            }

            foreach(var i in icons){
                i.SetActive(false);
            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
