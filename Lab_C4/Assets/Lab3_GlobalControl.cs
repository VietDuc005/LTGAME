using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3_GlobalControl : MonoBehaviour
{
    private float lastVolume = 1f;

    void Update()
    {
        // M: Mute/Unmute
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (AudioListener.volume > 0f)
            {
                lastVolume = AudioListener.volume;
                AudioListener.volume = 0f;
                Debug.Log("Muted");
            }
            else
            {
                AudioListener.volume = (lastVolume <= 0f) ? 1f : lastVolume;
                Debug.Log("Unmuted");
            }
        }

        // P: Pause/Resume toàn bộ audio
        if (Input.GetKeyDown(KeyCode.P))
        {
            AudioListener.pause = !AudioListener.pause;
            Debug.Log("Paused: " + AudioListener.pause);
        }
    }
}
