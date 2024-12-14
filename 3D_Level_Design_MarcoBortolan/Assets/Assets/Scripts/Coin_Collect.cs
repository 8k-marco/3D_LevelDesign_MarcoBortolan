using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Collect : MonoBehaviour
{
    [Header("Coin")]
    [SerializeField] private  int Coin = 0;
    [SerializeField] private TextMeshProUGUI coinText;

    private void Start() 
    {
        GameObject coinTextObject = GameObject.Find("Coin_Text");
        if (coinTextObject != null)
          {
              coinText = coinTextObject.GetComponent<TextMeshProUGUI>();
          }
        UpdateCoinText();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.transform.tag == "Coin")
        {
            Coin++;
            UpdateCoinText();
            Destroy(other.gameObject);
        }
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "coinText: " + Coin;
        }
    }
}