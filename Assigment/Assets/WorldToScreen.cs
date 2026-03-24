using UnityEngine;

public class WorldToScreen : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        // Cho Cube tự chạy qua phải
        transform.position += Vector3.right * speed * Time.deltaTime;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Debug.Log(screenPos);
    }
}
