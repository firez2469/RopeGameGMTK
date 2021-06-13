using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject : MonoBehaviour
{
    Vector2 initialPosn;
    public float size = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        initialPosn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        print(Mathf.Sin(Time.time));
        transform.position = initialPosn+ (Vector2)transform.up * Mathf.Sin(Time.time)*size;
    }
}
