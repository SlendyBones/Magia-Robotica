using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleMenu : MonoBehaviour
{
    [SerializeField]
    string _lvl;
    [SerializeField]
    string _scene;
    [SerializeField]
    string _characterScene;
    [SerializeField]
    string _mainMenu;
    [SerializeField]
    GameObject _configMenu;
    [SerializeField]
    GameObject _playMenu;
    [SerializeField]
    GameObject _startMenu;
    GameObject _actualMenu;
    [SerializeField]
    private Slider _soundsSlider;
    [SerializeField]
    private Slider _musicSlider;


    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (PlayerPrefs.HasKey("PREFS_VolumeSFX") && _soundsSlider != null)
            _soundsSlider.value = PlayerPrefs.GetFloat("PREFS_VolumeSFX");

        if (PlayerPrefs.HasKey("PREFS_VolumeMusic") && _musicSlider != null)
            _musicSlider.value = PlayerPrefs.GetFloat("PREFS_VolumeMusic");

        _actualMenu = _startMenu;

    }
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_mainMenu);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void ChangeLVL()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_lvl);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void AnotherScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_scene);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CharacterScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_characterScene);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ConfMenu()
    {
        _configMenu.SetActive(true);
        _playMenu.SetActive(false);
        _startMenu.SetActive(false);
    }

    public void PlayMenu()
    {
        _configMenu.SetActive(false);
        _playMenu.SetActive(true);
        _startMenu.SetActive(false);
    }

    public void StartMenu()
    {
        _configMenu.SetActive(false);
        _playMenu.SetActive(false);
        _startMenu.SetActive(true);
    }



    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeSoundsVolume(float soundsVol)
    {
        SoundManager.instance.ChangeVolumeSound(soundsVol);
    }

    public void ChangeMusicVolume(float musicVol)
    {
        SoundManager.instance.ChangeVolumeMusic(musicVol);
    }
}
