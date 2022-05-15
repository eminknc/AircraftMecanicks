using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_play_script : MonoBehaviour
{
    int timerr = 0;
    public Transform plane;
    public Transform landing_start_pos;
    public Transform landing_finish_pos;
    void Start()
    {
        
       // plane.transform.DOLocalRotate(new Vector3(-20, 0, 0), 2f).SetDelay(2.5f);
       // plane.transform.DOLocalRotate(new Vector3(-10, 0, 0), 2f).SetDelay(4.5f)
          //  .OnComplete(()=>plane.GetComponent<plane_movment>().control=true);
    }
    public void landing() {
        Debug.Log("tiiiiiiii");
        StartCoroutine(timer());
        plane.GetComponent<plane_movment>().control = false;
        plane.GetComponent<plane_movment>().move_control = false;
        plane.DOLocalRotate(landing_start_pos.localEulerAngles, 1);
        plane.DOMove(landing_start_pos.position,3).SetEase(Ease.Linear).OnComplete(()=> plane.DOMove(landing_finish_pos.position, 6).SetEase(Ease.OutCubic));
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator timer() {
        for (; ; ) {
            yield return new WaitForSeconds(1);
            timerr++;
            Debug.Log(timerr);

        }
    
    }
}
