using UnityEngine;


public class KeyScript : MonoBehaviour
{
    public int forPlayerNum = 1;
    bool thisKeyCollected = false;
    private void Start()
    {
        KeysCollected = 0;
    }
    public static int TotalKeys()
    {
        //return GameObject.FindObjectsOfType<KeyScript>().Length;
        return GameObject.FindGameObjectsWithTag("Key").Length;
    }

    public static int KeysCollected = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!thisKeyCollected&&(
                (forPlayerNum == 1&& collision.gameObject.name == "Player1")
                ||(forPlayerNum==2&&collision.gameObject.name=="Player2")))
            {
                thisKeyCollected = true;
                KeysCollected++;
                Destroy(this.gameObject);
            }
            
        }
        
    }
}
