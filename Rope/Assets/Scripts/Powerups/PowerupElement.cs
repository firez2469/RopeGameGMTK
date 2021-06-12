using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupElement : MonoBehaviour
{
    public enum PowerupType { LONGER,SHORTER};
    public PowerupType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (type == PowerupType.LONGER)
            {
                collision.transform.parent.GetComponentInChildren<RopePhysics>().addLength(1);
            }
            else
            {
                print("Collided");
                collision.transform.parent.GetComponentInChildren<RopePhysics>().removeLength(1);
            }
            Destroy(this.gameObject);

        }
    }
    
}
