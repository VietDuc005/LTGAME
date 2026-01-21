using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed = 5f;
    public bool smooth = true;

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion targetRot = Quaternion.LookRotation(dir);

        if (smooth)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotateSpeed * Time.deltaTime
            );
        }
        else
        {
            transform.rotation = targetRot;
        }
    }
}

