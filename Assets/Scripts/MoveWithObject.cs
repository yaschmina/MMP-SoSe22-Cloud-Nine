using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) // Es wird geschaut, ob die Wolke mit einem anderen Objekt kollidiert
    {
        if (collision.gameObject.name == "Player") // Es wird geschaut, ob dieses andere Objekt der "Player" ist -> wichtig: gleicher Name wie in Hierarchie
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // für wenn der Player die Plattform wieder verlässt
    {
        if (collision.gameObject.name == "Player") 
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
