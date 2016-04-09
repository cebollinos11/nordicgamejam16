using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntDirector : MonoBehaviour
{
    private float DEFAULTFLOODTIME = 15;
    private float floodTimeRemaining = 15;
    private float currentTime = 0;
    [SerializeField] private AnimationCurve difficultyCurve;
    [SerializeField] private AnimationCurve floodDurationCurve;
    [SerializeField] private float ENDTIME = 300;
    private Dictionary<Room, float> currentFloodedRooms;

    public Room[] Rooms; 

	// Use this for initialization
	void Start () {
        currentFloodedRooms = new Dictionary<Room, float>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    currentTime += Time.deltaTime;

	    if (floodTimeRemaining <= 0)
	    {
	        float duration = floodDurationCurve.Evaluate(currentTime/ENDTIME);
	        FloodRoom(duration);

	        floodTimeRemaining = DEFAULTFLOODTIME - (difficultyCurve.Evaluate(currentTime/ENDTIME) * 10);
	    }
	    else
	    {
	        floodTimeRemaining -= Time.deltaTime;
	    }

        Dictionary<Room, float> tempDict = new Dictionary<Room, float>();
	    foreach (KeyValuePair<Room, float> pair in currentFloodedRooms)
	    {
	        float timeRemaining = pair.Value - Time.deltaTime;
	        if (timeRemaining <= 0)
	        {
	            pair.Key.state = Room.RoomState.Idle;
                continue;
	        }

            tempDict.Add(pair.Key, timeRemaining);
	    }
	    currentFloodedRooms = tempDict;
	}

    public void FloodRoom(float floodDuration)
    {
        /*
        Room floodRoom = Rooms[Random.Range(0, Rooms.Length - 1)];
        floodRoom.state = Room.RoomState.Filling;
        currentFloodedRooms.Add(floodRoom, floodDuration);
        */
    }

}
