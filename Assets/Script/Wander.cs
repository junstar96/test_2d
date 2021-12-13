using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Face
{
    // Start is called before the first frame update
    public float offset; //처음부터 주어진 값이나 지점까지의 거리 차
    public float radius;
    public float rate;

    public override void Awake()
    {
        target = new GameObject();
        target.transform.position = transform.position;
        base.Awake();
    }

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        float wanderOrientation = Random.Range(-1.0f, 1.0f) * rate;
        float targetOrientation = wanderOrientation * agent.orientation;
        








        return base.GetSteering();
    }

}
