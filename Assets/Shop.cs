using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] closed;
    public Image[] items;
    public Text[] chooseOrCurrent;

    public GameObject[] btnChoose;

    public Text currentHI;
    void Start()
    {
        
        currentHI.text="Current hi: "+PlayerPrefs.GetInt("hi").ToString();
        //PlayerPrefs.SetInt("hi",6000);

        
        if(PlayerPrefs.GetInt("hi")>=1000){
            closed[1].SetActive(false);
        }
        else{
            closed[1].SetActive(true);
        }

        if(PlayerPrefs.GetInt("hi")>=3000){
            closed[2].SetActive(false);
        }
        else{
            closed[2].SetActive(true);
        }

        if(PlayerPrefs.GetInt("hi")>=5000){
            closed[3].SetActive(false);
        }
        else{
            closed[3].SetActive(true);
        }

        choose(PlayerPrefs.GetInt("currentMap"));

        
    }


    public void choose(int id){
        for(int i=0;i<chooseOrCurrent.Length;i++){

            items[i].GetComponent<Image>().color=new Color32(2,2,46,255);

            if(closed[i].activeSelf==false){

                chooseOrCurrent[i].text="Available";
                btnChoose[i].SetActive(true);

            }
            else{
                chooseOrCurrent[i].text="";
                btnChoose[i].SetActive(false);
            }

        }

        chooseOrCurrent[id].text="Current";
        items[id].GetComponent<Image>().color=new Color32(17,150,3,255);

        PlayerPrefs.SetInt("currentMap",id);
        btnChoose[id].SetActive(false);



    }


    public void openScene(int id){

        StartCoroutine(loadAsync(id));

    }
    public GameObject loadingPanel;
    public Slider loadingSlider;

    IEnumerator loadAsync(int id)
    {
        AsyncOperation operation = Application.LoadLevelAsync(id);
        loadingPanel.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingSlider.value = progress;
            yield return null;

        }
    }

    
}
