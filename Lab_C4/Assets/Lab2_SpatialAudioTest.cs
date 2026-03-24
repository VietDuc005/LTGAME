using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab2_SpatialAudioTest : MonoBehaviour
{
    public AudioSource emitter;     // AudioSource gắn trên SoundEmitter
    public Transform listenerTarget; // Thường là Main Camera (có AudioListener)

    public float moveSpeed = 5f;

    void Update()
    {
        // Di chuyển "tai nghe" (camera) để test gần/xa
        if (listenerTarget != null)
        {
            float h = Input.GetAxis("Horizontal"); // A/D
            float v = Input.GetAxis("Vertical");   // W/S
            listenerTarget.Translate(new Vector3(h, 0, v) * moveSpeed * Time.deltaTime);
        }

        // Nhấn 1 -> chuyển sang 2D
        if (Input.GetKeyDown(KeyCode.Alpha1) && emitter != null)
        {
            emitter.spatialBlend = 0f;
            Debug.Log("Mode: 2D (Spatial Blend = 0)");
        }

        // Nhấn 2 -> chuyển sang 3D
        if (Input.GetKeyDown(KeyCode.Alpha2) && emitter != null)
        {
            emitter.spatialBlend = 1f;
            Debug.Log("Mode: 3D (Spatial Blend = 1)");
        }
    }
}
