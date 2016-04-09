using UnityEngine;
using System.Collections;
using GamepadInput;

public class InputController : MonoBehaviour
{
    public InputTester inputTester;

    private GamepadState controller1;
    private GamepadState controller2;
    private GamepadState controller3;
    private GamepadState controller4;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        controller1 = GamepadInput.GamePad.GetState(GamePad.Index.One);
        controller2 = GamepadInput.GamePad.GetState(GamePad.Index.Two);
        controller3 = GamepadInput.GamePad.GetState(GamePad.Index.Three);
        controller4 = GamepadInput.GamePad.GetState(GamePad.Index.Four);
    }

	void Update ()
	{
        Debug.Log("1: " + controller1.LeftStickAxis + "  2: " + controller2.LeftStickAxis +"  3: " + controller3.LeftStickAxis + "  4: " +controller4.LeftStickAxis);
    }
}
