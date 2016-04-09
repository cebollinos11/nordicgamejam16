using UnityEngine;
using System.Collections;

public class GuacamoleButton : Button {

    public Room roomToFill;

    public bool isLeaking;


    public void StartLeaking() {
        isLeaking = true;
    }

    public void StopLeaking()
    {
        ShaderManager.LayerMask(GetComponent<SpriteRenderer>(), Color.blue);
        Debug.Log("FUCK IT");
    }

    protected override void Start()
    {
        base.Start();
        StartLeaking();
    }

    public override void OnPress()
    {
        base.OnPress();

        if (isLeaking)
        {
            StopLeaking();
        }
        
        
        
    }
   

}
