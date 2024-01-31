using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int strawberries = 0;
    [SerializeField] private Text strawberryText;
    [SerializeField] private Text endText;
    [SerializeField] private AudioSource CollectSoundEffect;
    [SerializeField] private int totalStrawberries;

    private void Start()
    {
        strawberryText.text = "strawberries: " + strawberries + "/" + totalStrawberries;
        endText.text = "you got strawberries: " + strawberries + "/" + totalStrawberries;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            //if you touch a stawberry it gets annihilated and makes the number on the screen go up
            Destroy(collision.gameObject);
            strawberries++;
            CollectSoundEffect.Play();
            strawberryText.text = "strawberries: " + strawberries + "/" + totalStrawberries;
            endText.text = "you got strawberries: " + strawberries + "/" + totalStrawberries;

        }
    }
}
