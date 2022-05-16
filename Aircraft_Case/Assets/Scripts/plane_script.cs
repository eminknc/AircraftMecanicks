using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plane_script : MonoBehaviour
{
    int count = 0;
    public bool fail_or_complate_case = false;
    public GameObject[] rings = new GameObject[12];
    public GameObject point_ui;
    Vector3 org_scale;
    public GameObject fail_panel;
    public Transform dead_road_ui;
    void Start()
    {
        StartCoroutine(count_timer());
        org_scale = point_ui.transform.localScale;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "center")
        {
            count = 0;
            for (int i = 0; i < rings.Length; i++)
            {
                if (other.transform.parent.parent.gameObject == rings[i])
                {
                    if (rings[i + 1])
                    {
                        rings[i + 1].SetActive(true);
                        if (i != 10) rings[i + 2].SetActive(true);
                    }
                    break;
                }
            }
            Destroy(other.transform.parent.GetChild(0).gameObject);
            Destroy(other.transform.parent.GetChild(1).gameObject);
            Destroy(other.transform.parent.GetChild(2).gameObject);

            other.transform.parent.parent.GetComponent<MeshRenderer>().material.DOColor(new Color32(248, 255, 0, 0), 0.2f);

            point_ui.gameObject.SetActive(true);

            point_ui.transform.GetChild(0).GetComponent<Text>().text = "+10";

            point_ui.GetComponent<Image>().color = new Color32(255, 245, 119, 255);
            point_ui.transform.GetChild(0).GetComponent<Text>().color = new Color32(115, 112, 0, 255);

            point_ui.transform.localScale = org_scale;

            point_ui.GetComponent<Image>().DOColor(new Color32(255, 245, 119, 0), 1f);
            point_ui.transform.GetChild(0).GetComponent<Text>().DOColor(new Color32(115, 112, 0, 0), 1f);
            point_ui.transform.DOScale(0.7f, 1f);


        }
        else if (other.gameObject.name == "circle")
        {
            count = 0;
            for (int i = 0; i < rings.Length; i++)
            {
                if (other.transform.parent.parent.gameObject == rings[i])
                {
                    if (rings[i + 1])
                    {
                        rings[i + 1].SetActive(true);
                        if (i != 10) rings[i + 2].SetActive(true);
                    }
                    break;
                }
            }

            Destroy(other.transform.parent.GetChild(0).gameObject);
            Destroy(other.transform.parent.GetChild(1).gameObject);
            Destroy(other.transform.parent.GetChild(2).gameObject);

            other.transform.parent.parent.GetComponent<MeshRenderer>().material.DOColor(new Color32(248, 255, 0, 0), 0.2f);

            point_ui.gameObject.SetActive(true);

            point_ui.transform.GetChild(0).GetComponent<Text>().text = "+5";

            point_ui.GetComponent<Image>().color = new Color32(173, 173, 173, 255);
            point_ui.transform.GetChild(0).GetComponent<Text>().color = new Color32(233, 233, 233, 255);

            point_ui.transform.localScale = org_scale;

            point_ui.GetComponent<Image>().DOColor(new Color32(173, 173, 173, 0), 1f);
            point_ui.transform.GetChild(0).GetComponent<Text>().DOColor(new Color32(233, 233, 233, 0), 1f);
            point_ui.transform.DOScale(0.7f, 1f);
        }
        else if (other.gameObject.name == "around")
        {
            count = 0;
            for (int i = 0; i < rings.Length; i++)
            {
                if (other.transform.parent.parent.gameObject == rings[i])
                {
                    if (rings[i + 1])
                    {
                        rings[i + 1].SetActive(true);
                        if (i != 10) rings[i + 2].SetActive(true);
                    }
                    break;
                }
            }

            Destroy(other.transform.parent.GetChild(0).gameObject);
            Destroy(other.transform.parent.GetChild(1).gameObject);
            Destroy(other.transform.parent.GetChild(2).gameObject);

            other.transform.parent.parent.GetComponent<MeshRenderer>().material.DOColor(new Color32(255, 56, 0, 0), 0.2f);

            point_ui.gameObject.SetActive(true);

            point_ui.transform.GetChild(0).GetComponent<Text>().text = "-5";

            point_ui.GetComponent<Image>().color = new Color32(255, 130, 119, 255);
            point_ui.transform.GetChild(0).GetComponent<Text>().color = new Color32(250, 20, 0, 255);

            point_ui.transform.localScale = org_scale;

            point_ui.GetComponent<Image>().DOColor(new Color32(255, 130, 119, 0), 1f);
            point_ui.transform.GetChild(0).GetComponent<Text>().DOColor(new Color32(250, 20, 0, 0), 1f);
            point_ui.transform.DOScale(0.7f, 1f);
        }
        else if (other.gameObject.tag == "terrain")
        {

            StartCoroutine(wait());

        }
    }
    IEnumerator wait()
    {
        fail_or_complate_case = true;
        GetComponent<plane_movment>().move_control = false;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        fail_panel.SetActive(true);

    }
    IEnumerator count_timer()
    {
        yield return new WaitForSeconds(9);
        for (; ; )
        {
            yield return new WaitForSeconds(1);
            count++;
            if (count == 8 && fail_or_complate_case == false)
            {

                dead_road_ui.gameObject.SetActive(true);
                dead_road_anim_1();
            }
            if (count == 15 && fail_or_complate_case == false)
            {
                dead_road_ui.gameObject.SetActive(false);
                StartCoroutine(wait());
                break;
            }

        }

    }
    void dead_road_anim_1()
    {
        dead_road_ui.localScale = new Vector3(1, 1, 1);
        dead_road_ui.DOScale(0.7f, 1).OnComplete(() => dead_road_anim_2());

    }
    void dead_road_anim_2()
    {
        dead_road_ui.localScale = new Vector3(1, 1, 1);
        dead_road_ui.DOScale(0.7f, 1).OnComplete(() => dead_road_anim_1());

    }
}
