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
    public float tileOffset = 0;

    //Water
    private Vector3 waterOrigScale;
    private Vector3 waterOriginalPos;
    private float lockTimeRemaining;

    [SerializeField] protected float drainAmount = 10;
    [SerializeField] private Transform water;

    AudioClip s_yay;

    protected virtual void Start()
    {
        filledAmount = 0;
        lockTimeRemaining = lockTime;
        state = RoomState.Idle;
        water.position = new Vector3(water.position.x, water.position.y + water.transform.position.z, water.position.z);
        waterOrigScale = water.localScale;
        waterOriginalPos = water.position;
        tileOffset = Random.Range(0f, 1f);
        s_yay = Resources.Load("Sounds/YAY") as AudioClip;
    }

    protected virtual void Update()
    {
        tileOffset += Time.deltaTime * 0.03f;
        water.localScale =  new Vector3(waterOrigScale.x, waterOrigScale.y, waterOrigScale.z * (filledAmount / 100f));
        water.GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(1.0f, transform.localScale.z);
        water.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(tileOffset, transform.localScale.z);
        water.transform.position = new Vector3(waterOriginalPos.x, waterOriginalPos.y + water.transform.localScale.z * 2f, waterOriginalPos.z );
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
            AudioManager.PlayClip(s_yay);

        }
    }
}
