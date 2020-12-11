using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHeal : MonoBehaviour
{
    public GameObject healParticles;
    private CarController carcontroller;
    // Start is called before the first frame update
    void Start()
    {
        carcontroller = GameObject.FindGameObjectWithTag("BoxCollider3").GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void healPlayer(int heal)
    {
        carcontroller.vehicleHealth += heal;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BoxCollider3")
        {
            Instantiate(healParticles, transform.position, Quaternion.identity);
            healPlayer(1);
            Destroy(gameObject);
        }
    }
}
