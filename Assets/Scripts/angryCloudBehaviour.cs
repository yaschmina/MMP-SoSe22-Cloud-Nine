using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angryCloudBehaviour : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Vector2 cloudStart;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private float speed = 2f;


    void Start()
    {
        //rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
    }
}
