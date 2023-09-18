using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class StartScript : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public AudioSource quitSound;

    // Start is called before the first frame update

    private void Start()
    {
        
        quitSound.GetComponent<AudioSource>();    
    }
    

    public void StartOnClick()
    {

        quitSound.Play();
        Debug.Log("Start game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void QuitOnClick()
    {

        quitSound.Play();
        Debug.Log("Quit");
        Application.Quit();
    }
}
