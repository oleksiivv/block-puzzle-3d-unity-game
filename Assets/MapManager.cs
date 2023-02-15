using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] standartMap;
    public GameObject[] forestMap;

    public GameObject[] streetMap;

    public GameObject[] christmasMap;
    void Start()
    {

        int n=PlayerPrefs.GetInt("currentMap");

        // foreach(var a in forestMap)a.SetActive(false);
        //     foreach(var a in streetMap)a.SetActive(false);
        //     foreach(var a in christmasMap)a.SetActive(false);
        //     foreach(var a in standartMap)a.SetActive(false);

        if(n==0){
            foreach(var a in forestMap)a.SetActive(false);
            foreach(var a in streetMap)a.SetActive(false);
            foreach(var a in christmasMap)a.SetActive(false);
        }

        else if(n==1){
            foreach(var a in forestMap)a.SetActive(true);

            foreach(var a in standartMap)a.SetActive(false);
            foreach(var a in streetMap)a.SetActive(false);
            foreach(var a in christmasMap)a.SetActive(false);
        }

        else if(n==2){
            foreach(var a in streetMap)a.SetActive(true);

            foreach(var a in forestMap)a.SetActive(false);
            foreach(var a in standartMap)a.SetActive(false);
            foreach(var a in christmasMap)a.SetActive(false);
        }

        else if(n==3){
            foreach(var a in christmasMap)a.SetActive(true);

            foreach(var a in forestMap)a.SetActive(false);
            foreach(var a in standartMap)a.SetActive(false);
            foreach(var a in streetMap)a.SetActive(false);
        }
        
        
    }

    
}
