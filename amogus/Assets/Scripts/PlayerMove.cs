using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        GetComponent<Animator>().SetFloat("xInput", xInput);
        GetComponent<Animator>().SetFloat("yInput", yInput);
        Debug.Log(xInput);
        Vector2 moveDir = new Vector2(xInput, yInput);
        GetComponent<Rigidbody2D>().velocity = moveDir * speed;
    }
}
