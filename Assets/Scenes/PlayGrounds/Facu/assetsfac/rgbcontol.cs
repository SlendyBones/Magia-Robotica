using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rgbcontol : MonoBehaviour
{
    public GameObject canvas;
    public InputField primaryred;
    public InputField primaryblue;
    public InputField primarygreen ;
    public InputField secondaryred;
    public InputField secondaryblue;
    public InputField secondarygreen;
    public Material pj;

    // Start is called before the first frame update
    void Start()
    {

        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            canvas.SetActive(true);
        }
    }
    public void changecolor()
    {
       

    

        pj.SetVector("_colorsecundario", new Vector4(float.Parse(primaryred.text), float.Parse(primaryblue.text), float.Parse(primarygreen.text), 0));
        pj.SetVector("_colorprincipal", new Vector4(float.Parse(secondaryred.text), float.Parse(secondaryblue.text), float.Parse(secondarygreen.text), 0));
    }
}
