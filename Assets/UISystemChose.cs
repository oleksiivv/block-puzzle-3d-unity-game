using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystemChose : MonoBehaviour
{
    public Image typeIcons;
    public GameObject arrowIcons;

    public Image typeCoord;
    public GameObject arrowCoord;

    public Color32 choosen,normal;

    void Start(){
        int id=PlayerPrefs.GetInt("coord");
        if(id==0){
            typeIcons.GetComponent<Image>().color=choosen;
            typeCoord.GetComponent<Image>().color=normal;

            arrowIcons.SetActive(true);
            arrowCoord.SetActive(false);
        }
        else{
            typeCoord.GetComponent<Image>().color=choosen;
            typeIcons.GetComponent<Image>().color=normal;

            arrowCoord.SetActive(true);
            arrowIcons.SetActive(false);
        }
    }
    

    public void choose(int id){
        PlayerPrefs.SetInt("coord",id);

        if(id==0){
            typeIcons.GetComponent<Image>().color=choosen;
            typeCoord.GetComponent<Image>().color=normal;

            arrowIcons.SetActive(true);
            arrowCoord.SetActive(false);
        }
        else{
            typeCoord.GetComponent<Image>().color=choosen;
            typeIcons.GetComponent<Image>().color=normal;

            arrowCoord.SetActive(true);
            arrowIcons.SetActive(false);
        }
    }
}
