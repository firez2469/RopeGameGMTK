using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePhysics : MonoBehaviour
{
    public Rigidbody2D rigidbody1;
    public Rigidbody2D rigidbody2;
    
    public float ropeLength = 1f;
    Vector2 centerPosition;

    //Don't implement yet;
    float drag;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get center position from which both objects are move away from or towards
        centerPosition = rigidbody1.transform.position - rigidbody2.transform.position;
        Vector2 obj1Relative = (Vector2)rigidbody1.transform.position - centerPosition;

    }


    
}
