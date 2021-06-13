using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int playerNum = 1;
    public bool inAir = true;

    public Animator anim;
    public SpriteRenderer display;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x;
        if (playerNum == 1)
        {
            x = Input.GetAxis("HorizontalP2");
        }
        else
        {
            x = Input.GetAxis("Horizontal");
        }
        if (!inAir)
        {
            if (x > 0)
            {
                display.flipX = false;
                anim.Play("Running");
            }
            else if (x == 0)
            {
                anim.Play("Idle");
            }
            else if (x < 0)
            {
                display.flipX = true;
                anim.Play("Running");
            }

        }
        
            

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("SimpleFloor")||collision.transform.CompareTag("ClearFloor"))
        {
            if(collision.transform.position.y<this.transform.position.y)
            inAir = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("SimpleFloor")|| collision.transform.CompareTag("ClearFloor"))
        {
            inAir = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("SimpleFloor") || collision.transform.CompareTag("ClearFloor"))
        {
            if (collision.transform.position.y < this.transform.position.y)
                inAir = false;
        }
    }
    
}

