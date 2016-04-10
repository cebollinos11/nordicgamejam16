using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Counter : MonoBehaviour {

    Text t;
    int i;

    void Increment() {
        i++;
    }
	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
        i = 0;
        InvokeRepeating("Increment", 1f, 1f);

	}
	
	// Update is called once per frame
	void Update () {
        t.text = i.ToString();
	}
}
