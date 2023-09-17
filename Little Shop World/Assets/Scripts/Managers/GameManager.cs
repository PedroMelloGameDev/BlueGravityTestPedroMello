using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    bool isPaused = false;
    [SerializeField] GameObject pauseScreen;

    [SerializeField] GameObject blockedPath;
    [SerializeField] GameObject coolestHat;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        blockedPath.SetActive(true);
        coolestHat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseAndResume();
        }
    }
    public void PauseAndResume()
    {
        if(!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
        else if(isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
    }
    public void OpenPath()
    {
        blockedPath.SetActive(false);
        coolestHat.SetActive(true);
    }
}
