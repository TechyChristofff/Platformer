using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround90 : MonoBehaviour {


    public GameObject RotateObject;
    enum Moving
    {
        none,
        left,
        right
    }

    public float maxSpeed;

    private Moving _moving;
	// Use this for initialization
	void Start () {
        _moving = Moving.none;
        maxSpeed = 0.0f
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //this.transform.RotateAround(RotateObject.transform.position, Vector3.up, 90);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            RotateObjectFunc(RotateObject.transform.position, Vector3.up, 90, 50000);
        }

        
    }

    private void RotateObjectFunc(Vector3 point, Vector3 axis, float rotateAmount, float rotateTime)
    {
        float step = 0.0f; //non-smoothed
        float rate =  1.0f/rotateTime;
        float smoothstep = 0.0f;
        float lastStep = 0.0f;
        float total = 0.0f;
        float totalTime = 0.0f;
        while (step < 1.0f)
        {
            step += Time.deltaTime * rate;
            totalTime += Time.deltaTime;
            smoothstep = Mathf.SmoothStep(0.0f, maxSpeed, step);
            float temp = rotateAmount * (smoothstep - lastStep);
            total += temp;
            transform.RotateAround(point, axis, temp);
            lastStep = smoothstep;
        }
        if(step>1.0)
            transform.RotateAround(point, axis, rotateAmount * (1.0f - lastStep));
    }

    private void OtherRotateObj(Vector3 point, Vector3 axis, float rotateAmount, float rotateTime)
    {
        Quaternion rotation = Quaternion.AngleAxis(rotateAmount, axis);
        Vector3 startPos = transform.position - point;
        Vector3 endPos = rotation * startPos;
        Quaternion startRot = transform.rotation;
        float step = 0.0f;
        float smoothStep = 0.0f;
        float rate = 1.0f / rotateTime;
        while (step < 1.0)
        {
            step += Time.deltaTime * rate;
            smoothStep = Mathf.SmoothStep(0.0f, 1.0f, step);
            transform.position = point + Vector3.Slerp(startPos, endPos, smoothStep);
            transform.rotation = startRot * Quaternion.Slerp(Quaternion.identity, rotation, smoothStep);
        }
        if (step > 1.0) {
            transform.position = point + endPos;
            transform.rotation = startRot * rotation;
        }
    }

    
}
