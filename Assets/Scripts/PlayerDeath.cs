using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody;
    [SerializeField] private int lives = 3;
    [SerializeField] private Text lifeCount;
    [SerializeField] private AudioSource looseLifeSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BananaPeel"))
        {
            lives--;
            Debug.Log("lives: " + lives);
            looseLifeSound.Play();
            animator.SetTrigger("loose_life_trigger"); // funktioniert momentan nicht

        }
        else if (collision.gameObject.CompareTag("DeathSquare"))
        {
            //evtl methode für die drei Zeilen schreiben
            lives--;
            Debug.Log("lives: " + lives);
            looseLifeSound.Play();
            animator.SetTrigger("loose_life_trigger"); // funktioniert momentan nicht
            Vector2 point0 = new Vector2(0.0f, 0.0f);
            rigidbody.MovePosition(point0);

        }
        lifeCount.text = "My lifes:" + lives;
        if (lives <= 0)
        {
            Die();
            // Invoke("RestartJumpNRunLevel", 2f); // soll das restarten verzögern, funktioniert aber nicht
        }
    }

    private void Die()
    {
        rigidbody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death_trigger");
    }

    private void RestartJumpNRunLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
