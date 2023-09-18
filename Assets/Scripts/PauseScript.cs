using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PauseScript : MonoBehaviour
{
  
    public Toggle pauseToggle;
    public Button backButton;
    public GameObject panel;
    public AudioSource buttonSound;
    [SerializeField] AudioLowPassFilter pausedMusic;
    [SerializeField] AudioSource bgMusicPause;
    // Start is called before the first frame update

    private void Start()
    {
       panel.SetActive(false);
        pausedMusic = bgMusicPause.GetComponent<AudioLowPassFilter>();
        buttonSound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    [SerializeField] private bool isPaused = true;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseResume();
        }
        if (Input.GetKeyDown(KeyCode.Home))
        {
            ReturnOnClick();
        }
    }


    //register this function on the button
    public void pauseResume()
    {
        if (isPaused == true)
        {
            buttonSound.Play();
            Debug.Log("Game Paused");
            isPaused = false;
            Time.timeScale = 0f;
            panel.SetActive(true);
            pausedMusic.enabled = true;
        }
        else
        {
            buttonSound.Play();
            Debug.Log("Game Resumed");
            isPaused = true;
            Time.timeScale = 1f;
            panel.SetActive(false);
            pausedMusic.enabled = false;
        }
    }

    public void ReturnOnClick()
    {
        buttonSound.Play();
            Debug.Log("Return to main menu.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
    }
}
