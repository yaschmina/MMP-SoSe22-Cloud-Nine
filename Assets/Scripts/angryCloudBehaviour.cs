using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angryCloudBehaviour : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    //private Vector2 cloudStart;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private float speed = 2f;
    private bool playerIsClose = false;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player.position.x > (rigidbody.position.x - 5f) && player.position.x < rigidbody.position.x + 5f)
        {
            playerIsClose = true;
            //Debug.Log("true x pos player: " + player.position.x);
            //Debug.Log("true x pos cloud: " + rigidbody.position.x);
        }

        if (playerIsClose)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
        }
    }
}
