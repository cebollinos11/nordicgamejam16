using UnityEngine;
using System.Collections;

public class GuacamoleButton : Button {

    public Room roomToFill;

    public override void OnPress()
    {
        base.OnPress();
        ShaderManager.LayerMask(GetComponent<SpriteRenderer>(), Color.blue);
        Debug.Log("PRess");
        
    }
   

}
