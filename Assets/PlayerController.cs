using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject Camera;

    private GameObject cameraBase;

    public float MaxSpeed;

	// Use this for initialization
	void Start () {
        cameraBase = new GameObject("cameraBase");
        //cameraBase.AddComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float LeftVert = Input.GetAxis("Left Vertical");
        float RightVert = Input.GetAxis("Right Vertical");
        float LeftHor = Input.GetAxis("Left Horizontal");
        float RightHor = Input.GetAxis("Right Horizontal");

        if (LeftHor != 0 || RightHor != 0)
        {
            cameraBase.transform.position = new Vector3(Camera.transform.position.x, this.transform.position.y, Camera.transform.position.z);
            Vector3 Movement = new Vector3(LeftHor, 0, -LeftVert);
            this.transform.Translate(Movement * MaxSpeed, cameraBase.transform);
        }

        if (RightHor != 0 || RightVert != 0)
        {
            float heading = Mathf.Atan2(RightVert, RightHor);
            //Quaternion rotation = new Quaternion(, 0, ,0);
            this.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, heading * Mathf.Rad2Deg, 0), 0.1f);
        }

        //if(Input.GetButton)
		
	}
}
