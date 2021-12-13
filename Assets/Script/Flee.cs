using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//서두르라는 의미
public class Flee : AgnetBehavior
{
    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        steering.linear = transform.position - target.transform.position;
        steering.linear.Normalize();
        steering.linear = steering.linear * agent.maxaccel;

        return steering;
    }
}

public class Evade : Flee
{
    public float maxPrediction;
    private GameObject targetAux; //보조적인 의미
    private Agent targetAgent;

    public override void Awake()
    {
        base.Awake();
        targetAgent = target.GetComponent<Agent>();
        targetAux = target;
        target = new GameObject();
    }

    public override Steering GetSteering()
    {
        Vector3 direction = targetAux.transform.position - transform.position;
        float distance = direction.magnitude;
        float speed = agent.velocity.magnitude;
        float prediction;
        if (speed <= distance / maxPrediction)
        {
            prediction = maxPrediction;
        }
        else
        {
            prediction = distance / speed;
        }
        target.transform.position = targetAux.transform.position;
        target.transform.position += targetAgent.velocity * prediction;
        return base.GetSteering();
    }

    private void OnDestroy()
    {
        Destroy(targetAux);
    }
}