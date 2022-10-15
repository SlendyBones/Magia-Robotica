using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rgbcontol : MonoBehaviour
{
    public GameObject canvas;

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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(false);
        }
    }
    public void changecolor()
    {
        canvas.SetActive(false);
    }
}
