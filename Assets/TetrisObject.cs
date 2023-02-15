using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TetrisObject : MonoBehaviour
{

    
    public int speed=1;

    public Button right,left,up,down,rotate,rotateZ,rotateY;

    public CubesController controller;

    public List<GameObject> child = new List<GameObject>();
    //private Rigidbody rb;

    public int childsCnt=0;
    

    void Start(){
        
        if(gameObject.name.Contains("x3")){
            
          for(int i=0;i<childsCnt;i++){
              child.Add(gameObject.transform.GetChild(i).gameObject);
          }
        }

        //transform.position=startPosition;
        right.onClick.AddListener(rightMove);
        left.onClick.AddListener(leftMove);
        up.onClick.AddListener(upMove);
        down.onClick.AddListener(downMove);
        rotate.onClick.AddListener(rotateObj);
        rotateZ.onClick.AddListener(rotateObjZ);
        rotateY.onClick.AddListener(rotateObjY);

        //rb = GetComponent<Rigidbody>();
    }

    public void Update(){
        if(speed==1 && controller.speed==1){
            if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
                rightMove();
            }
        }

        if(speed==1 && controller.speed==1){
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
                leftMove();
            }
        }

        if(speed==1 && controller.speed==1){
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
                upMove();
            }
        }

        if(speed==1 && controller.speed==1){
            if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){
                downMove();
            }
        }

        if(speed==1 && controller.speed==1){
            if(Input.GetKeyDown(KeyCode.Space)){
                rotateObject();
            }
        }
        // if(speed==1 && controller.speed==1){
        //     if(Input.GetKey(KeyCode.X)){
        //         rb.AddForce(Vector3.down*100);
        //     }
        // }
    }


    int deg=0;
    void rotateObject(){
        if(deg<3){
            rotateObj();
            deg++;
        }
        else if(deg>=3 && deg<6){
            rotateObjY();
            deg++;
        }
        else if(deg>=6 && deg<9){
            rotateObjZ();
            deg++;
        }
        else{
            deg=0;
        }
    }
    public void rightMove(){
        if(speed==1 && controller.speed==1)transform.position+=new Vector3(0.2f,0,0);
    }
    public void leftMove(){
        if(speed==1 && controller.speed==1)transform.position+=new Vector3(-0.2f,0,0);
    }
    public void upMove(){
        if(speed==1 && controller.speed==1)transform.position+=new Vector3(0,0,0.2f);
    }
    public void downMove(){
        if(speed==1 && controller.speed==1)transform.position+=new Vector3(0,0,-0.2f);
    }

    public void rotateObj(){

        if(speed==1 && controller.speed==1)transform.Rotate(90,0,0);

    }

    public void rotateObjZ(){

        if(speed==1 && controller.speed==1)transform.Rotate(0,0,90);

    }

    public void rotateObjY(){

        if(speed==1 && controller.speed==1)transform.Rotate(0,90,0);

    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.name.Contains("Part")){
            foreach(var a in child){
                if(a==other.gameObject)return;
            }
        }

        if(other.gameObject.tag=="Wall"){
            other.gameObject.GetComponent<AudioSource>().Play();
            controller.speed=0;
        }
        


        if(speed==1){
            controller.createNew();
            speed=0;
            right.onClick.RemoveAllListeners();
            left.onClick.RemoveAllListeners();
            up.onClick.RemoveAllListeners();
            down.onClick.RemoveAllListeners();
            rotate.onClick.RemoveAllListeners();
            rotateY.onClick.RemoveAllListeners();
            rotateZ.onClick.RemoveAllListeners();

            if(gameObject.name.Contains("x3")){
            
              for(int i=0;i<childsCnt;i++){
                gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().castShadows=false;
              }
            }
            else{
                gameObject.GetComponent<MeshRenderer>().castShadows=false;
            }
        }

    }

    
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="RowFinish" ){
            Debug.Log("Row Finish");
            if(speed==0 && !gameObject.name.Contains("Part")){
                if(PlayerPrefs.GetInt("hi")<PlayerPrefs.GetInt("CurrentScore")){
                    PlayerPrefs.SetInt("hi",PlayerPrefs.GetInt("CurrentScore"));
                }
                other.gameObject.GetComponent<AudioSource>().Play();
                controller.speed=0;
            }
        }
        else if(other.tag=="Wall"){
            other.gameObject.GetComponent<AudioSource>().Play();
            controller.speed=0;
        }
        else{
        
        if(!gameObject.name.Contains("x3") || other.gameObject.tag=="Row")return;

        

        foreach(var a in child){
            if(a==other.gameObject)return;
        }


        if(speed==1){
            controller.createNew();
            speed=0;
            right.onClick.RemoveAllListeners();
            left.onClick.RemoveAllListeners();
            up.onClick.RemoveAllListeners();
            down.onClick.RemoveAllListeners();
            rotate.onClick.RemoveAllListeners();

            if(gameObject.name.Contains("x3")){
            
              for(int i=0;i<childsCnt;i++){
                gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().castShadows=false;
              }
            }
            else{
                gameObject.GetComponent<MeshRenderer>().castShadows=false;
            }
        }
        }

        
    }

     void OnTriggerStay(Collider other){
         if(other.gameObject.tag=="RowFinish" ){
             Debug.Log("Row Finish");
             if(speed==0 && !gameObject.name.Contains("Part")){
                 controller.speed=0;
                 other.gameObject.GetComponent<AudioSource>().Play();
             }
         }
     }

    // void createNew(){
    //     var obj = Instantiate(gameObject,startPosition,Quaternion.identity) as GameObject;
    //     TetrisObject tetrisObj = obj.GetComponent<TetrisObject>();
    // }


    




}
