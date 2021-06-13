using UnityEngine;


public class DoorScript : MonoBehaviour
{

    // Door characteristics
    [SerializeField]
    bool doorLocked = true;

    public Sprite closed;
    public Sprite open;
    


    void Update()
    {
        // When all the keys are collected, change the lock state of the door to "open"
        if (KeyScript.TotalKeys() == KeyScript.KeysCollected) 
        {
            doorLocked = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Triggered");
        if (!doorLocked )
        {
            Debug.Log("IT'S WORKING!!!, IT'S WORKING, WOOOOW, HELL YEAH!!");
            // make it so it loads the next scene.
            //LoadingScene.LoadScene(GameManager.NextLevel);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = open;
            GameManager.gameOver = true;
            collision.gameObject.SetActive(false);
        }
    }
}
