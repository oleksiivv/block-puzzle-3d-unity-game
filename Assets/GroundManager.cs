using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public CubesController controller;

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="TetrisObject"){
            gameObject.GetComponent<AudioSource>().Play();
            controller.speed=0;
        }
        
    }
}
