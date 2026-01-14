using UnityEngine;

public class CheckPos : MonoBehaviour
{
    void Start()
    {
        Debug.Log("World Position: " + transform.position);
        Debug.Log("Local Position: " + transform.localPosition);
    }
}
