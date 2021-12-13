using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//여기가 유닛들의 행동 패턴에 들어가는 것들을 담는다. 부모 클래스
public class AgnetBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    protected Agent agent;
    public float maxspeed;
    public float maxaccel;
    public float maxrotation;
    public float maxangularaccel;


    public virtual void Awake()
    {
        agent = gameObject.GetComponent<Agent>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        agent.SetSteering(GetSteering());
    }

    public virtual Steering GetSteering()
    {
        return new Steering();
    }

    public float MapToRange(float rotation)
    {
        rotation %= 360.0f;
        if(Mathf.Abs(rotation) > 180.0f)
        {
            if(rotation< 0.0f)
            {
                rotation += 360.0f;
            }
            else
            {
                rotation -= 360.0f;
            }
        }

        return rotation;
    }


    public Vector3 GetOriAsVec(float orientation)
    {
        Vector3 vector = Vector3.zero;
        vector.x = Mathf.Sin(orientation * Mathf.Deg2Rad) * 1.0f;
        vector.z = Mathf.Cos(orientation * Mathf.Deg2Rad) * 1.0f;

        return vector;
    }
}
