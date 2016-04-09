using UnityEngine;
using System.Collections;

public class TaponButton : Button {

    public override void OnPress()
    {
        base.OnPress();

        Debug.Log("TAPON");
    }
}
