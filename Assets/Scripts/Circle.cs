using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Circle : MonoBehaviour
{
    public int vertexCount = 40;
    public float lineWidth = 0.1f;
    public float radiusMin;
    public float radiusMax;
    public float radius;
    public float height;
    public float width;

    private LineRenderer lineRenderer;


    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    //Displays the Circle in Unity Editor and creates a circle of a set size
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;
        
        
        Vector3 oldPos = Vector3.zero;
        for(int i = 0; i<vertexCount+1; ++i)
        {
            Vector3 pos = new Vector3(radius * Mathf.Sin(theta), 0f, radius * Mathf.Cos(theta));  //Math to get each vertex in order to draw a circle
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;
            theta += deltaTheta;
        }
   
    }
#endif
}
