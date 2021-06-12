using UnityEngine;


public class KeyScript : MonoBehaviour
{
    public static int TotalKeys()
    {
        return GameObject.FindGameObjectsWithTag("Key").Length;
    }

    public static int KeysCollected = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KeysCollected++;
            Destroy(this.gameObject);
        }
        
    }
}
