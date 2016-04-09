using UnityEngine;
using System.Collections;

public class roomFill : MonoBehaviour {

    Room rm;
    Vector3 origScale;
    float bottom;

	// Use this for initialization
	void Start () {
        rm = transform.parent.GetComponent<Room>();
        bottom = transform.position.y-transform.localScale.y/2;
        
	}
	
	// Update is called once per frame
	void Update () {

        //rm.filledAmount += Time.timeScale;
        //if (rm.filledAmount > 100f)
        //    rm.filledAmount = 100f;

        Debug.Log(rm.filledAmount);
        //transform.position = new Vector3(transform.position.x,transform.localScale.y,transform.position.z);
	    
	}
}
