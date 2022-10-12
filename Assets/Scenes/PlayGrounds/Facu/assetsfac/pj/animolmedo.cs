using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animolmedo : MonoBehaviour
{
    public Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            anim.SetBool("walking", true);
        else
        {
            anim.SetBool("walking", false);
        }
    }
}
