using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public FloatingJoystick floatingjoystick;
    public bool control = true;
    public void FixedUpdate()
    {
        
        if(control) transform.Rotate(-floatingjoystick.Vertical, 0.0f, -floatingjoystick.Horizontal);
        transform.position += transform.forward * Time.deltaTime * speed;
        
    }
}