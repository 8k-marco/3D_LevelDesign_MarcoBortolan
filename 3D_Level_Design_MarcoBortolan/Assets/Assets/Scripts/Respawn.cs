using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
   public float threshold;

   void OnCollisionEnter(Collision other) 
   {    
        if(other.collider.CompareTag("L1"))
        {
            transform.position = new Vector3 (0f,2f,0f);
        }

        if(other.collider.CompareTag("L2"))
        {
            transform.position = new Vector3 (-5.469188f,12.37996f,25.9638f);
        }
        /*
        if(other.collider.CompareTag("L3"))
        {
            transform.position = new Vector3 (0f,0f,0f);
        }
        */
   }
}