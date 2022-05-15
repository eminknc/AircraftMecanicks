using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final_ring_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "plane") {

            Camera.main.GetComponent<game_play_script>().landing();
            Camera.main.GetComponent<camera_fallow>().is_landing = true;
        }
    }
}
