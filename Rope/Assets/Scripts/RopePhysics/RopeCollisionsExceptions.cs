using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollisionsExceptions : MonoBehaviour
{
    string[] tags = { "ClearFloor" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(string tag in tags)
        {
            if (collision.transform.CompareTag(tag))
            {
                Physics2D.IgnoreCollision(collision.collider, this.GetComponent<CircleCollider2D>());
            }
        }
    }
}
