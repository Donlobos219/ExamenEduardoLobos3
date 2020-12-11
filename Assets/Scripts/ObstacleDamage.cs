using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    public GameObject destuctibleObject;
    public GameObject explosion;
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
    public void hurtPlayer(int damage)
    {
        carcontroller.vehicleHealth -= damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BoxCollider3")
        {
            
            Instantiate(explosion, transform.position, Quaternion.identity);
            GameObject destrutibleBox = Instantiate(destuctibleObject, transform.position, transform.rotation) as GameObject;
            Rigidbody[] allRigibodies = destrutibleBox.GetComponentsInChildren<Rigidbody>();
            if (allRigibodies.Length > 0)
            {
                foreach(var body in allRigibodies)
                {
                    body.AddExplosionForce(500, transform.position, 1);
                }
            }
            hurtPlayer(1);
            Destroy(gameObject);
        }
    }
}
