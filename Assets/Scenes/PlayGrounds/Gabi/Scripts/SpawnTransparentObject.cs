using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTransparentObject : MonoBehaviour
{
    public GameObject testObject;
    [Range(0, 255)]
    public float tranparencyValue;
    public Material transparentMaterial;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        Renderer spawnedObject = Instantiate(testObject,pos,Quaternion.identity).GetComponent<Renderer>();
        //Color originalColor = spawnedObject.GetComponent<Renderer>().material.color;
        //spawnedObject.material.color = new Color(spawnedObject.material.color.r, spawnedObject.material.color.g, spawnedObject.material.color.b,-40);
        spawnedObject.material = transparentMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
