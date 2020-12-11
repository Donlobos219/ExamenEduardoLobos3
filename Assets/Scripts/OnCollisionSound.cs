using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] hurt;
    
    // Start is called before the first frame update
    void Start()
    {
        source.clip = hurt[Random.Range(0, hurt.Length)];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
