using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default_AI_Move : MonoBehaviour
{
    public GameObject target;
    public int count;

    //코루틴 위치
    private bool isDelay = false;
    private static float timelimit = 1.0f;
    private float time = 0.0f;

    List<Vector3> randomMovePoint;
    // Start is called before the first frame update
    void Start()
    {
        randomMovePoint = GetSegment();
        count = 0;

        StartCoroutine(ChangePoint());
    }

    // Update is called once per frame
   

    List<Vector3> GetSegment()
    {
        List<Vector3> segments = new List<Vector3>();

        for(int i = 0;i<10;i++)
        {
            segments.Add(new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f)));
        }


        return segments;
    }

    IEnumerator ChangePoint()
    {
        while(true)
        {
            count = (count + 1) % 10;
            transform.position = randomMovePoint[count];
            yield return new WaitForSeconds(1.0f);
        }
        
    }
}
