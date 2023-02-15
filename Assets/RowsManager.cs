using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowsManager : MonoBehaviour
{
    public Row[] rows;
    public GameObject[] tableRow;

    public int current=-1;

    public Text currentRow;
    public GameObject table;
    void Start()
    {
        Time.timeScale=1;
        
        foreach(var row in tableRow){

            row.SetActive(false);

        }

        currentRow.gameObject.SetActive(false);
        table.SetActive(false);

                PlayerPrefs.SetInt("CurrentScore",0);

        
    }

    int i=0;
    // Update is called once per frame
    public void change(){

        currentRow.gameObject.SetActive(true);
        table.SetActive(true);
        
        foreach(var row in tableRow){

            row.SetActive(false);

            

        }

        int j=-1;

        for(i=rows.Length-1;i>=0;i--){

            if(rows[i].current>0){
                if(j==-1)j=i;
                tableRow[i].SetActive(true);
                //break;
            }

        }


        currentRow.text="You are on row "+(j+1).ToString()+" now";
        
    }
}
