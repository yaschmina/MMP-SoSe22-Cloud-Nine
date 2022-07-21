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
            animator.SetTrigger("loose_life_trigger"); // funktioniert momentan nicht

        }
        else if (collision.gameObject.CompareTag("DeathSquare"))
        {
            lives--;
            Debug.Log("lives: " + lives);
            animator.SetTrigger("loose_life_trigger"); // funktioniert momentan nicht
            Vector2 point0 = new Vector2(0.0f, 0.0f);
            rigidbody.MovePosition(point0);

        }
        lifeCount.text = "My lifes:" + lives;
        if (lives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        rigidbody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death_trigger");
    }

    private void RestartJumpNRunLevel() // funktioniert momentan wsl nicht so ganz weil ich das mit den 3 Leben eingebaut hab
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
