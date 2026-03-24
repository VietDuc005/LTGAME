using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Lab5_Video : MonoBehaviour
{
    public VideoPlayer vp;

    void Start()
    {
        vp.playOnAwake = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!vp.isPrepared)
            {
                vp.prepareCompleted += OnPrepared;
                vp.Prepare();
            }
            else if (!vp.isPlaying)
            {
                vp.Play();
            }
        }
    }

    void OnPrepared(VideoPlayer source)
    {
        source.prepareCompleted -= OnPrepared;
        source.Play();
    }
}
