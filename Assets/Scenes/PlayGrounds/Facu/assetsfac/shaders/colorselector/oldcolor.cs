using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oldcolor : MonoBehaviour
{
    // Start is called before the first frame update
    public string shadercode;
    public Material pjm;
    void Start()
    {
        GetComponent<Image>().color= pjm.GetVector(shadercode);
      
    }
}
