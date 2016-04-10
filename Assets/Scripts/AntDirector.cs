using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntDirector : MonoBehaviour
{
    [SerializeField] private float DEFAULTFLOODTIME = 15;
    private float floodTimeRemaining = 15;
    private float currentTime = 0;
    [SerializeField] private AnimationCurve difficultyCurve;
    [SerializeField] private AnimationCurve floodDurationCurve;
    [SerializeField] private float ENDTIME = 300;
    [SerializeField] private float initialFloodAmount = 15;


    private Dictionary<Room, float> currentFloodedRooms;

    private float mainRoomFillAmount = 0;

    public Room[] Rooms;
    public Room antColony;

    AudioClip s_water;

	// Use this for initialization
	void Start () {
        currentFloodedRooms = new Dictionary<Room, float>();
	    floodTimeRemaining = DEFAULTFLOODTIME;
        s_water = Resources.Load("Sounds/waterNormal") as AudioClip;
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
	        else
	        {
                if (pair.Key.isLocked) continue;
	            float excess = pair.Key.Fill(10*Time.deltaTime);
	            if (excess > 0)
	            {
	                antColony.Fill(excess);
                    if (antColony.filledAmount > antColony.FILLOVERFLOWLIMIT) 
                        LoseGame();
	            }
                tempDict.Add(pair.Key, timeRemaining);
            }

	    }
	    currentFloodedRooms = tempDict;
	}

    public void FloodRoom(float floodDuration)
    {
        
        Room floodRoom = Rooms[Random.Range(0, Rooms.Length)];
        if (floodRoom.state == Room.RoomState.Filling)
        {
            currentFloodedRooms.Remove(floodRoom);
        }
        floodRoom.state = Room.RoomState.Filling;
        if (!floodRoom.isLocked)
        {
            floodRoom.Fill(initialFloodAmount);
            ShaderManager.SS();
            AudioManager.PlayClip(s_water);
        }
            
        currentFloodedRooms.Add(floodRoom, floodDuration);
        
    }

    public void LoseGame()
    {
        Debug.Log("YOU LOSE! LOL");
    }

}
