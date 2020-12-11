using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighActivation : MonoBehaviour
{

    public Light lamplight;

    public bool on = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (on == true)

            {
                lamplight.enabled = false;
                on = false;
            }
            else
            {
                if (on == false)
                {
                    lamplight.enabled = true;
                    on = true;
                }
            }
        }
    }
}
