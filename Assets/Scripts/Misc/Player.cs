﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    private void onTriggerEnter(Collider collision)
        {
            print("Colliding!");
        }
}
