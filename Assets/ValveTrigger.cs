using UnityEngine;
using System.Collections;

public class ValveTrigger : MonoBehaviour {

    
    public bool wasTriggered;
    public string name;

    ValveScript vs;
	// Use this for initialization
	void Start () {
        vs = transform.parent.GetComponent<ValveScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Trigger "+name);
        wasTriggered = true;
        vs.CheckTriggers();
    }
}
