using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Row : MonoBehaviour
{
    public List<GameObject> items= new List<GameObject>();
    public int maxCount=10;
    public int current=0;

    public int currentRow=0;

    public Text addPointsAlert;

    void Start()
    {
        
    }

    
    void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag=="TetrisObject"){
            // if(other.gameObject.name.Contains("Part")){

            //     if(other.gameObject.GetComponentInParent<TetrisObject>().speed==0){

            //         current++;
            //         items.Add(other.gameObject);

            //     }

            // }
            // else{
            //     if(other.gameObject.GetComponent<TetrisObject>().speed==0){
            //         current++;
            //         items.Add(other.gameObject);
            //     }
                
            // }

            current++;
            items.Add(other.gameObject);

            if(current==maxCount){
                
                Invoke("cleanRow",0.5f);
            }



            transform.parent.gameObject.GetComponent<RowsManager>().change();

        }

        
    }


    // void OnTriggerStay(Collider other){
    //     if(current==maxCount){
                
    //         Invoke("cleanRow",0.5f);
    //     }
    // }

    void cleanRow(){
        if(current<maxCount){return;}

        gameObject.GetComponent<AudioSource>().Play();
        
        addPointsAlert.text="+1000";
        addPointsAlert.gameObject.SetActive(true);
        Invoke("cleanAlert",1.5f);
        PlayerPrefs.SetInt("CurrentScore",PlayerPrefs.GetInt("CurrentScore")+1000);
        foreach(var item in items){
            Destroy(item.gameObject);
        }
        items.Clear();
        current=0;
    }


    void cleanAlert(){
        addPointsAlert.text="";
        addPointsAlert.gameObject.SetActive(false);
    }

    void OnTriggerExit(Collider other)
    {

        if(other.gameObject.tag=="TetrisObject"){
            current--;
            items.Remove(other.gameObject);

            transform.parent.gameObject.GetComponent<RowsManager>().change();
        }

        

        
    }
}
