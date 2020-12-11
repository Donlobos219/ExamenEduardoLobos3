using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    private CarController carcontroller;
    public ParticleSystem flame;
    
    // Start is called before the first frame update
    private void Start()
    {  
        carcontroller = GameObject.FindGameObjectWithTag("BoxCollider3").GetComponent<CarController>();
        flame.Stop();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && carcontroller.currentTurbo > 0)
        {
            flame.Play();
            if(Input.GetKeyDown(KeyCode.E) && carcontroller.currentTurbo == -1)
            {
                Debug.Log("NoTurbo");
                flame.Stop();
            }
        }

        




        if (Input.GetKeyUp(KeyCode.E))
        {
            flame.Stop();
        }
    }
}
