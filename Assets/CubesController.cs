using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Advertisements;

public class CubesController : MonoBehaviour
{
#if UNITY_IOS
    public string gameId="3987840";
#else
    public string gameId="3987841";
#endif

    public Button right,left,up,down,rotate,rotateZ,rotateY;
    public Button rotateXCoord,rotateZCoord,rotateYCoord;

    public GameObject[] cubes;
    public int speed=1;

    public GameObject diePanel,pausePanel;

    public Text score;
    
    public Text hi,newHiAlert;

    bool run=true;
    private int startedHi;

    public AdmobMainScene admob;

    void Start(){
        Advertisement.Initialize(gameId,false);
        startedHi=PlayerPrefs.GetInt("hi");
        StartCoroutine(scoreInc());
    }

bool showed=false;
    IEnumerator scoreInc(){
        while(true){
            if(speed>0 && Time.timeScale!=0){
                PlayerPrefs.SetInt("CurrentScore",PlayerPrefs.GetInt("CurrentScore")+1);
                score.text="Score "+PlayerPrefs.GetInt("CurrentScore").ToString();
                hi.text="HI "+PlayerPrefs.GetInt("hi").ToString();
            }

            if(PlayerPrefs.GetInt("CurrentScore")>PlayerPrefs.GetInt("hi") ){

                
                // if(!showed && PlayerPrefs.GetInt("hi")==startedHi){
                //      newHiAlert.gameObject.SetActive(true);
                //      Invoke("stopAnimNewHi",3f);
                //      showed=true;
                //  }

                 PlayerPrefs.SetInt("hi",PlayerPrefs.GetInt("CurrentScore"));
                
                


            }

            yield return new WaitForSeconds(0.75f);
        }
    }


    void stopAnimNewHi(){
        newHiAlert.gameObject.SetActive(false);
    }


    public void loadScene(int id){

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

bool addShowed=false;
    void Update(){
        

        

        if(speed==0 && diePanel.activeSelf==false){

            

             diePanel.SetActive(true);
             
        }

        if(speed==0 && !addShowed){

             if(Advertisement.IsReady("video")){
                  Advertisement.Show("video");
                  addShowed=true;
               }
               else{
                   admob.showIntersitionalAd();
                   addShowed=true;
               }

        }
    }

    public GameObject pauseBg;
    public void pause(){

         if(Advertisement.IsReady("video")){
              Advertisement.Show("video");
         }
          else{
                   admob.showIntersitionalAd();
               }

        Time.timeScale=0;

        run=false;
        pausePanel.SetActive(true);
        pauseBg.SetActive(true);


    }


    public void resume(){

        Time.timeScale=1;

        run=true;
        pausePanel.SetActive(false);
        pauseBg.SetActive(false);
    }

    public void createNew(){
        if(speed==0){
            diePanel.SetActive(true);
            return;
        }
        int id=Random.Range(0,cubes.Length);
        var obj = Instantiate(cubes[id],cubes[id].transform.position,Quaternion.identity) as GameObject;
        TetrisObject tetrisObj = obj.GetComponent<TetrisObject>();
        tetrisObj.controller=GetComponent<CubesController>();

        tetrisObj.right=right;
        tetrisObj.left=left;
        tetrisObj.up=up;
        tetrisObj.down=down;
        if(PlayerPrefs.GetInt("coord")==0){
            tetrisObj.rotate=rotate;
            tetrisObj.rotateZ=rotateZ;
            tetrisObj.rotateY=rotateY;
        }
        else{
            tetrisObj.rotate=rotateXCoord;
            tetrisObj.rotateZ=rotateZCoord;
            tetrisObj.rotateY=rotateYCoord;

        }

    }
}
