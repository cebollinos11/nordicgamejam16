using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GamepadInput;

public class InputController : MonoBehaviour
{

    private GamepadState anyController;
    private GamepadState controller1;
    private GamepadState controller2;
    private GamepadState controller3;
    private GamepadState controller4;

    [SerializeField] private GamePad.Index valve = GamePad.Index.Any;
    [SerializeField] private GamePad.Index tapon = GamePad.Index.Any;
    [SerializeField] private GamePad.Index jumping = GamePad.Index.Any;

    [SerializeField] private ValveScript valve1;
    [SerializeField] private ValveScript valve2;
    [SerializeField] private TaponButton tapon1;
    [SerializeField] private JumpButton jump1;

    private Dictionary<GamePad.Index, GamepadState> padStates; 
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
    void FixedUpdate()
    {
        anyController = GamepadInput.GamePad.GetState(GamePad.Index.Any);
        controller1 = GamepadInput.GamePad.GetState(GamePad.Index.One);
        controller2 = GamepadInput.GamePad.GetState(GamePad.Index.Two);
        controller3 = GamepadInput.GamePad.GetState(GamePad.Index.Three);
        controller4 = GamepadInput.GamePad.GetState(GamePad.Index.Four);

        SaveStates();

        if (valve1 != null)
            valve1.ReceiveInput(padStates[valve].LeftStickAxis.x, padStates[valve].LeftStickAxis.y);
        if (valve2 != null)
            valve2.ReceiveInput(padStates[valve].rightStickAxis.x, padStates[valve].rightStickAxis.y);
        if (tapon1 != null)
            tapon1.ReceiveInputs(padStates[tapon].A);

        if (jump1 != null)
            jump1.ReceiveInputs(padStates[jumping].RightTrigger,padStates[jumping].LeftTrigger);
         
        
    }

	void Update ()
	{
    }

    private void SaveStates()
    {

        padStates = new Dictionary<GamePad.Index, GamepadState>();
        padStates.Add(GamePad.Index.Any, anyController);
        padStates.Add(GamePad.Index.One, controller1);
        padStates.Add(GamePad.Index.Two, controller2);
        padStates.Add(GamePad.Index.Three, controller3);
        padStates.Add(GamePad.Index.Four, controller4);
    }
}
