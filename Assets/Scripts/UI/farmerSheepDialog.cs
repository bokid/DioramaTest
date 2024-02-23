using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class farmerSheepDialog : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool dialogActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            print("Player in range");
        }
    }

    void onTriggerExit(Collider other)
    {
        if (other.tag == ("Player"))
        {
            print("Player left range");
        }
    }
}
