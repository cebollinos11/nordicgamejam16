using UnityEngine;
using System.Collections;

public class TaponButton : Button {

    public roomFill roomToFill;

    public override void OnPress()
    {
        base.OnPress();

        Debug.Log("TAPON");
    }
}
