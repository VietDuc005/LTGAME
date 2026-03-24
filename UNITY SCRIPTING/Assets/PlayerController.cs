using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Lab 1: Lifecycle Debugger
    void Awake() => Debug.Log("Lifecycle: Awake");
    void OnEnable() => Debug.Log("Lifecycle: OnEnable");
    void Start() => Debug.Log("Lifecycle: Start");

    // Lab 2: Vector Movement & Normalize
    public float speed = 5f;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); // A, D
        float y = Input.GetAxisRaw("Vertical");   // W, S

        Vector2 moveInput = new Vector2(x, y);

        // Normalize để đi chéo không bị nhanh hơn
        if (moveInput.magnitude > 1) moveInput = moveInput.normalized;

        transform.Translate(moveInput * speed * Time.deltaTime);
    }
}