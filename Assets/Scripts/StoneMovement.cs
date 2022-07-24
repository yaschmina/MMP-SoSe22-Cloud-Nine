using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private int currentPoint = 0;
    private bool playerWasClose = false;

    [SerializeField] private GameObject[] startAndEndPoints;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float radius = 2f;
    [SerializeField] private float radiusDown = 7f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player.position.x > (rigidbody.position.x - radius) && player.position.x < rigidbody.position.x + radius && player.position.y < rigidbody.position.y && player.position.y < rigidbody.position.y + radiusDown)
        {
            playerWasClose = true;
        }

            if (playerWasClose)
            { 
            // transform.position ist die Position von dem Objekt dem das Skript zugeordnet ist
            if (Vector2.Distance(startAndEndPoints[currentPoint].transform.position, transform.position) < .1f) // Rechnet Distanz zwischen zwei Punkten aus -> chekt  ob die Distanz kleiner als 0.1 ist
            {
                currentPoint++;
            }
            // Bewegt die Wolke unter Ber?cksichtigung des Spielspeeds
            transform.position = Vector2.MoveTowards(transform.position, startAndEndPoints[currentPoint].transform.position, Time.deltaTime * speed);
        }
    }
}
