using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    public float speed = 10.0f;
    public Transform cameratarget;

    //잠깐 확인을 하기 위해 두도록 하자.
    private float timecheck;

    private Camera thiscamera;
    private Vector3 worldDefaultVector;

    // Start is called before the first frame update
    void Start()
    {
        timecheck = 0.0f;
        thiscamera = GetComponent<Camera>();
        worldDefaultVector = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        thiscamera.transform.position = new Vector3(cameratarget.position.x, cameratarget.position.y, -10);
        float scroll = Input.GetAxis("Mouse ScrollWheel") * speed;
        timecheck += Time.deltaTime;

        Debug.Log(scroll);

        if(timecheck >= 1.0f)
        {
            Debug.Log("thiscamera.fieldOfView" + thiscamera.fieldOfView);
        }

        if (thiscamera.fieldOfView <= 20.0f && scroll < 0)
        {
            thiscamera.fieldOfView = 20.0f;
        }
        else if(thiscamera.fieldOfView >= 60.0f && scroll > 0)
        {
            thiscamera.fieldOfView = 60.0f;
        }
        else
        {
            thiscamera.fieldOfView += scroll;
        }


        //일정 구간 줌으로 들어가면 캐릭터를 줌한다.
        if(thiscamera && thiscamera.fieldOfView <= 30.0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                Quaternion.LookRotation(cameratarget.position - transform.position), 0.15f);

        }
        //일정 구간 밖에서는 원래의 카메라 방향으로 돌아가기.
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(worldDefaultVector), 0.15f);
        }
    }
}
