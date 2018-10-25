using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BackgroundMusicController : MonoBehaviour {
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip gameMusic;

    private AudioSource audioSource;

    private void Awake()
    {
       audioSource = GetComponent<AudioSource>();
        Assert.IsNotNull(audioSource);
        Assert.IsNotNull(menuMusic);
        Assert.IsNotNull(gameMusic);

    }

    void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {
        var clipToPlay = GameManager.Instance.GameStarted ?
            gameMusic : menuMusic;
        PlayMusic(clipToPlay);
	}

    private void PlayMusic(AudioClip clipToPlay)
    {
        if (audioSource.clip != clipToPlay)
        {
            audioSource.clip = clipToPlay;
            audioSource.Play();
         }
    }
}
