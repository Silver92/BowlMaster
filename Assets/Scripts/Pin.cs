using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshhold = 10f;
    public float distanceToRaise = 40f;
    private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
    
	}
    
    public bool IsStanding () {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(270-rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if (tiltInX < standingThreshhold && tiltInZ < standingThreshhold) {
            return true;
        }
        else {
            return false;
        }
        
    }
    
    public void Raise () {
        if (IsStanding()) {
            rigidBody.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
        }    
    }
    
    public void Lower () {
        rigidBody.useGravity = true;
    }
    
}
