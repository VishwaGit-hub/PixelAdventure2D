using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int apples = 0;
    [SerializeField] private Text applesText;
    [SerializeField] private AudioSource itemCollectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            itemCollectionSoundEffect.Play();
            apples++;
            applesText.text = "Apples:" + apples;
        }
    }
}
