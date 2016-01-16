using UnityEngine;
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
		public InputNode(float continuousInterval, float timeDuration, bool reversed = false)
		{
			ContinuousInterval = continuousInterval;
			TimeDuration = timeDuration;
			Reversed = reversed;
        }

		public float TimeDuration;
		public float ContinuousInterval;
		public float LastUpdateTime;
		public bool Pressed;
		public bool Reversed;
	}

	// TODO: put this public
	private Dictionary<Action, InputNode> Inputs = new Dictionary<Action, InputNode>()
	{
		{Action.North, new InputNode(0.0f, -1.0f)},
		{Action.Northeast, new InputNode(0.0f, -1.0f) },
		{Action.East, new InputNode(0.0f, -1.0f) },
		{Action.Southeast, new InputNode(0.0f, -1.0f) },
		{Action.South, new InputNode(0.0f, -1.0f) },
		{Action.Southwest, new InputNode(0.0f, -1.0f) },
		{Action.West, new InputNode(0.0f, -1.0f) },
		{Action.Northwest, new InputNode(0.0f, -1.0f) },
		{Action.Jump, new InputNode(0.0f, -1.0f, true) },
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
			if (Input.GetButton(inputConvert(key)) ^ inputNode.Reversed)
			{
				// Check time
				if ( Time.fixedTime - inputNode.LastUpdateTime > inputNode.ContinuousInterval)
				{
					inputNode.LastUpdateTime = Time.fixedTime;
					inputNode.Pressed = true;
				}
				// Update the array data

			} else if(inputNode.Pressed && inputNode.TimeDuration >= 0.0f)
			{
				// Volatile 
				if (inputNode.TimeDuration < Time.fixedTime - inputNode.LastUpdateTime)
				{
					inputNode.LastUpdateTime = Time.fixedTime;
					inputNode.Pressed = false;
				}
			}
		}
	}

	public bool GetInput(Action input)
	{
		if (Inputs[input].Pressed)
		{
			Inputs[input].Pressed = false;
			return true;
        }
		return false;
	}
}
