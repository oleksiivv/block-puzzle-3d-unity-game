using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject buttonMuted, buttonNormal;

    public Dropdown quality;
    void Start()
    {
        //PlayerPrefs.SetInt("hi",6000);
        quality.GetComponent<Dropdown>().value=QualitySettings.GetQualityLevel();
        if(PlayerPrefs.GetInt("!sound")==0){

            buttonMuted.SetActive(false);
            buttonNormal.SetActive(true);

        }
        else{
            buttonMuted.SetActive(true);
            buttonNormal.SetActive(false);
        }
        
    }

    public void mute(){
        PlayerPrefs.SetInt("!sound",1);
        buttonMuted.SetActive(true);
        buttonNormal.SetActive(false);
        GetComponent<AudioSource>().enabled=false;
        
    }

    public void unmute(){
        PlayerPrefs.SetInt("!sound",0);
        buttonMuted.SetActive(false);
        buttonNormal.SetActive(true);

        GetComponent<AudioSource>().enabled=true;

        

    }


    public void openScene(int id){

        StartCoroutine(loadAsync(id));

    }


    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
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
