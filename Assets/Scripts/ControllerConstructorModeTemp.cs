using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerConstructorModeTemp : MonoBehaviour
{
    [SerializeField] private GameObject _construcMenu;
    private bool _construcMenuIsOn;
    // Start is called before the first frame update
    void Start()
    {
        _construcMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            _construcMenuIsOn = !_construcMenuIsOn;
            if (_construcMenuIsOn)
            {
                _construcMenu.SetActive(true);
            }
            else
            {
                _construcMenu.SetActive(false);
            }
            
        }
    }
}
