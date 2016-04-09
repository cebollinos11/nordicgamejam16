using UnityEngine;
using System.Collections;

public class ValveScript : MonoBehaviour {

    public string XaxisName;
    public string YaxisName;

    [SerializeField]
    GameObject ValveSprite;
    Vector3 visitedPositions;

    public ValveTrigger[] valveTriggers;

    int completedTurns;

    public TextMesh turnCountText;

    

	// Use this for initialization
	void Start () {
        visitedPositions = new Vector4(0f, 0f, 0f, 0f);
        updateText();
	}

    void updateText() {
        turnCountText.text = "Completed Turns: "+completedTurns.ToString();
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
           

            completedTurns++;
            updateText();

            for (int i = 0; i < valveTriggers.Length; i++)
            {
                valveTriggers[i].wasTriggered = false;
            }
        }

        



    }
	
	// Update is called once per frame
	void Update () {

        float angle;
        float x = Input.GetAxis(XaxisName);
        float y = Input.GetAxis(YaxisName);
        if (x != 0.0f || y != 0.0f)
        {
            angle = Mathf.Atan2(y, x) ;
            // Do something with the angle here.
            
            ValveSprite.transform.rotation = Quaternion.EulerAngles(0f, 0f, angle);

            transform.rotation = Quaternion.Slerp(ValveSprite.transform.rotation, Quaternion.Euler(0f,0f,angle) , Time.time * 1f);

            
        }
	
	}
}
