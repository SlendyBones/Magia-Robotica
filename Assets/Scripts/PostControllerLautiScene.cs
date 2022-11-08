using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostControllerLautiScene : MonoBehaviour
{
    [SerializeField] GameObject _rainVolume;
    [SerializeField] GameObject _snowVolume;
    // Start is called before the first frame update
    void Start()
    {
        _rainVolume.SetActive(false);
        _snowVolume.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _rainVolume.SetActive(true);
            SoundManager.instance.PlaySound(SoundID.Rain);
            SoundManager.instance.StopSound(SoundID.Snow);
            _snowVolume.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _snowVolume.SetActive(true);
            SoundManager.instance.PlaySound(SoundID.Snow);
            SoundManager.instance.StopSound(SoundID.Rain);
            _rainVolume.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _snowVolume.SetActive(false);
            _rainVolume.SetActive(false);
            SoundManager.instance.StopAllSounds();
        }
    }
}
