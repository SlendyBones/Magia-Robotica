using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rgbcontol : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvas3d;

    // Start is called before the first frame update
    void Start()
    {
        
        canvas3d.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            canvas3d.SetActive(true);
            canvas.SetActive(false);
           
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            canvas3d.SetActive(false);
            canvas.SetActive(true);
          
        }
    }
    public void changecolor()
    {
        canvas3d.SetActive(false);
    }
}
