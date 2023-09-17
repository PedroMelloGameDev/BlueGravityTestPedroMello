using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioScript instance;

    [SerializeField] AudioSource effectSoundSource;

    [SerializeField] AudioClip buttonSound; 

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButtonSound()
    {
        effectSoundSource.PlayOneShot(buttonSound);
    }
}
