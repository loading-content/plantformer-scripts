using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private Animator anim;
    public GameObject StawberryText;
    public GameObject EndTextUI;

    float gameSpeed;

    private bool levelCompleted = false;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && levelCompleted == false)
        {
            gameSpeed = Time.timeScale;

            finishSound.Play();
            levelCompleted = true;
            anim.SetTrigger("Triggered");
            StawberryText.SetActive(false);
            EndTextUI.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("CompleteLevel", 0.5f);
        }
    }

    private void CompleteLevel()
    {
        Time.timeScale = gameSpeed;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
