using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class chickBehavior : MonoBehaviour
{
    //OnCollected Action will be used by playerController to pick up the duckling.
    public static event Action OnCollected;
    //Target selected in inspector will be Mama
    public Transform target;
    //Target found by the script will be the Line Position targets; LPos1-3
    private Transform lineTarget;
    NavMeshAgent nav;
    //Private bool for checking if this particular object has been picked up and not all objects of the class.
    private bool picked = false;
    //Formation will be changed by button press.
    public string formation = "";
    //Wait will be changed by button press, duckling speed will be set to 0 on wait.
    public bool wait = false;
    //Serialized for debugging. chickIndex will assign a number by order of objects picked. 
    [SerializeField]
    private float chickIndex = 0;
   
    void Start()
    {
        //Connect to NavMeshAgent component.
        nav = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        //Establish Line Formation targets by chick index.
        if (chickIndex == 1)
        {
            lineTarget = GameObject.Find("LPos1").transform;
        }
        else if (chickIndex == 2)
        {
            lineTarget = GameObject.Find("LPos2").transform;
        }
        else if (chickIndex == 3)
        {
            lineTarget = GameObject.Find("LPos3").transform;
        }
        //Gather inputs
        bool xbox_a = Input.GetButton("XboxA");
        bool xbox_b = Input.GetButton("XboxB");
        bool xbox_x = Input.GetButton("XboxX");
        //On pick up...
        if (picked == true)
        {   
            //follow mama...
            nav.SetDestination(target.position);
            //change formation to Gaggle on B...
            if (xbox_b)
            {
                formation = "Gaggle";
                print(formation);
            }
            //change formation to Line on X...
            if (xbox_x)
            {
                formation = "Line";
                print(formation);
            }
            //Change target to the LineTarget if current formation is "Line..."
            if (formation == "Line")
            {
                nav.SetDestination(lineTarget.position);
                nav.stoppingDistance = 0;
            }
            //Revert to default target("Mama") if formation = Gaggle.
            else if (formation == "Gaggle")
            {
                nav.SetDestination(target.position);
                nav.stoppingDistance = 2;
            }
        }
        //Xbox A will be used for a quack noise, check for ducklings in range in future build.
        if (xbox_a)
        {
            print("A");
        }
    }
    //xbox Y was set in Fixed update as test, toggle only works intermittently...
    void FixedUpdate()
    {
        bool xbox_y = Input.GetButton("XboxY");
        if (xbox_y)
        {
            //Toggles wait's state.
            wait = wait ? false : true;
            print(wait);  
        }
        //Moved wait's check out of the xbox_y condition, still only partially works.
        if (wait == true)
            {
                nav.speed = 0;
            }
        else
            {
                nav.speed = 5;
            }  
    }
    //Another object collides with duckling object...
    void OnTriggerEnter(Collider other)
    {
        //...If it's a player...
        if (other.CompareTag("Player"))
        {
            //...and if the chick is unpicked...
            if (picked == false)
            {
            //...invoke OnCollected...
            OnCollected?.Invoke();
            //...Update local chickIndex to current value of chickCount from playerController...
            chickIndex = GameObject.Find("Mama").GetComponent<playerController>().chickCount;
            //... and set picked to true.
            picked = true;
            }
            
            
        }
    }
}
