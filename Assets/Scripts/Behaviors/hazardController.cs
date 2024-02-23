using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazardController : MonoBehaviour
{
    public GameObject GameOver;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Ha, you are dead!");
            GameOver.SetActive(true);
            Time.timeScale = 0;

        }
    }
   
}
