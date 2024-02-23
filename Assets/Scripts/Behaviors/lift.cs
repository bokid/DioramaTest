using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
{
    public Transform player;
    public Transform liftswitch;
    public Transform downpos;
    public Transform upperpos;

    public float speed;
    bool isdown;


    void Start()
    {
        isdown = true;
    }

    void Update()
    {
        if(Vector2.Distance(player.position,liftswitch.position)< 1f && Input.GetKeyDown("e"))
        {
            if (transform.position.y <= downpos.position.y)
            {
                isdown = true;
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                
                StartLift();
            }
            else if (transform.position.y >= upperpos.position.y)
            {
                isdown = false;
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                StartLift();
            }
        }

        //StartLift();
    }
    void StartLift()
    {

        
        
        if(isdown)
        {
            //transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position,upperpos.position,speed * Time.deltaTime);
        }
        else
        {
            //transform.Translate(Vector3.down * speed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position,downpos.position,speed * Time.deltaTime);
        }
    }
}
