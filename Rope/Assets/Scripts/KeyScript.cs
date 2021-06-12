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
        KeysCollected++;
        Destroy(this.gameObject);
    }
}
