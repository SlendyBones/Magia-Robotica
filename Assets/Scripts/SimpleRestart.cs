using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleRestart : MonoBehaviour
{
    [SerializeField]
    string _artScene;

    [SerializeField]
    string _menu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
           UnityEngine.SceneManagement.SceneManager.LoadScene(_artScene);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(_menu);
        }
    }
}
