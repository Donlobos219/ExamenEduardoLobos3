using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSound2 : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] explosion;
    // Start is called before the first frame update
    void Start()
    {
        source.clip = explosion[Random.Range(0, explosion.Length)];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
