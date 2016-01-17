﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {

	private static Control instance = null;
	public static Control GetInstance()
	{
		return instance;
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
		public InputNode(float timeDuration, float triggerPressDuration = 0.0f, bool reversed = false)
		{
			TimeDuration = timeDuration;
			Reversed = reversed;
			TriggerPressDuration = triggerPressDuration;
        }

		public float TriggerPressDuration;
		public float TimeDuration;


		public float InputPressDuration;
		public float LastUpdateTime;
		public bool Pressed;
		public bool Reversed;
	}

	// TODO: put this public
	private Dictionary<Action, InputNode> Inputs = new Dictionary<Action, InputNode>()
	{
		{Action.North, new InputNode(0.05f)},
		{Action.Northeast, new InputNode(0.05f) },
		{Action.East, new InputNode(0.05f) },
		{Action.Southeast, new InputNode(0.05f) },
		{Action.South, new InputNode(0.05f) },
		{Action.Southwest, new InputNode(0.05f) },
		{Action.West, new InputNode(0.05f) },
		{Action.Northwest, new InputNode(0.05f) },
		{Action.Jump, new InputNode(0f, 0.1f, true) },
	};

	private string inputConvert(Action input)
	{
		switch (input)
		{
			case Action.North:
				return InputNames.North;
            case Action.Northeast:
				return InputNames.Northeast;
            case Action.East:
				return InputNames.East;
            case Action.Southeast:
				return InputNames.Southeast;
			case Action.South:
				return InputNames.South;
			case Action.Southwest:
				return InputNames.Southwest;
			case Action.West:
				return InputNames.West;
			case Action.Northwest:
				return InputNames.Northwest;
			case Action.Jump:
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
		List<Action> keys = new List<Action>(Inputs.Keys);
		foreach (Action key in keys)
		{
			InputNode inputNode = Inputs[key];
			if (!inputNode.Pressed) {
				if (Input.GetButton(inputConvert(key)) ^ inputNode.Reversed)
				{
					// Check time
					if (inputNode.InputPressDuration > inputNode.TriggerPressDuration)
					{
						inputNode.InputPressDuration = 0.0f;
						inputNode.LastUpdateTime = Time.fixedTime;
						inputNode.Pressed = true;
					} else
					{
						inputNode.InputPressDuration += Time.deltaTime;
					}
				} else
				{
					inputNode.InputPressDuration = 0.0f;
				}
			} else if(inputNode.Pressed && inputNode.TimeDuration >= 0.0f)
			{
				if (Input.GetButton(inputConvert(key)) ^ inputNode.Reversed)
					continue;
				// Volatile 
				if (inputNode.TimeDuration < Time.fixedTime - inputNode.LastUpdateTime)
				{
					inputNode.InputPressDuration = 0.0f;
					inputNode.LastUpdateTime = Time.fixedTime;
					inputNode.Pressed = false;
				}
			}
		}
	}

	public bool GetInput(Action input)
	{
		return Inputs[input].Pressed;
	}
}
