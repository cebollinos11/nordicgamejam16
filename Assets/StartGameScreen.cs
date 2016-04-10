using UnityEngine;
using System.Collections;

public class StartGameScreen : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {

       
        if (Input.GetKeyDown(KeyCode.Space))

        {
            Debug.Log("you*******");
            Application.LoadLevel(1);
        }

	}
}
