using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Lab7_VideoEvents : MonoBehaviour
{
    public VideoPlayer vp;
    public GameObject finishPanel;

    void Start()
    {
        // Đăng ký event
        vp.prepareCompleted += OnPrepared;
        vp.loopPointReached += OnVideoFinished;

        // Chuẩn bị video trước (giảm giật/đen frame đầu)
        vp.Prepare();

        if (finishPanel != null)
            finishPanel.SetActive(false);
    }

    void OnPrepared(VideoPlayer source)
    {
        Debug.Log("Video prepared!");
        // Có thể auto play luôn, hoặc để bạn bấm V như Lab5
        // source.Play();
    }

    void OnVideoFinished(VideoPlayer source)
    {
        Debug.Log("Video finished!");
        if (finishPanel != null)
            finishPanel.SetActive(true);
    }

    // Gắn vào nút REPLAY
    public void Replay()
    {
        if (finishPanel != null)
            finishPanel.SetActive(false);

        vp.Stop();
        vp.time = 0;
        vp.Play();
    }

    // (Tuỳ chọn) nút SKIP để kết thúc ngay
    public void Skip()
    {
        OnVideoFinished(vp);
    }
}

