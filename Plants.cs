using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if player hit the plant if that is true plant closes
        if (collision.gameObject.name == "Player")
        {
            anim.SetTrigger("close");
        }
    }
}
