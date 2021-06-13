using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeComponent : MonoBehaviour
{
    public bool isEnabled = true;
    public List<string> activatedFor = new List<string>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&!activatedFor.Contains(collision.gameObject.name))
        {
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            collision.transform.parent.GetComponentInChildren<AudioSource>().time = 0.5f;
            collision.transform.parent.GetComponentInChildren<AudioSource>().Play();
            activatedFor.Add(collision.gameObject.name);
            StartCoroutine(restartGame());
        }
    }

    private IEnumerator restartGame()
    {
        yield return new WaitForSeconds(3);
        GameManager.RestartLevel();

    }
}
