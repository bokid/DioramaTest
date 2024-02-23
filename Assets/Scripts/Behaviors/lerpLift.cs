using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpLift : MonoBehaviour
{
    private Vector3 endPosition = new Vector3(-5,-5,-1);
    private Vector3 startPosition;
    public float duration;
    public Transform liftSwitch;
    public Transform player;
    private float elapsedTime;

    private bool isUp = true;

    void Start()
    {
        startPosition = transform.position;
    }

   
    void Update()
    {
        float percentageComplete = elapsedTime / duration;
        //liftSwitch.onTriggerEnter();
        
        if (isUp)
        {
            if (Vector2.Distance(player.position,liftSwitch.position)< 1f) //&& Input.GetKey("e"))
            {
                elapsedTime += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

                if(transform.position == endPosition)
                {
                    isUp = false;
                }
                
            }
        }
        else
        {
            if (Vector2.Distance(player.position,liftSwitch.position)< 1f) //&& Input.GetKey("e"))
            {
                elapsedTime += Time.deltaTime;
                transform.position = Vector3.Lerp(endPosition, startPosition, percentageComplete);

                if(transform.position == startPosition)
                {
                    isUp = true;
                }
                

            }
        }
        

    }

   
    
}
