using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayMusic(MusicID.ChillMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
