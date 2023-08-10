using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float followSpeed;
    public Vector3 offset;
    public bool isLanding = false;
    public Transform landingCameraReferencePos;

    void FixedUpdate()
    {
        if (!isLanding)
        {
            Vector3 targetPos = target.position - target.forward * offset.z + Vector3.up * offset.y;
            float declination = 0.96f;
            transform.position = transform.position * declination + targetPos * (1.0f - declination);
            transform.LookAt(target.position + target.forward * 30.0f);
        }
        else
        {
            transform.localPosition = landingCameraReferencePos.position;
            Vector3 lookDirection = target.position - transform.position;
            lookDirection.Normalize();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), 10 * Time.deltaTime);
        }
    }
}