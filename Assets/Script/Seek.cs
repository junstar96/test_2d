using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//여기는 탐색하는 쪽
public class Seek : AgnetBehavior
{ 
    // Start is called before the first frame update
    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        steering.linear = target.transform.position - transform.position;
        steering.linear.Normalize();
        steering.linear = steering.linear * agent.maxspeed;



        return steering;
    }
    // Update is called once per frame
}
