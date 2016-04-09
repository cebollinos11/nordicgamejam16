using UnityEngine;
using System.Collections;

public class TaponButton : Button {

    public Room roomToFill;

    AudioClip s_cork;

    protected override void Start()
    {
        s_cork = Resources.Load("Sounds/Cork") as AudioClip;
        base.Start();
    }
    public override void OnPress()
    {
        ShaderManager.SS();
        AudioManager.PlayClip(s_cork);
        
        base.OnPress();

        roomToFill.Drain();
    }
}
