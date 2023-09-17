using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioScript instance;

    [SerializeField] AudioSource effectSoundSource; //source where the audio will come out off

    [SerializeField] AudioClip buttonSound;
    [SerializeField] AudioClip playerAttackSound;
    [SerializeField] AudioClip interactSound;
    [SerializeField] AudioClip coinSound;
    [SerializeField] AudioClip victorySound;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    public void PlayButtonSound()
    {
        effectSoundSource.PlayOneShot(buttonSound);
    }
    public void PlayerAttack()
    {
        effectSoundSource.PlayOneShot(playerAttackSound);
    }
    public void InteractSound()
    {
        effectSoundSource.PlayOneShot(interactSound);
    }
    public void CoinSound()
    {
        effectSoundSource.PlayOneShot(coinSound);
    }
    public void VictorySound()
    {
        effectSoundSource.PlayOneShot(victorySound);
    }
}
