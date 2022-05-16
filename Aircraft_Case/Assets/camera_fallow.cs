using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_fallow : MonoBehaviour
{
    public Transform target;
    public float fallow_speed;
    public Vector3 ofset;
    public bool is_landing = false;
    public Transform landing_camera_referans_pos;


    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (is_landing == false)
        {
            Vector3 pos = target.position - target.forward * 1.0f + Vector3.up * 5.0f;
            float declination = 0.96f;
            transform.position = transform.position * declination + pos * (1.0f - declination);
            transform.LookAt(target.position + target.forward * 30.0f);
        }
        else
        {
            transform.localPosition = landing_camera_referans_pos.position;
            Vector3 lookDirection = target.position - transform.position;
            lookDirection.Normalize();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), 10 * Time.deltaTime);





        }

    }
}
