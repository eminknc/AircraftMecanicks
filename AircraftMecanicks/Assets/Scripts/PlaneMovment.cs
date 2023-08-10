using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovment : MonoBehaviour
{
    public float speed;
    public FloatingJoystick floatingJoystick;
    public bool control = true;
    public bool moveControl = true;
    public GameObject engineEffects;
    public GameObject completePanel;

    private void FixedUpdate()
    {
        RotatePlane();
        MovePlane();
    }

    private void RotatePlane()
    {
        if (control)
        {
            float rotationX = -floatingJoystick.Vertical / 2;
            float rotationY = floatingJoystick.Horizontal / 3;
            float rotationZ = -floatingJoystick.Horizontal / 2;

            transform.Rotate(rotationX, rotationY, rotationZ);
        }
    }

    private void MovePlane()
    {
        if (moveControl)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }

    public void GetStop()
    {
        engineEffects.SetActive(false);
        moveControl = true;

        DOTween.To(() => speed, x => speed = x, 0, 8);

        StartCoroutine(WaitToStop());
    }

    private IEnumerator WaitToStop()
    {
        yield return new WaitForSeconds(6);
        completePanel.SetActive(true);
    }
}