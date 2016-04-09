using UnityEngine;
using System.Collections;

public class Room_Guacamole : Room {

    public GuacamoleButton[] buttons;


    bool alreadyLeaking() {

        bool foo = false;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].isLeaking)
                foo = true;
        }

        return foo;
    
    }

    void LeakOne() {
        int roll = Random.Range(0, 4);
        buttons[roll].StartLeaking();
    }
	
	// Update is called once per frame
	protected override void Update () {

        base.Update();

        if (filledAmount > 0)
        {
            if (!alreadyLeaking())
                LeakOne();
            
        }
	
	}
}
