using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartCollector : MonoBehaviour
{
    private int collectedHearts = 0;

    [SerializeField] private Text heartText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart")) // zerstört Heart, wenn Player mit diesem collidiert
        {
            Destroy(collision.gameObject);
            collectedHearts++;
            Debug.Log("Hearts: " + collectedHearts);
            heartText.text = "Hearts: " + collectedHearts;
        }
    }
}
