using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class materialdisplay : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject cristalrosadogam;
    public GameObject mineralgam;
    public GameObject cristalrojogam;
    public GameObject cristalmoradogam;

    public int cristalrosado;
    public int mineral;
    public int cristalrojo;
    public int cristalmorado;


    public Text cristalrosadotext;
    public Text mineraltext;
    public Text cristalrojotext;
    public Text cristalmoradotext;


    void Start()
    {
        

        if (cristalrosado != 0)
        {
            cristalrosadogam.SetActive(true);
            cristalrosadotext.text = cristalrosado.ToString();
        }
        if (mineral != 0)
        {
            mineralgam.SetActive(true);
            mineraltext.text = mineral.ToString();
        }
        if (cristalrojo != 0)
        {
            cristalrojogam.SetActive(true);
            cristalrojotext.text = cristalrojo.ToString();
        }
        if (cristalmorado != 0)
        {
            cristalmoradogam.SetActive(true);
            cristalmoradotext.text = cristalmorado.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
