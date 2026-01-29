using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour
{
    public VideoPlayer introVideo;
    public AudioSource bgm;

    bool isEnding = false;

    void Start()
    {
        if (introVideo == null)
        {
            Debug.LogError("Chưa gán introVideo!");
            return;
        }

        introVideo.loopPointReached += OnVideoFinished;

        if (!introVideo.isPlaying) introVideo.Play();
        if (bgm != null && !bgm.isPlaying) bgm.Play();
    }

    public void Skip()
    {
        EndIntro();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        EndIntro();
    }

    void EndIntro()
    {
        if (isEnding) return;
        isEnding = true;

        if (introVideo != null) introVideo.Stop();
        if (bgm != null) bgm.Stop();

        SceneManager.LoadScene("GameScene"); // đúng tên scene của bạn
    }
}

