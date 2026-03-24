using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab1_Control : MonoBehaviour
{
    public AudioSource myAudioSource; // Kéo AudioSource vào đây trong Inspector

    void Update()
    {
        // Nhấn Space để Play
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!myAudioSource.isPlaying) // Kiểm tra để tránh phát chồng
            {
                myAudioSource.Play();
                Debug.Log("Audio Playing");
            }
        }

        // Nhấn S để Stop
        if (Input.GetKeyDown(KeyCode.S))
        {
            myAudioSource.Stop();
            Debug.Log("Audio Stopped");
        }
    }
}
