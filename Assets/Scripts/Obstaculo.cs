using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float velocity;
    public float zerovelocity = 0f;
    public bool destruible;
    public GameObject obstaculo;
    private TimeManager timemanager;
    public AudioSource source;
    public AudioClip[] carHorn;

    // Start is called before the first frame update
    void Start()
    {
        //timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }

    void MueveObstaculo()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DestroyTrigger")==true && destruible == true)
        {
            Destroy(gameObject);
        }

        if(other.gameObject.tag == ("DestroyCarrosNivel2"))
        {
            Destroy(gameObject);
        }

        if(other.gameObject.tag == ("BoxCollider3"))
        {
            source.clip = carHorn[Random.Range(0, carHorn.Length)];
            source.Play();
            
        }





    
    }
    // Update is called once per frame
    void Update()
    {
        
        //MueveObstaculo();
        //if (timemanager.TimeIsStopped)
        //{
            //GetComponent<Rigidbody>().position += Vector3.back * zerovelocity * Time.deltaTime;

        //}
        //else
        {
            GetComponent<Rigidbody>().position += Vector3.right * velocity * Time.deltaTime;
        }
        
    }
}
