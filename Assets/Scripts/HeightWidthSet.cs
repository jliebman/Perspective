using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightWidthSet : MonoBehaviour
{
    public GameObject prefab;
    public float height;
    public float width;
    // Start is called before the first frame update
    void Start()
    {
        prefab.transform.localScale.Set(prefab.transform.localScale.x, height, width);

    }

}
