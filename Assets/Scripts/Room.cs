using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour
{

    public enum RoomState 
    {
        Filling,
        Idle
    };

    public RoomState state;
    public bool isLocked = false;
    public float filledAmount;
    public float fillOverflowLimit = 65;
    public float fillSpeed = 1;

    void Start()
    {
        filledAmount = 0;
        state = RoomState.Idle;
    }

    void Update()
    {
    }

    public void SetLock(bool locked)
    {
        isLocked = locked;
    }

    public void Fill(float amount)
    {
        filledAmount += amount * fillSpeed;
    }
}
