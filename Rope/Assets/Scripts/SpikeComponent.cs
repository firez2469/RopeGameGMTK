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
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            StartCoroutine(restartGame());
        }
    }

    private IEnumerator restartGame()
    {
        yield return new WaitForSeconds(3);
        GameManager.RestartLevel();

    }
}
