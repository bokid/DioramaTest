using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    // Start is called before the first frame update
    private float vertInput;
    private float horInput;
    private Rigidbody plane;
    public float rotationMult;
    private string hello = "This is my message";
    
    void Start()
    {
        plane = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        vertInput = UnityEngine.Input.GetAxisRaw("Vertical");
        print(hello);
        print(vertInput);

        transform.rotation = Quaternion.Euler(vertInput * rotationMult, 0f, horInput * rotationMult);
        

    }
}
