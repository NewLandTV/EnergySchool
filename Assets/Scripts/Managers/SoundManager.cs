using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    // Bgm and Sfx sound data.
    [SerializeField]
    private Sound[] bgm;
    [SerializeField]
    private Sound[] sfx;

    // Bgm player and Sfx player. (AudioSource)
    [SerializeField]
    private AudioSource bgmPlayer;
    [SerializeField]
    private AudioSource[] sfxPlayer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(string bgmName, bool loop)
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            if (bgmName.Equals(bgm[i].name))
            {
                bgmPlayer.clip = bgm[i].clip;
                bgmPlayer.loop = loop;

                bgmPlayer.Play();

                return;
            }
        }
    }

    public void PauseBGM()
    {
        bgmPlayer.Pause();
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    public void PlaySFX(string sfxName)
    {
        for (int i = 0; i < sfx.Length; i++)
        {
            if (sfxName.Equals(sfx[i].name))
            {
                for (int j = 0; j < sfxPlayer.Length; j++)
                {
                    if (!sfxPlayer[j].isPlaying)
                    {
                        sfxPlayer[j].clip = sfx[i].clip;

                        sfxPlayer[j].Play();

                        return;
                    }
                }

                return;
            }
        }
    }

    public void StopAllSFX()
    {
        for (int i = 0; i < sfxPlayer.Length; i++)
        {
            sfxPlayer[i].Stop();
        }
    }
}
