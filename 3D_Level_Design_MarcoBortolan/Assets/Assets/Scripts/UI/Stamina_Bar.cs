using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina_Bar : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private PlayerController playerController;

    [Header("Slider")]
   [SerializeField] private Slider slider;

    [Header("Stamina Values")]
   [SerializeField] private float maxStamina = 100f;
   [SerializeField] private float currentStamina;
   [SerializeField] private float regenStamina = 20f;
   [SerializeField] private float drainStamina = 10f;

   [Header("Delay Values")]
    public float regenerationDelay = 2f;
    private float regenerationTimer = 0f;

    private void Start() 
    {
        currentStamina = maxStamina;
        playerController = FindAnyObjectByType<PlayerController>();
        slider = FindAnyObjectByType<Slider>();
        UpdateSlider();
    }

    private void Update() 
    {
       RegenStamina();
       DrainStamina();
       UpdateSlider();
       EmptyStamina();
    }


    public void RegenStamina ()
    {
        if(currentStamina < maxStamina)
        {
            if(regenerationTimer >= regenerationDelay)
            {
                currentStamina += regenStamina * Time.deltaTime;
            }
            else
            {
                regenerationTimer += Time.deltaTime;
            }
        }
    }

    public void DrainStamina()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentStamina -= drainStamina * Time.deltaTime;
            regenerationTimer = 0f;
        }
    }

    public void EmptyStamina()
    {
        if(currentStamina == 0)
        {
            playerController.movementSpeed = 10f;
        }
    }

    public void UpdateSlider()
    {
        if(slider != null)
        {
            slider.value = currentStamina / maxStamina;
        }
    }
}
