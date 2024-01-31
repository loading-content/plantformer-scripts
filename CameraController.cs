using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    void Update()
    {
        //follows the player everywhere it goes
        transform.position = new Vector3(player.position.x, player.position.y + 1f, transform.position.z);
    }
}
