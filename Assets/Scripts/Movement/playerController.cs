using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float chickCount = 0;
    
    public float gravity;
    Vector3 velocity;

    void Update()
    {
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //Gets raw inputs from keyboard or controller
        float horizontal = Input.GetAxisRaw("Horizontal");                 
        float vertical = Input.GetAxisRaw("Vertical");

        //Establishes variables for what is always forward and right of the main camera
        Vector3 camF = cam.forward;                                        
        Vector3 camR = cam.right;

        //Zeroes out the rotation of the camera (camera will always be angled downward)
        camF.y = 0;                                                        
        camR.y = 0;

        //Normalizes these directions
        camF = camF.normalized;                                            
        camR = camR.normalized;

        //Uses horizontal and vertical inputs and stores them in a useful vector3.
        Vector3 input = new Vector3(horizontal, 0f, vertical).normalized;               
        //Combines the directional inputs relative to forward and right of the main camera
        Vector3 direction = (camF * input.z + camR * input.x);            

        // if the controller is recieving input...
        if (direction.magnitude >= 0.1f)                                
        {   
            //...Get the direction that the object is going to move in...
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            //... and rotate the object in the direction it is to move      
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            //and finally move the object.
            controller.Move(direction * Time.deltaTime * speed);    
        }
    }
    
    void OnEnable() => chickBehavior.OnCollected += OnChickCollected;
    void OnDisable() => chickBehavior.OnCollected -= OnChickCollected;

    void OnChickCollected()
    {
        chickCount++;
        print(chickCount);
    }
}
