using UnityEngine;
using System.Collections;

public class TaponButton : Button {

    public Room roomToFill;

    public override void OnPress()
    {
        base.OnPress();

        roomToFill.Drain();
    }
}
