using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject hiPanel;
    public Text best;

    public GameObject rateBox;
    public static int opened=0;

    void Start(){
        if(PlayerPrefs.GetInt("hi")!=0){
            hiPanel.SetActive(true);
            best.text="HI: "+PlayerPrefs.GetInt("hi").ToString();
        }
        else{
            hiPanel.SetActive(false);
        }

        if(opened==2 && PlayerPrefs.GetInt("rated")==0){
            //rateBox.SetActive(true);
        }

        opened++;

        rateBox.SetActive(false);
    }


    public void RateNow(){
        rateBox.SetActive(false);
        PlayerPrefs.SetInt("rated",1);
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.VertexStudioGames.Block3D");
    }

    public void rateLater(){
        rateBox.SetActive(false);
        opened=10;
    }

    public void newerLate(){

        rateBox.SetActive(false);
        PlayerPrefs.SetInt("rated",1);

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
            Debug.Log(progress);
            yield return null;

        }
    }

}
