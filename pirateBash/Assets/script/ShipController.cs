using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {


    public float speed = 10.0f;
    public float turnSpeed = 10.0f;
    public float rightingForce = 500.0f;

    private float thrust;
    private float torque;
    private Rigidbody rb;
    private Vector3 myThrustVector;
    private Vector3 myTorqueVector;
    private Quaternion targetRotation;



    // Use this for initialization
    void Start ()
    {
        rb = this.GetComponent<Rigidbody>();
        myThrustVector = Vector3.zero;
        myTorqueVector = Vector3.zero;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        thrust = speed * Input.GetAxis("Vertical");
        myThrustVector.z = thrust;
        rb.AddRelativeForce(myThrustVector);

        torque = turnSpeed * Input.GetAxis("Horizontal");
        myTorqueVector.y = torque;
        

        rb.AddTorque(rightingForce*Vector3.Cross(transform.up, Vector3.up), ForceMode.Force);

        rb.AddRelativeTorque(myTorqueVector);
        
        

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //col.gameObject.transform.position
            Destroy(col.gameObject);
            speed+=col.gameObject.GetComponent<boatAI>().value;
            Debug.Log("my speed increased to " + speed);
        }
    }

}
