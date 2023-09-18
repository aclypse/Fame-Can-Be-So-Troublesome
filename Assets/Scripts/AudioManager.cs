using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioLowPassFilter underwaterFilter;
    public AudioSource bgMusic;

    private bool isUnderwater = false;

    private void Start()
    {
        // Initialize references
        underwaterFilter = bgMusic.GetComponent<AudioLowPassFilter>();
    }

    private void Update()
    {
        // Check for pause input (e.g., pressing Escape)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleUnderwaterEffect();
        }
    }

    public void ToggleUnderwaterEffect()
    {
        isUnderwater = !isUnderwater;

        // Apply the underwater filter effect based on the 'isUnderwater' flag
        if (isUnderwater)
        {
            // Enable the low-pass filter (underwater effect)
            underwaterFilter.enabled = true;
        }
        else
        {
            // Disable the low-pass filter (normal effect)
            underwaterFilter.enabled = false;
        }
    }
}

