using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathStuff : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource DeathSoundEffect;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deadly") || collision.gameObject.CompareTag("EvilAnt") || collision.gameObject.CompareTag("LevelWall"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("FleshyPlant"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            Invoke("Die", 0.5f);
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        DeathSoundEffect.Play();
        anim.SetTrigger("death");
    }


    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
