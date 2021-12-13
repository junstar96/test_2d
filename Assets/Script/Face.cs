using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//마주보는 알고리즘
public class Face : Align
{
    // Start is called before the first frame update
    protected GameObject targetAux;


    public override void Awake()
    {
        base.Awake();
        targetAux = target;
        target = new GameObject();
        target.AddComponent<Agent>();
    }

    private void OnDestroy()
    {
        Destroy(target);
    }

    public override Steering GetSteering()
    {
        Vector3 direction = targetAux.transform.position - transform.position;
        if(direction.magnitude > 0.0f)
        {
            float targetOrientation = Mathf.Atan2(direction.x, direction.z);
            targetOrientation *= Mathf.Rad2Deg;
            target.GetComponent<Agent>().orientation = targetOrientation;
        }

        return base.GetSteering();
    }
}
