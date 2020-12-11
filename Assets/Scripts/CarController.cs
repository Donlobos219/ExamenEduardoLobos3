using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody car;

    public float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrength = 180f, gravityForce = 10f, dragOnGround = 3f;

    private float speedInput, turnInput;

    private bool grounded;

    public LayerMask whatIsGround;
    public float groundRayLegnth = .5f;
    public Transform groundRayPoint;

    public Transform leftFrontWheel, rightFrontWheel;
    public float maxWheelTurn = 25f;

    public int maxTurbo = 100;
    public int minTurbo = 0;
    public int currentTurbo;
    public BoostBar turboBar;

    public int vehicleHealth = 3;

    public static Vector3 playerPos;

    public GameObject highlyDamagedVehicle;
    public GameObject normalVehicle;
    public GameObject damagedVehicle;
    

    // Start is called before the first frame update
    void Start()
    {      
        StartCoroutine(TrackPlayer());        
        highlyDamagedVehicle.SetActive(false);
        damagedVehicle.SetActive(false);
        normalVehicle.SetActive(true);
        currentTurbo = maxTurbo;
        car.transform.parent = null;
        turboBar.SetMaxTurbo(maxTurbo);
    }

    // Update is called once per frame
    void Update()
    {
        if (vehicleHealth == 2)
        {
            highlyDamagedVehicle.SetActive(false);
            damagedVehicle.SetActive(true);
            normalVehicle.SetActive(false);
            
        }

        if (vehicleHealth == 1)
        {
            highlyDamagedVehicle.SetActive(true);
            damagedVehicle.SetActive(false);
            normalVehicle.SetActive(false);
            
        }

        if (vehicleHealth == 3)
        {
            highlyDamagedVehicle.SetActive(false);
            damagedVehicle.SetActive(false);
            normalVehicle.SetActive(true);
        }


        speedInput = 0f;
        if(Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f;
            if (Input.GetKey(KeyCode.E))
            {
                UseTurbo(1);
                if (Input.GetKey(KeyCode.E) && currentTurbo > 0)
                {
                    speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f * 3f;
                }    
            }

            else

            {
               speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f;
            } 
        }
        
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel * 1000f;
        }

        
        
        turnInput = Input.GetAxis("Horizontal");

        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
        }

        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) -180, leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, turnInput * maxWheelTurn, rightFrontWheel.localRotation.eulerAngles.z);


        transform.position = car.transform.position;
    }

    void UseTurbo(int doTurbo)
    {
        currentTurbo = Mathf.Clamp(currentTurbo, 0, 100);
        currentTurbo -= doTurbo;

        turboBar.SetTurbo(currentTurbo);
        
    }


    public void SwitchDamagedVehicle()
    {               
            GameObject.Instantiate(damagedVehicle, transform);
            

    }
    
    private void FixedUpdate()
    {
        if (vehicleHealth > 3)
        {
            vehicleHealth = 3;
        }
        grounded = false;
        RaycastHit hit;

        if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLegnth, whatIsGround))
        {
            grounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if (grounded)
        {
            car.drag = dragOnGround;

            if (Mathf.Abs(speedInput) > 0)
            {
                car.AddForce(transform.forward * speedInput);
            }
        }

        else
        {
            car.drag = 0.1f;

            car.AddForce(Vector3.up * -gravityForce * 100f);
        }
    }

    IEnumerator TrackPlayer()
    {
        while (true)
        {
            playerPos = gameObject.transform.position;
            yield return null;
        }
    }
}
