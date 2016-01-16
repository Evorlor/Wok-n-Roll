﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {

	private static Control instance = null;
	public static Control GetInstance()
	{
		return instance;
	}


	public enum INPUT
	{
		North = 0, Northeast, East, Southeast, South, Southwest, West, Northwest, Jump
	}

	private class InputNames
	{
		public const string North = "North";
		public const string Northeast = "Northeast";
		public const string East = "East";
		public const string Southeast = "Southeast";
		public const string South = "South";
		public const string Southwest = "Southwest";
		public const string West = "West";
		public const string Northwest = "Northwest";
		public const string Jump = "Jump";
	}

	private class InputNode
	{
		public InputNode(float timeDuration)
		{
			TimeDuration = timeDuration;
        }

		public float TimeDuration;
		public float LastUpdateTime;
		public bool Pressed;
	}

	// TODO: put this public
	private Dictionary<INPUT, InputNode> Inputs = new Dictionary<INPUT, InputNode>()
	{
		{INPUT.North, new InputNode(0.0f)},
		{INPUT.Northeast, new InputNode(0.0f) },
		{INPUT.East, new InputNode(0.0f) },
		{INPUT.Southeast, new InputNode(0.0f) },
		{INPUT.South, new InputNode(0.0f) },
		{INPUT.Southwest, new InputNode(0.0f) },
		{INPUT.West, new InputNode(0.0f) },
		{INPUT.Northwest, new InputNode(0.0f) },
		{INPUT.Jump, new InputNode(0.0f) },
	};

	private string inputConvert(INPUT input)
	{
		switch (input)
		{
			case INPUT.North:
				return InputNames.North;
            case INPUT.Northeast:
				return InputNames.Northeast;
            case INPUT.East:
				return InputNames.East;
            case INPUT.Southeast:
				return InputNames.Southeast;
			case INPUT.South:
				return InputNames.South;
			case INPUT.Southwest:
				return InputNames.Southwest;
			case INPUT.West:
				return InputNames.West;
			case INPUT.Northwest:
				return InputNames.Northwest;
			case INPUT.Jump:
				return InputNames.Jump;
			default:
				return string.Empty;
		} 
	}

	void Start () {
		instance = this;
    }

	void FixedUpdate () {

		// Check button status
		List<INPUT> keys = new List<INPUT>(Inputs.Keys);
		foreach (INPUT key in keys)
		{
			if (Input.GetButton(inputConvert(key)))
			{
				// Check time
				InputNode inputNode = Inputs[key];
                if ( Time.fixedTime - inputNode.LastUpdateTime > inputNode.TimeDuration)
				{
					inputNode.LastUpdateTime = Time.fixedTime;
					inputNode.Pressed = true;
                }
				// Update the array data
			}
		}
	}

	public bool GetInput(INPUT input)
	{
		if (Inputs[input].Pressed)
		{
			Inputs[input].Pressed = false;
			return true;
        }
		return false;
	}
}