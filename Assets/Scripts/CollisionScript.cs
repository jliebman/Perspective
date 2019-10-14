using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    // Checks if User is in the Starting Spot
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("MainCamera"))
            this.GetComponent<Light>().color = Color.green;

    }
    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("MainCamera"))
        this.GetComponent<Light>().color = Color.red;
    } 
}
