using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReachedEnd : MonoBehaviour
{
    private AudioSource win;
    private bool levelCompleted = false;

    void Start()
    {
       win = GetComponent<AudioSource>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            levelCompleted = true; // Sorgt dafür, dass der Sound nur 1x spielt
            win.Play();
            Invoke("LevelCompleted", 2f); // sorgt für Verzögerung beim callen von LevelCompleted()
            Debug.Log("Gewonnen!");
        }
    }

    // Soll das nächste Level anschalten eig
    //private void LevelCompleted()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}
}
