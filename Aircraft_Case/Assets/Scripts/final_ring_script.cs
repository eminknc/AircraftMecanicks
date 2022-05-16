using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final_ring_script : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "plane")
        {

            Camera.main.GetComponent<game_play_script>().landing();
            Camera.main.GetComponent<camera_fallow>().is_landing = true;
        }
    }
}
