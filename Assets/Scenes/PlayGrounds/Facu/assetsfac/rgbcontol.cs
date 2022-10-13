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
    public GameObject pj;
    public Material pjm;

    // Start is called before the first frame update
    void Start()
    {
        pjm = pj.GetComponent<Renderer>().material;
        canvas.SetActive(false);
        pjm.SetFloat("Boolean_d98f0f713e8243b6a923b0fec1101aed", 1f);
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

        pjm.SetFloat("Boolean_d98f0f713e8243b6a923b0fec1101aed", 0f);


        pjm.SetVector("Color_9af90b6a8db54b21aeee5f58226d9961", new Vector4(float.Parse(primaryred.text), float.Parse(primaryblue.text), float.Parse(primarygreen.text), 0));
        pjm.SetVector("Color_a08d51509e524380a91a5dc923146f33", new Vector4(float.Parse(secondaryred.text), float.Parse(secondaryblue.text), float.Parse(secondarygreen.text), 0));
        canvas.SetActive(false);
    }
}
