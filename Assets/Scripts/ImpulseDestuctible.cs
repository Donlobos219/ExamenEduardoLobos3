using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseDestuctible : MonoBehaviour
{
    public float impulseForce = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<Rigidbody>().AddForce(Vector3.up * impulseForce * Time.deltaTime);
    }
}
