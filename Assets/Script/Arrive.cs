using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : AgnetBehavior
{
    // Start is called before the first frame update

    public float targetRadius;
    public float slowRadius;
    public float timeToTarget = 0.1f;

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        Vector3 direction = target.transform.position - transform.position;
        float distance = direction.magnitude;
        float targetspeed;
        if(distance < targetRadius)
        {
            return steering;
        }

        if(distance > slowRadius)
        {
            targetspeed = agent.maxspeed;
        }
        else
        {
            targetspeed = agent.maxspeed * distance / slowRadius;
        }

        Vector3 desiredVelocity = direction;
        desiredVelocity.Normalize();
        desiredVelocity *= targetspeed;
        steering.linear = desiredVelocity - agent.velocity;
        steering.linear /= timeToTarget;
        if(steering.linear.magnitude > agent.maxaccel)
        {
            steering.linear.Normalize();
        }
    


        return steering;
    }
}
