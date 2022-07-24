using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] startAndEndPoints;
    private int currentPoint = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        // transform.position ist die Position von dem Objekt, dem das Skript zugeordnet ist
        if (Vector2.Distance(startAndEndPoints[currentPoint].transform.position, transform.position) < .1f) // Rechnet Distanz zwischen zwei Punkten aus -> chekt  ob die Distanz kleiner als 0.1 ist
        {
            currentPoint++;
            if (currentPoint >= startAndEndPoints.Length) // wenn wir am letzen Wegpunkt in der Liste angekommen sind
            {
                currentPoint = 0;
            }
        }
        // Bewegt die Wolke unter Ber?cksichtigung des Spielspeeds
        transform.position = Vector2.MoveTowards(transform.position, startAndEndPoints[currentPoint].transform.position, Time.deltaTime * speed);  
    }
}
