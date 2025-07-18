using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("Clips")]
    public AudioClip backgroundMusic;
    public AudioClip eatSFX;
    public AudioClip playerDieSFX;
    public AudioClip gameOverSFX;
    public AudioClip enemySpawnSFX;
    public AudioClip BoosterSFX;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (backgroundMusic != null)
        {
            bgmSource.clip = backgroundMusic;
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }

    public void PlayEatSFX()
    {
        PlaySFX(eatSFX);
    }

    public void PlayPlayerDieSFX()
    {
        PlaySFX(playerDieSFX);
    }

    public void PlayGameOverSFX()
    {
        PlaySFX(gameOverSFX);
    }

    public void PlayEnemySpawnSFX()
    {
        PlaySFX(enemySpawnSFX);
    }

    public void PlayBoosterSFX()
    {
        PlaySFX(BoosterSFX);
    }
}
