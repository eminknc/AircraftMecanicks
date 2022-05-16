using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_play_script : MonoBehaviour
{
    public Transform plane;
    public Transform landing_start_pos;
    public Transform landing_finish_pos;
    public GameObject count_down_ui;
    void Start()
    {
        StartCoroutine(count_down());
        plane.transform.DOLocalRotate(new Vector3(-20, 0, 0), 2f).SetDelay(2.5f);
        plane.transform.DOLocalRotate(new Vector3(-10, 0, 0), 2f).SetDelay(4.5f)
            .OnComplete(()=>plane.GetComponent<plane_movment>().control=true);
    }
    public void landing() {
        plane.GetComponent<plane_movment>().control = false;
        plane.GetComponent<plane_movment>().move_control = false;
        plane.DOLocalRotate(landing_start_pos.localEulerAngles, 1);
        plane.DOMove(landing_start_pos.position, 3).SetEase(Ease.Linear).OnComplete(() => plane.GetComponent<plane_movment>().get_stop());
       
    }
    IEnumerator count_down() {
        Vector3 org_scale = count_down_ui.transform.localScale;
        for (int i=6;i>0;i-- ) {
            yield return new WaitForSeconds(1);
            count_down_ui.transform.GetChild(0).GetComponent<Text>().text = i.ToString();

            count_down_ui.GetComponent<Image>().color = new Color32(255, 245, 119, 255);
            count_down_ui.transform.localScale = org_scale;

            count_down_ui.GetComponent<Image>().DOColor(new Color32(255, 245, 119, 200), 0.8f);
            count_down_ui.transform.DOScale(0.7f, 0.8f);

        }
        yield return new WaitForSeconds(1);
        count_down_ui.GetComponent<Image>().DOColor(new Color32(255, 245, 119, 0), 1);
        count_down_ui.transform.GetChild(0).GetComponent<Text>().DOColor(new Color32(255, 245, 119, 0), 1);


    }


}
