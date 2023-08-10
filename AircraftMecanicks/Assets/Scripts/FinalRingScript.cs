using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRingScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GamePlayScript gamePlayScript = Camera.main.GetComponent<GamePlayScript>();
            CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();

            if (gamePlayScript != null)
            {
                gamePlayScript.Landing();
            }

            if (cameraFollow != null)
            {
                cameraFollow.IsLanding = true;
            }
        }
    }
}