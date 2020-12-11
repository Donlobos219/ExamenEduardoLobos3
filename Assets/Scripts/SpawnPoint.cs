using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private TimeManager timemanager;
    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public float spawnLeastWaitZero = 10000f;
    public float spawnMostWaitZero = 10000f;
    public int startWait;
    public bool stop;

    public bool canSpawn;

    public Transform Spawnpoint;
    public GameObject Prefab;

    int randEnemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
        ///timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
            spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
               
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while(!stop)
        {
            randEnemy = Random.Range(0, 2);

            Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
            //if (timemanager.TimeIsStopped)
            {
                
            }

            //else
            {
                Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            }
            

            yield return new WaitForSeconds(spawnWait);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
    }

    
    //void CanStartSpawn()
    //{
        //if (timemanager.TimeIsStopped)
        //{
            //canSpawn = true;
        //}

        //else
        //{
            //canSpawn = false;
        //}
    //}
}
