using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_fallow : MonoBehaviour
{
    public Transform target;
    public float fallow_speed;
    public Vector3 ofset;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = target.position - ofset;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * fallow_speed);
    }
}
