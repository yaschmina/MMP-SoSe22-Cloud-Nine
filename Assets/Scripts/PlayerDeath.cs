using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody;
    [SerializeField] private int lives = 3;

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
            animator.SetTrigger("loose_life_trigger");

            if (lives < 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        rigidbody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death_trigger");
    }

    //private void RestartJumpNRunLevel() // funktioniert momentan wsl nicht so ganz weil ich das mit den 3 Leben eingebaut hab
    //{
     //   SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

}
