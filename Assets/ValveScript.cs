﻿using UnityEngine;
using System.Collections;

public class ValveScript : MonoBehaviour {
    
    [SerializeField]
    GameObject ValveSprite;
    Vector3 visitedPositions;

    public ValveTrigger[] valveTriggers;

    int completedTurns;
   

    public Room roomToFill;

    

	// Use this for initialization
	void Start () {
        visitedPositions = new Vector4(0f, 0f, 0f, 0f);
	}
    

    public void CheckTriggers() {

        bool completeturn = true;

        for (int i = 0; i < valveTriggers.Length; i++)
        {
            //Debug.Log(valveTriggers[i].name+ " is "+valveTriggers[i].wasTriggered);
            if (!valveTriggers[i].wasTriggered)
            {
                completeturn = false;

            }
                
        }

        if (completeturn) {

            ShaderManager.LayerMask(ValveSprite.GetComponent<SpriteRenderer>(), Color.blue);
            completedTurns++;
            roomToFill.Drain();

            for (int i = 0; i < valveTriggers.Length; i++)
            {
                valveTriggers[i].wasTriggered = false;
            }
        }

        



    }

    public void ReceiveInput(float xAxis, float yAxis)
    {

        float angle;
        float x = xAxis;
        float y = yAxis;
        if (x != 0.0f || y != 0.0f)
        {
            angle = Mathf.Atan2(y, x);
            // Do something with the angle here.

            ValveSprite.transform.rotation = Quaternion.EulerAngles(0f, 0f, angle);

            transform.rotation = Quaternion.Slerp(ValveSprite.transform.rotation, Quaternion.Euler(0f, 0f, angle), Time.time * 1f);


        }

    }
	
	
}
