﻿using UnityEngine;
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

    [SerializeField] private ValveScript valve1;
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

        valve1.ReceiveInput(padStates[valve].LeftStickAxis.x, padStates[valve].LeftStickAxis.y);
    }

	void Update ()
	{
        Debug.Log("1: " + controller1.LeftStickAxis + "  2: " + controller2.LeftStickAxis +"  3: " + controller3.LeftStickAxis + "  4: " +controller4.LeftStickAxis);


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
