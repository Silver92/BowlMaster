﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    
    public GameObject pinSet;
    
    private Animator animator;
    private PinCounter pinCounter;
    
    private ActionMaster actionMaster = new ActionMaster();

	// Use this for initialization
	void Start () {
        pinCounter = GetComponent<PinCounter>();
        animator = GetComponent<Animator>();
	}
    
	
	// Update is called once per frame
	void Update () {
        
	}
    
    public void RaisePins () {
        foreach (Pin pin in FindObjectsOfType<Pin>()) {
            pin.Raise();
            
        }
    }
    
    public void LowerPins () {
        foreach (Pin pin in FindObjectsOfType<Pin>()) {
            pin.Lower();
        }
    }
    
    public void RenewPins () {
        Instantiate(pinSet, new Vector3(0, 40, 1829), Quaternion.identity);
    }
    
    private void OnTriggerExit(Collider other)
    {
        GameObject thingLeft = other.gameObject;

        if (thingLeft.GetComponent<Pin>() ) {
            Destroy(thingLeft);
        }
    }
    
    public void PerformAction (ActionMaster.Action action) {
        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.EndTurn) {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        } else if (action == ActionMaster.Action.Reset) {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        } else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("Have to desing the ending");
        }
    }

}
