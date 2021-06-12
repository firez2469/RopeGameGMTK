using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeComponent : MonoBehaviour
{
    public bool isEnabled = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpringJoint2D joint = collision.gameObject.GetComponent<SpringJoint2D>();
            foreach(SpringJoint2D j in joint.connectedBody.GetComponents<SpringJoint2D>())
            {
                j.enabled = !isEnabled;
            }

            joint.enabled = !isEnabled;
            

            //collision.gameObject.GetComponent<SpringJoint2D>().connectedBody = collision.GetComponent<Rigidbody2D>();
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = !isEnabled;
        }
    }
}
