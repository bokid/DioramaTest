using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updatedLift : MonoBehaviour
{
    public Rigidbody lift;
    public Transform player;
    public Transform liftswitch;
    public Transform downpos;
    //public float switchDistance;
    public float speed;

    
    
    bool up;

    
    void Start()
    {
        lift = GetComponent<Rigidbody>();
        //bool up = true; 
    }

    void FixedUpdate()
    {
        
    }
    
    void Update()
    {
        //if (lift.transform.position.y < -3)
        //    {
        //        speed = 0;
        //        print("stop");
        //    }

        if (lift.transform.position.y >= 0)
        {
            up = true;
        }
        else if (lift.transform.position.y < -5)
        {
            up = false;
        }
        
        if (up)
        {
            if (Vector2.Distance(player.position,liftswitch.position)< 1f && Input.GetKeyDown("e"))
            {
                //up = false;
                print("goin down!");
                lift.velocity = -transform.up * speed;

                if (lift.transform.position.y < -5)
                {
                    lift.velocity = Vector3.zero;
                }
        
            
            }
            
        }

        if(!up)
        {
            if (Vector2.Distance(player.position,liftswitch.position)< 1f && Input.GetKeyDown("e"))
            {
                //up = false;
                print("goin up!");
                lift.velocity = transform.up * speed;
                if (lift.transform.position.y > 0)
                {
                lift.velocity = Vector3.zero;
                }
            
            }
            
        }
        
        
    
        
    }
}
