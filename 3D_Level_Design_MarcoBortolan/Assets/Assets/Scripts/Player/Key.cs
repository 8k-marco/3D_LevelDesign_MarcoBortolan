using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    [Header("Door_Objects")]
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    [SerializeField] private GameObject door3;
    [SerializeField] private GameObject door4;
    [SerializeField] private GameObject door5;
    [SerializeField] private GameObject door6;
    [SerializeField] private GameObject door7;
    [SerializeField] private GameObject water;

    [Header("Key_Objects")]
    [SerializeField] private GameObject key1;
    [SerializeField] private GameObject key2;
    [SerializeField] private GameObject key3;
    [SerializeField] private GameObject key4;

    [Header("Press_Button")]
    [SerializeField] private GameObject kF;

    [Header("Switch_Objects")]
    [SerializeField] private GameObject lever1;
    [SerializeField] private GameObject lever2;
    [SerializeField] private GameObject lever3;

    [Header("Switch_Objects")]
    [SerializeField] private GameObject rope1;
    [SerializeField] private GameObject rope2;

    [Header("Bool")]
    //Key
    [SerializeField] private bool hasKey;
    [SerializeField] private bool hasKey2;
    [SerializeField] private bool hasKey3;
    [SerializeField] private bool hasKey4;
    //Rope
    [SerializeField] private bool hasRope1;
    [SerializeField] private bool hasRope2;
    //Switch
    [SerializeField] private bool hasLever1 = false;
    [SerializeField] private bool hasLever2 = false;
    [SerializeField] private bool hasLever3 = false;

    private void Start() 
    {
        //Door
        door1 = GameObject.FindGameObjectWithTag("Door");
        door2 = GameObject.FindGameObjectWithTag("Door2");
        door3 = GameObject.FindGameObjectWithTag("Door3");
        door4 = GameObject.FindGameObjectWithTag("Door4");
        door5 = GameObject.FindGameObjectWithTag("Door5");
        door6 = GameObject.FindGameObjectWithTag("Door6");
        door7 = GameObject.FindGameObjectWithTag("Door7");
        water = GameObject.FindGameObjectWithTag("water");
        //Key
        key1 = GameObject.FindGameObjectWithTag("Key");
        key2 = GameObject.FindGameObjectWithTag("Key2");
        key3 = GameObject.FindGameObjectWithTag("Key3");
        key4 = GameObject.FindGameObjectWithTag("Key4");
        //Switches
        lever1 = GameObject.FindGameObjectWithTag("Lever1");
        lever2 = GameObject.FindGameObjectWithTag("Lever2");
        lever3 = GameObject.FindGameObjectWithTag("Lever3");
        //Ropes
        rope1 = GameObject.FindGameObjectWithTag("Rope1");
        rope2 = GameObject.FindGameObjectWithTag("Rope2");
        // pressButton
        kF = GameObject.FindGameObjectWithTag("KeyF");
        kF.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {   
        //Key --> Door
        if(other.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(key1);
        }

        if(other.CompareTag("Door"))
        {
            if(hasKey)
            {
                door1.SetActive(false);   
            }
        }

        if(other.CompareTag("Key2"))
        {
            hasKey2 = true;
            Destroy(key2);
        }

        if(other.CompareTag("Door2"))
        {
            if(hasKey2)
            {
                door2.SetActive(false);   
            }
        }

        if(other.CompareTag("Key3"))
        {
            hasKey3 = true;
            Destroy(key3);
        }

        if(other.CompareTag("Key4"))
        {
            hasKey4 = true;
            Destroy(key4);
        }

        if(other.CompareTag("Door3"))
        {
            if(hasKey3 && hasKey4)
            {
                door3.SetActive(false);   
            }
        }

        //Lever --> Door
        if(other.CompareTag("Lever1"))
        {
            hasLever1 = true;
            kF.SetActive(true);
        }
        
        if(other.CompareTag("Lever2"))
        {
            hasLever2 = true;
            kF.SetActive(true);
        }

        if(other.CompareTag("Lever3"))
        {
            hasLever3 = true;
            kF.SetActive(true);
        }

        //Ropes --> Waterpegel
        if(other.CompareTag("Rope1"))
        {
            hasRope1 = true;
        }

        if(other.CompareTag("Rope2"))
        {
            hasRope2 = true;
        }

        if(hasRope1 && hasRope2)
        {
            water.SetActive(false);   
        }
    }

    private void OnTriggerExit(Collider other) 
    {
      if(other.CompareTag("Lever1"))
      {
        hasLever1 = false;
        kF.SetActive(false);
      }

      if(other.CompareTag("Lever2"))
      {
        hasLever2 = false;
        kF.SetActive(false);
      }  

      if(other.CompareTag("Lever3"))
      {
        hasLever3 = false;
        kF.SetActive(false);
      }    
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.F) && hasLever1)
        {
            door4.SetActive(false);
            door7.SetActive(false);
            kF.SetActive(false); 
        }

        if(Input.GetKeyDown(KeyCode.F) && hasLever2)
        {
            door5.SetActive(false);
            kF.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.F) && hasLever3)
        {
            door6.SetActive(false);
            kF.SetActive(false);
        }
    }
}