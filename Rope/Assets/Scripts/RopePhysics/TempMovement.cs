using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMovement : MonoBehaviour
{
    float normspeed = 7f;
    float fastSpeed = 15f;
    float speed = 0;
    public bool p1 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p1)
        {
            float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = fastSpeed;
            }
            else
            {
                speed = normspeed;
            }
            transform.position += transform.right * x;
        }
        else
        {
            float x = Input.GetAxis("HorizontalP2") * Time.deltaTime * speed;

            if (Input.GetKey(KeyCode.RightShift))
            {
                speed = fastSpeed;
            }
            else
            {
                speed = normspeed;
            }
            transform.position += transform.right * x;
        }
       
       
    }
}
