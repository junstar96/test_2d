using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgnetBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    protected Agent agent;

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
}
