using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScript : MonoBehaviour
{
    public Transform plane;
    public Transform landingStartPos;
    public Transform landingFinishPos;
    public GameObject countdownUI;

    void Start()
    {
        StartCoroutine(Countdown());
        plane.transform.DOLocalRotate(new Vector3(-20, 0, 0), 2f).SetDelay(2.5f);
        plane.transform.DOLocalRotate(new Vector3(-10, 0, 0), 2f).SetDelay(4.5f)
            .OnComplete(() => plane.GetComponent<PlaneMovment>().Control = true);
    }

    public void Landing()
    {
        PlaneScript planeScript = plane.GetComponent<PlaneScript>();
        PlaneMovment planeMovment = plane.GetComponent<PlaneMovment>();

        if (planeScript != null && planeMovment != null)
        {
            planeScript.FailOrCompleteCase = true;
            planeMovment.Control = false;
            planeMovment.MoveControl = false;
            plane.DOLocalRotate(landingStartPos.localEulerAngles, 1);
            plane.DOMove(landingStartPos.position, 3).SetEase(Ease.Linear).OnComplete(() => planeMovment.GetStop());
        }
    }

    IEnumerator Countdown()
    {
        Vector3 originalScale = countdownUI.transform.localScale;
        for (int i = 6; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
            countdownUI.transform.GetChild(0).GetComponent<Text>().text = i.ToString();

            Color countdownColor = new Color32(255, 245, 119, 255);
            countdownUI.GetComponent<Image>().color = countdownColor;
            countdownUI.transform.localScale = originalScale;

            countdownUI.GetComponent<Image>().DOColor(new Color32(255, 245, 119, 200), 0.8f);
            countdownUI.transform.DOScale(0.7f, 0.8f);

        }
        yield return new WaitForSeconds(1);
        Color transparentColor = new Color32(255, 245, 119, 0);
        countdownUI.GetComponent<Image>().DOColor(transparentColor, 1);
        countdownUI.transform.GetChild(0).GetComponent<Text>().DOColor(transparentColor, 1);
    }
}