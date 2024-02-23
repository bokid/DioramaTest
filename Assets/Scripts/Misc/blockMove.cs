using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockMove : MonoBehaviour
{
    private float horInput;
    private float vertInput;
    public float speed;
    public CharacterController controller;
    //Vector3 velocity;
    private Rigidbody cube;
    // Start is called before the first frame update
    void Start()
    {
        cube = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        vertInput = UnityEngine.Input.GetAxisRaw("Vertical");
            //    float horizontal = Input.GetAxisRaw("Horizontal");
            //    float vertical = Input.GetAxisRaw("Vertical");  
                               
            //    controller.Move(Time.deltaTime * speed);
        cube.velocity = new Vector2(horInput * speed, vertInput * speed);


    }
}
