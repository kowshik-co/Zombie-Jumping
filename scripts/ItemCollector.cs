using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int Coins = 0;

    [SerializeField] Text coinsText;
    [SerializeField] AudioSource collectablsound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            Coins++;
            coinsText.text = "Coins: " + Coins;
            collectablsound.Play();
        }
    }
}
