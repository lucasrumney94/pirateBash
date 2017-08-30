using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatAI : MonoBehaviour
{
    public float value = 5.0f;
    public float speed = 100.0f;
    public float turnSpeed = 100.0f;
    public float rightingForce = 500.0f;
    public float TimeToSwitchTurn;

    private float thrust;
    private float torque;
    private Rigidbody rb;
    private Vector3 myThrustVector;
    private Vector3 myTorqueVector;
    private Quaternion targetRotation;
    private List<float> myTurnDirection;
    private int leftOrRight;
    private bool continueCoroutine = true;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        myThrustVector = Vector3.zero;
        myTorqueVector = Vector3.zero;
        StartCoroutine(SwitchDirection());
        myTurnDirection = new List<float>();
        myTurnDirection.Add(-1.0f);
        myTurnDirection.Add(1.0f);
        myTurnDirection.Add(0.0f);
        myTurnDirection.Add(0.6f);
        myTurnDirection.Add(-0.6f);
        leftOrRight = Random.Range(0, 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        thrust = speed;
        myThrustVector.z = thrust;
        rb.AddRelativeForce(myThrustVector);

        torque = myTurnDirection[leftOrRight] * turnSpeed;




        myTorqueVector.y = torque;


        rb.AddTorque(rightingForce * Vector3.Cross(transform.up, Vector3.up), ForceMode.Force);

        rb.AddRelativeTorque(myTorqueVector);
    }

    IEnumerator SwitchDirection()
    {
        while(continueCoroutine)
        {
            leftOrRight = Random.Range(0, 2);
            //Debug.Log(torque);
            yield return new WaitForSeconds(TimeToSwitchTurn);

        }

        
    }
}