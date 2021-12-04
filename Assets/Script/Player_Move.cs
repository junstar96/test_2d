using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private Rigidbody2D playermove;
    // Start is called before the first frame update

    private void Awake()
    {
        playermove = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        playermove = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            playermove.MovePosition(playermove.position + Vector2.up * Time.deltaTime);
        }

    }

    private void LateUpdate()
    {
        
    }
}
