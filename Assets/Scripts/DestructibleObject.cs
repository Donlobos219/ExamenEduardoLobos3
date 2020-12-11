using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    private CarController carcontroller;
    public BoostBar turboBar;
    public GameObject[] destruible;
    public int durability = 100;
    public int currentDurability; 
    public int turboToAdd = 20;

    // Start is called before the first frame update
    void Start()
    {
        currentDurability = durability;
        carcontroller = GameObject.FindGameObjectWithTag("BoxCollider3").GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDurability <= 0)
        {
            AddTurbo(turboToAdd);
            GameObject fracturedObject = Instantiate(destruible[Random.Range(0, destruible.Length)], transform.position, transform.rotation)as GameObject;
            Rigidbody[] allRigidBodies = fracturedObject.GetComponentsInChildren<Rigidbody>();
            if(allRigidBodies.Length > 0)
            {
                foreach(var body in allRigidBodies)
                {
                    body.AddExplosionForce(500, transform.position, 1);
                }
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "BoxCollider3")
        {
            hurtObject(8);   
        }
    }

    public void hurtObject(int damage)
    {
        currentDurability -= damage;
    }

    private void AddTurbo(int turbo)
    {
        carcontroller.currentTurbo += turbo;
        turboBar.SetTurbo(carcontroller.currentTurbo);

    }


}
