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
    public float lockTime = 10;

    //Water
    private Vector3 waterOrigScale;
    private float lockTimeRemaining;

    [SerializeField] protected float drainAmount = 10;
    [SerializeField] private Transform water;

    protected virtual void Start()
    {
        filledAmount = 0;
        lockTimeRemaining = lockTime;
        state = RoomState.Idle;
        waterOrigScale = water.localScale;
    }

    protected virtual void Update()
    {
        water.localScale =  new Vector3(waterOrigScale.x, waterOrigScale.y * (filledAmount/100f), waterOrigScale.z);
        if (isLocked)
        {
            lockTimeRemaining -= Time.deltaTime;
            if (lockTimeRemaining <= 0) 
            {
                SetLock(false);
            }
        }
    }

    public void SetLock(bool locked)
    {
        isLocked = locked;
        lockTimeRemaining = lockTime;
    }

    public float Fill(float amount)
    {
        filledAmount += amount * fillSpeed;
        float excess = filledAmount - FILLOVERFLOWLIMIT;
        if (excess > 0)
        {
            filledAmount = FILLOVERFLOWLIMIT;
            return excess;
        }
        return 0;
    }

    public void Drain()
    {
        bool hadWater = (filledAmount > 0);
        filledAmount -= drainAmount;
        if (filledAmount < 0)
            filledAmount = 0;
        if (filledAmount == 0 && hadWater)
        {
            SetLock(true);
        }
    }
}
