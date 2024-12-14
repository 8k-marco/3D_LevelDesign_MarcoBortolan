using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject doorObject;
    [SerializeField] private GameObject keyObject;

    [Header("Bool")]
    [SerializeField] private bool hasKey;

    private void Start() 
    {
        doorObject = GameObject.FindGameObjectWithTag("Door");
        keyObject = GameObject.FindGameObjectWithTag("Key");
    }

    private void OnTriggerEnter(Collider other)
    {   
        if(other.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(keyObject);
        }

        if(other.CompareTag("Door"))
        {
            if(hasKey)
            {
                doorObject.SetActive(false);   
            }
        }
    }
}