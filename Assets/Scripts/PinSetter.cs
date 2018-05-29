using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    
    public Text standingDisplay;
    public GameObject pinSet;

    private int lastStandingCount = -1;
    private Ball ball;
    private float lastChangeTime;
    private int lastSettledCount = 10;
    private bool ballOutOfPlay = false;
    private ActionMaster actionMaster = new ActionMaster();
    private Animator animator;

	// Use this for initialization
	void Start () {
        ball = FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();
	}
    
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();
        
        if(ballOutOfPlay) {
            standingDisplay.color = Color.red;
            UpdateStandingCountAndSettle();
        }
	}
    
    public bool SetBallOutOfPlay() {
        return ballOutOfPlay = true;
    }
    
    public void RaisePins () {
        foreach (Pin pin in FindObjectsOfType<Pin>()) {
            pin.Raise();
            pin.transform.rotation = Quaternion.Euler(270f, 0, 0);
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
    
    void UpdateStandingCountAndSettle() {
        int currentStanding = CountStanding();
        
        if (currentStanding != lastStandingCount) {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            
            return;
        }

        float settleTime = 3f;
        if ((Time.time - lastChangeTime) > settleTime) {
            PinsHaveSettled();
        }
    }
    
    void PinsHaveSettled () {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        ActionMaster.Action action = actionMaster.Bowl(pinFall);
        Debug.Log("Pinfall: " + pinFall + " " + action);
        
        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.EndTurn) {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        } else if (action == ActionMaster.Action.Reset) {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        } else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("Have to desing the ending");
        }
    
        ball.Reset();
        lastStandingCount = -1;
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
        
    }
    
    
    
    int CountStanding() {
        int standing = 0;
        
        foreach (Pin pin in FindObjectsOfType<Pin>()) {
             if (pin.IsStanding()) {
                standing++;
             }
        }
        return standing;
        
    }
    

    private void OnTriggerExit(Collider other)
    {
        GameObject thingLeft = other.gameObject;

        if (thingLeft.GetComponent<Pin>() ) {
            Destroy(thingLeft);
        }
    }

}
