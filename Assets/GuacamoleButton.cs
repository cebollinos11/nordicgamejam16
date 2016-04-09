using UnityEngine;
using System.Collections;

public class GuacamoleButton : MonoBehaviour {

    public string inputName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown(inputName)) {

            Debug.Log("button pressed!");
        }
	
	}
}
