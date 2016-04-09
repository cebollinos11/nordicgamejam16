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
    public float FILLOVERFLOWLIMIT = 65;
    public float fillSpeed = 1;

    //Water
    private Vector3 waterOrigScale;

    [SerializeField] protected float drainAmount = 10;
    [SerializeField] private Transform water;

    protected virtual void Start()
    {
        filledAmount = 0;
        state = RoomState.Idle;
        waterOrigScale = water.localScale;
    }

    protected virtual void Update()
    {
        water.localScale =  new Vector3(waterOrigScale.x, waterOrigScale.y * (filledAmount/100f), waterOrigScale.z);
    }

    public void SetLock(bool locked)
    {
        isLocked = locked;
    }

    public float Fill(float amount)
    {
        filledAmount += amount * fillSpeed;
        float excess = FILLOVERFLOWLIMIT - filledAmount;
        if (excess > 0)
        {
            filledAmount = FILLOVERFLOWLIMIT;
            return excess;
        }
        return 0;
    }

    public void Drain()
    {
        filledAmount -= drainAmount;
        if (filledAmount < 0) filledAmount = 0;
    }
}
