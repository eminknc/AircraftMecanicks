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
    public GameObject engine_effects;
    public GameObject complate_panel;
    public void FixedUpdate()
    {

        if (control) transform.Rotate(-floatingjoystick.Vertical / 2, +floatingjoystick.Horizontal / 3, -floatingjoystick.Horizontal / 2);
        if (move_control) transform.position += transform.forward * Time.deltaTime * speed;

    }
    public void get_stop()
    {
        engine_effects.SetActive(false);
        move_control = true;
        DOTween.To(() => speed, x => speed = x, 0, 8);
        StartCoroutine(wait_to_stop());
    }
    IEnumerator wait_to_stop()
    {
        yield return new WaitForSeconds(6);
        complate_panel.SetActive(true);
    }
}
