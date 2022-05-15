using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane_movment : MonoBehaviour
{
    public float speed;
    public FloatingJoystick floatingjoystick;
    public bool control = true;
    public bool move_control = true;
    public void FixedUpdate()
    {
       
        if (control) transform.Rotate(-floatingjoystick.Vertical/2, +floatingjoystick.Horizontal/3, -floatingjoystick.Horizontal/2);
        if (move_control) transform.position += transform.forward * Time.deltaTime * speed;
       
    }
}
