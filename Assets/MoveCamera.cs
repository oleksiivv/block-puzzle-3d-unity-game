﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //public Vector3 startPosition;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*1/10);
        transform.Translate(Vector3.right*-1/10);
    }
}
