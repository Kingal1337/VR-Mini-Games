using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TennisGameManager : MonoBehaviour
{
    public enum Sound {
        Ball_Hit,
        Target_Shatter
    }

    public AudioSource playerAudioSource;
    public AudioClip ballHitClip;
    public AudioClip shatterClip;

    public TextMeshPro scoreText;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score + "";
    }

    public void AddScore(int score) {
        this.score += score;
    }

    public void Reset() {
        score = 0;
    }

    public void PlaySound(AudioSource source, Sound sound) {//null for default source a.k.a the player
        switch (sound) {
            case Sound.Ball_Hit:
                PlaySound(source, ballHitClip);
                break;
            case Sound.Target_Shatter:
                PlaySound(source, shatterClip);
                break;
        }
    }

    private void PlaySound(AudioSource source, AudioClip clip) {
        if (clip == null) {
            return;
        }
        source = source == null ? playerAudioSource : source;
        source.clip = clip;
        source.Play();
    }
}
