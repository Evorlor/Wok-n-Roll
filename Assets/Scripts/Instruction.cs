using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Instruction : MonoBehaviour
{
    [Tooltip("The Sprite associated with this Instruction for the UI")]
    public Sprite sprite;

    [Tooltip("Instruction which will need to be performed")]
    public Action action;
}