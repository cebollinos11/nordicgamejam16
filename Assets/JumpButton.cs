using UnityEngine;
using System.Collections;

public class JumpButton : Button {

    public JumpingAnt antLeft;
    public JumpingAnt antRight;

    bool rightNeedsToRest;
    bool leftNeedsToRest;

    string whoIsEnabled;

    public Room roomToFill;



    protected override void Start() {
        whoIsEnabled = "left";
        base.Start();
        
    }
    public void EnableTheOther() {
        if (whoIsEnabled == "left")
            whoIsEnabled = "right";
        else {
            whoIsEnabled = "left";
            roomToFill.Drain();
            ShaderManager.LayerMask(GetComponent<SpriteRenderer>(), Color.blue);
        }
    }
    public override void ReceiveInputs(float jumpRight, float jumpLeft)
    {
        
        if (jumpRight > 0f && !rightNeedsToRest && whoIsEnabled == "right")
        {
            antRight.Jump();
            rightNeedsToRest = true;
        }

        if (jumpLeft > 0f && !leftNeedsToRest && whoIsEnabled=="left") {
            antLeft.Jump();
            leftNeedsToRest = true;
        }
            

        if (jumpRight == 0f)
            rightNeedsToRest = false;
        if(jumpLeft == 0f)
            leftNeedsToRest =false;
    }
}
