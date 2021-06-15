using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    public Circuit circuit;
    Drive ds;
    public float brakingSensitivity = 3f;
    public float steeringSensitivity = 0.01f;
    public float accSensitivity = 0.3f;
    Vector3 target;
    Vector3 nextTarget;
    int currentWP = 0;
    float totalDistanceToTarget;

    GameObject tracker;
    int currentTrackerWP = 0;
    public float lookAhead = 12; 

    // Start is called before the first frame update
    void Start()
    {
        ds = this.GetComponent<Drive>();
        target = circuit.waypoints[currentWP].transform.position;
        nextTarget = circuit.waypoints[currentWP + 1].transform.position;
        totalDistanceToTarget = Vector3.Distance(target, ds.rb.gameObject.transform.position);

        tracker = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = ds.rb.gameObject.transform.position;
        tracker.transform.rotation = ds.rb.gameObject.transform.rotation;
    }

    void ProgressTracker()
    {
        Debug.DrawLine(ds.rb.gameObject.transform.position, tracker.transform.position);

        if(Vector3.Distance(ds.rb.gameObject.transform.position, tracker.transform.position) > lookAhead)
        {
            return;
        }

        tracker.transform.LookAt(circuit.waypoints[currentTrackerWP].transform.position);
        tracker.transform.Translate(0, 0, 1.0f); //speed of tracker

        if(Vector3.Distance(tracker.transform.position, circuit.waypoints[currentTrackerWP].transform.position)< 1)
        {
            currentTrackerWP++;
            if(currentTrackerWP >= circuit.waypoints.Length)
            {
                currentTrackerWP = circuit.waypoints.Length;
            }
        }

    }

    
    // Update is called once per frame
    void Update()
    {
        ProgressTracker();
        Vector3 localTarget = ds.rb.gameObject.transform.InverseTransformPoint(tracker.transform.position);
        //Vector3 nextLocalTarget = ds.rb.gameObject.transform.InverseTransformPoint(nextTarget);
        //float distanceToTarget = Vector3.Distance(target, ds.rb.gameObject.transform.position);

        float targetAngle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
        //float nextTargetAngle = Mathf.Atan2(nextLocalTarget.x, nextLocalTarget.z) * Mathf.Rad2Deg;

        float steer = Mathf.Clamp(targetAngle * steeringSensitivity, -1, 1) * Mathf.Sign(ds.currentSpeed);
        
        //float distanceFactor = distanceToTarget / totalDistanceToTarget;
        float speedFactor = ds.currentSpeed / ds.maxSpeed;

        float corner = Mathf.Clamp(Mathf.Abs(targetAngle), 0, 90);
        float cornerFactor = corner / 90.0f;

        float brake = 0;
        if(corner > 10 && speedFactor > 0.1f)
        {
            brake = Mathf.Lerp(0, 1 + speedFactor * brakingSensitivity, cornerFactor);
        }

        float acc = 1f;
        if(corner > 20 && speedFactor > 0.2f)
        {
            acc = Mathf.Lerp(0, 1 * accSensitivity, 1 - cornerFactor);
        }
        //float acc = Mathf.Lerp(accSensitivity, 1, distanceFactor);
        //float brake = Mathf.Lerp((-1 - Mathf.Abs((nextTargetAngle))) * brakingSensitivity , 1 + speedFactor, 1 - distanceFactor);

        /*if(Mathf.Abs(nextTargetAngle) > 20)
        {
            brake += 0.8f;
            acc -= 0.8f;
        }

        if(isJump)
        {
            acc = 1;
            brake = 0;
        }*/

        Debug.Log("Brake: " + brake + "Acc: " + acc);

        //if(distanceToTarget < 5)
        //{
           // brake = 0.8f;
            //acc = 0.1f;
        //}

        ds.Go(acc, steer, brake);

        /*if(distanceToTarget < 4)  //threshold, make larger if car starts to circle waypoint
        {
            currentWP++;
            if (currentWP >= circuit.waypoints.Length)
                currentWP = 0;
            target = circuit.waypoints[currentWP].transform.position;
            if(currentWP == circuit.waypoints.Length-1)
            {
                nextTarget = circuit.waypoints[0].transform.position;
            }
            else
                nextTarget = circuit.waypoints[currentWP + 1].transform.position;

            totalDistanceToTarget = Vector3.Distance(target, ds.rb.gameObject.transform.position);

            if (ds.rb.gameObject.transform.InverseTransformPoint(target).y > 5)
            {
                isJump = true;
            }
            else isJump = false;
        }*/

        ds.CheckForSkid();
        ds.CalcEngineSound();
         
    }
}
