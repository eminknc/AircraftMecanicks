using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneScript : MonoBehaviour
{
    private int count = 0;
    public bool failOrCompleteCase = false;
    public GameObject[] rings = new GameObject[12];
    public GameObject pointUI;
    private Vector3 orgScale;
    public GameObject failPanel;
    public Transform deadRoadUI;

    private void Start()
    {
        StartCoroutine(CountTimer());
        orgScale = pointUI.transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "center")
        {
            HandleRingCollision(other, 10, new Color32(248, 255, 0, 0), new Color32(255, 245, 119, 255), new Color32(115, 112, 0, 255));
        }
        else if (other.gameObject.name == "circle")
        {
            HandleRingCollision(other, 5, new Color32(248, 255, 0, 0), new Color32(173, 173, 173, 255), new Color32(233, 233, 233, 255));
        }
        else if (other.gameObject.name == "around")
        {
            HandleRingCollision(other, -5, new Color32(255, 56, 0, 0), new Color32(255, 130, 119, 255), new Color32(250, 20, 0, 255));
        }
        else if (other.gameObject.tag == "terrain")
        {
            StartCoroutine(Wait());
        }
    }

    private void HandleRingCollision(Collider other, int score, Color32 materialColor, Color32 pointUIColor, Color32 textColor)
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

        other.transform.parent.parent.GetComponent<MeshRenderer>().material.DOColor(materialColor, 0.2f);

        pointUI.gameObject.SetActive(true);

        pointUI.transform.GetChild(0).GetComponent<Text>().text = score > 0 ? "+" + score.ToString() : score.ToString();

        pointUI.GetComponent<Image>().color = pointUIColor;
        pointUI.transform.GetChild(0).GetComponent<Text>().color = textColor;

        pointUI.transform.localScale = orgScale;

        pointUI.GetComponent<Image>().DOColor(new Color32(pointUIColor.r, pointUIColor.g, pointUIColor.b, 0), 1f);
        pointUI.transform.GetChild(0).GetComponent<Text>().DOColor(new Color32(textColor.r, textColor.g, textColor.b, 0), 1f);
        pointUI.transform.DOScale(0.7f, 1f);
    }

    private IEnumerator Wait()
    {
        failOrCompleteCase = true;
        GetComponent<PlaneMovment>().moveControl = false;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        failPanel.SetActive(true);
    }

    private IEnumerator CountTimer()
    {
        yield return new WaitForSeconds(9);
        while (true)
        {
            yield return new WaitForSeconds(1);
            count++;
            if (count == 8 && !failOrCompleteCase)
            {
                deadRoadUI.gameObject.SetActive(true);
                DeadRoadAnim(1);
            }
            if (count == 15 && !failOrCompleteCase)
            {
                deadRoadUI.gameObject.SetActive(false);
                StartCoroutine(Wait());
                break;
            }
        }
    }

    private void DeadRoadAnim(int animationIndex)
    {
        deadRoadUI.localScale = Vector3.one;
        deadRoadUI.DOScale(0.7f, 1).OnComplete(() => DeadRoadAnim(animationIndex == 1 ? 2 : 1));
    }
}