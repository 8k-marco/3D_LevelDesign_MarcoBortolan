using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klettern : MonoBehaviour
{
    public bool clamp;
    public float clampSpeed;
    public Rigidbody rb;


    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("ladder"))
        {
            clamp = true;
            rb.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider c)
    {
       if (c.gameObject.CompareTag("ladder"))
        {
            clamp = false;
            rb.useGravity = true;
        } 
    }


    void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, clampSpeed * Time.deltaTime, 0);
        }
    }
}