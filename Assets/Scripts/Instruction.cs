using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Instruction : MonoBehaviour
{
    [Tooltip("The Sprite associated with this Instruction for the UI")]
    public Sprite sprite;

    public Action action;
}