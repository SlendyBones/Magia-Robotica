using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class SoundManager : MonoBehaviour
{

    public AudioClip[] sounds;
    public AudioClip[] music;
    public AudioSource[] sfxChannel;
    public AudioSource[] musicChannel;

    public float volumeSFX;
    public float volumeMusic;

    public static SoundManager instance;

    void Awake()
    {
        if (PlayerPrefs.HasKey("PREFS_VolumeSFX"))
        {
            volumeSFX = PlayerPrefs.GetFloat("PREFS_VolumeSFX");
            volumeMusic = PlayerPrefs.GetFloat("PREFS_VolumeMusic");
        }
        else
        {
            PlayerPrefs.SetFloat("PREFS_VolumeSFX", volumeSFX);
            PlayerPrefs.SetFloat("PREFS_VolumeMusic", volumeSFX);
        }

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        sfxChannel = new AudioSource[sounds.Length];
        for (int i = 0; i < sfxChannel.Length; i++)
        {
            sfxChannel[i] = gameObject.AddComponent<AudioSource>();
            sfxChannel[i].clip = sounds[i];
        }

        musicChannel = new AudioSource[music.Length];
        for (int i = 0; i < musicChannel.Length; i++)
        {
            musicChannel[i] = gameObject.AddComponent<AudioSource>();
            musicChannel[i].clip = music[i];
        }

    }
    
    public int AddSFXSource(AudioSource myAudioSource)
    {
        List<AudioSource> tempList = new List<AudioSource>();

        tempList.AddRange(sfxChannel);
        tempList.Add(myAudioSource);

        sfxChannel = tempList.ToArray();

        return (sfxChannel.Length - 1);
    }

    public bool isSoundPlaying(SoundID id)
    {
        return sfxChannel[(int)id].isPlaying;
    }

    public void PlaySound(SoundID id, bool loop = false, float pitch = 1)
    {
        sfxChannel[(int)id].Play();
        sfxChannel[(int)id].loop = loop;
        sfxChannel[(int)id].volume = volumeSFX;
        sfxChannel[(int)id].pitch = pitch;  
    }

    public void PlaySoundByID(int id, bool loop = false, float pitch = 1)
    {
        sfxChannel[id].Play();
        sfxChannel[id].loop = loop;
        sfxChannel[id].volume = volumeSFX;
        sfxChannel[id].pitch = pitch;
    }

    public void StopAllSounds()
    {
        for (int i = 0; i < sfxChannel.Length; i++)
        {
            sfxChannel[i].Stop();
        }
    }

    public void PauseAllSounds()
    {
        for (int i = 0; i < sfxChannel.Length; i++)
        {
            sfxChannel[i].Pause();
        }
    }

    public void ResumeAllSounds()
    {
        for (int i = 0; i < sfxChannel.Length; i++)
        {
            sfxChannel[i].UnPause();
        }
    }

    public void StopSound(SoundID id)
    {
        sfxChannel[(int)id].Stop();
    }

    public void PauseSound(SoundID id)
    {
        sfxChannel[(int)id].Pause();
    }

    public void ResumeSound(SoundID id)
    {
        sfxChannel[(int)id].UnPause();
    }

    public void ToggleMuteSound(SoundID id)
    {
        sfxChannel[(int)id].mute = !sfxChannel[(int)id].mute;
    }

    public void ChangeVolumeSound(float volume)
    {
        volumeSFX = volume;
        for (int i = 0; i < sfxChannel.Length; i++)
        {
            sfxChannel[i].volume = volumeSFX;
        }
        PlayerPrefs.SetFloat("PREFS_VolumeSFX", volume);
    }

    public bool isMusicPlaying(MusicID id)
    {
        return musicChannel[(int)id].isPlaying;
    }

    public void PlayMusic(MusicID id, bool loop = true, float pitch = 1)
    {
        musicChannel[(int)id].Play();
        musicChannel[(int)id].loop = loop;
        musicChannel[(int)id].volume = volumeMusic;
        musicChannel[(int)id].pitch = pitch;
    }

    public void StopAllMusic()
    {
        for (int i = 0; i < musicChannel.Length; i++)
        {
            musicChannel[i].Stop();
        }
    }

    public void PauseAllMusic()
    {
        for (int i = 0; i < musicChannel.Length; i++)
        {
            musicChannel[i].Pause();
        }
    }

    public void ResumeAllMusic()
    {
        for (int i = 0; i < musicChannel.Length; i++)
        {
            musicChannel[i].UnPause();
        }
    }

    public void StopMusic(MusicID id)
    {
        musicChannel[(int)id].Stop();
    }

    public void PauseMusic(MusicID id)
    {
        musicChannel[(int)id].Pause();
    }

    public void ResumeMusic(MusicID id)
    {
        musicChannel[(int)id].UnPause();
    }

    public void ToggleMuteMusic(MusicID id)
    {
        musicChannel[(int)id].mute = !musicChannel[(int)id].mute;
    }

    public void ChangeVolumeMusic(float volume)
    {
        volumeMusic = volume;
        for (int i = 0; i < musicChannel.Length; i++)
        {
            musicChannel[i].volume = volumeMusic;
        }
        PlayerPrefs.SetFloat("PREFS_VolumeMusic", volume);
    }
}

public enum SoundID
{
    Buttons,
    Construction,
    Bag,
    Pick,
    Machine,            //0
    Generator,           //1
    Spawn,          //2
    Steps,          //3
    Error            //4
                     //5
                     //6
                     //7
                     //8
                     //9
                     //10
                     //11
                     //12
                     //13
                     //14
                     //15
                     //16
                     //17
                     //18
                     //19
                     //20
                     //21
                     //22
                     //23
                     //24
                     //25
                     //26
                     //27
                     //28
                     //29
                     //30
                     //31
                     //32
                     //33    
                     //34
                     //35
                     //36
                     //37
                     //38
                     //39
                     //40
                     //41
                     //42
                     //43
                     //44
                     //45
                     //46
}

public enum MusicID
{
    ChillMusic,
    ChillMusic2,
    Sasterfac1,
    ChillMusic3
}