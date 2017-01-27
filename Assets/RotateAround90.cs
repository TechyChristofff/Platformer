using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround90 : MonoBehaviour {


    public GameObject RotateObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.transform.RotateAround(RotateObject.transform.position, Vector3.up, 90);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            this.transform.RotateAround(RotateObject.transform.position, Vector3.up, -90);
        }
        this.transform.LookAt(RotateObject.transform);
    }

    private void LateUpdate()
    {
        //this.transform.Rotate(Vector3.up, 10.0f);
    }

    
}
