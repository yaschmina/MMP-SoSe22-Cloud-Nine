using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform followPlayer; 

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(followPlayer.position.x, followPlayer.position.y, transform.position.z); //followPlayer könnte hier auch player heißen (siehe tutorial)
    }
}
