using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource mainSource;

    public AudioSource effectSource;

    public AudioSource actionSource;

    public AudioClip jumpClip;

    public AudioClip bumpClip;

    public AudioClip coinClip;

    public AudioClip stompClip;

    public AudioClip winClip;

    public AudioClip dieClip;

    public void PlayCoin()
    {
        effectSource.PlayOneShot (coinClip);
    }

    public void PlayStomp()
    {
        effectSource.PlayOneShot (stompClip);
    }

    public void PlayJump()
    {
        actionSource.PlayOneShot (jumpClip);
    }

    public void PlayBump()
    {
        actionSource.PlayOneShot (bumpClip);
    }

    public void PlayWin()
    {
        mainSource.Stop();
        mainSource.PlayOneShot (winClip);
    }

    public void PlayDie()
    {
        mainSource.Stop();
        mainSource.PlayOneShot (dieClip);
    }

    public void PauseMain()
    {
        mainSource.Pause();
    }

    public void ResumeMain()
    {
        mainSource.UnPause();
    }
}
