using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCubePos : MonoBehaviour
{
    public TetrisObject parent;
    private bool isFallen=false;
    // Start is called before the first frame update
     void Start()
     {
         parent=GetComponentInParent<TetrisObject>();
     }
    // void Update(){
    //     Debug.Log(parent.speed);

    //     if(parent.speed==0 &&!isFallen){

    //         GetComponent<Rigidbody>().velocity=Vector3.up*-2;
    //         Invoke("stopFall",3);

    //     }

    // }

    // void stopFall(){

    //     isFallen=true;

    // }
}
