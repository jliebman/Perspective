using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public Circle cir;
    public GameObject spawn;
    public float height;
    public float width;
    [Tooltip("0, 90, or 180")]
    public float quadrant;
    public Material cl;
    public bool randHeight = false;
    public bool randWidth = false;
   
    // Start is called before the first frame update
    //Spawns a circle with random size within a range
    void Start()
    {
        //Generate Random Size Circle with given range
        cir.radius = Random.Range(cir.radiusMin, cir.radiusMax);
        cir.radius = Mathf.Ceil(cir.radius);
        //Determine angle that Cube Spawns at based on spawning quadrants
        float ang = Random.value * 90 + quadrant;
        //ang = 90;
        //Spawn the item
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = cir.radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        spawnPosition.y =  0f;
        spawnPosition.z = cir.radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        //Rotate the Item so it's tangental to the point on the circle
        Quaternion rot = new Quaternion(0f, 0f, 0f, 0f);
        rot = Quaternion.Euler(0, ang - 90, 0);
        //Put the object in the scene
        GameObject a = Instantiate(spawn, spawnPosition, rot);
        if(randHeight)
        {
            height = Random.value * 10;
            height = Mathf.Ceil(height);
            cir.height = height;
        }
        else if(randWidth)
        {
            width = Random.value * 10;
            width = Mathf.Ceil(width);
            cir.width = width;
        }
        a.transform.localScale= new Vector3(a.gameObject.transform.localScale.x, height, width);
        //Set the Color
        a.GetComponent<Renderer>().material = cl;

        
    }
}
