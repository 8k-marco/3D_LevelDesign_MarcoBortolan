using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject optionScreen;

   private void Start() 
   {
        optionScreen = GameObject.FindGameObjectWithTag("Option");
        optionScreen.SetActive(false);
   }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            optionScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            optionScreen.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
