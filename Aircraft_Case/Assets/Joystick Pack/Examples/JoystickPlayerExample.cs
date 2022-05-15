using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public FloatingJoystick floatingjoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        //Vector3 direction = Vector3.forward * floatingjoystick.Vertical + Vector3.right * floatingjoystick.Horizontal;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        transform.Rotate(-floatingjoystick.Vertical, 0.0f, -floatingjoystick.Horizontal,Space.World);
        transform.position += transform.forward * Time.deltaTime * speed;
        speed -= transform.forward.y * Time.deltaTime * 50.0f;
        if (speed < 35.0f) {
            speed = 35f;
        }
    }
}