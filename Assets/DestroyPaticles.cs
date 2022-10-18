using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPaticles : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 0.5f);
    }
}
