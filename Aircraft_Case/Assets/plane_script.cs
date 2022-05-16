using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plane_script : MonoBehaviour
{
    public GameObject point_ui;
    Vector3 org_scale;
    void Start()
    {
        org_scale = point_ui.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "center")
        {


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
            Destroy(other.transform.parent.GetChild(0).gameObject);
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
            Destroy(other.transform.parent.GetChild(0).gameObject);
            Destroy(other.transform.parent.GetChild(1).gameObject);

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

    }
}
