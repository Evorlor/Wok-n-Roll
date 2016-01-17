using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class InstructionAnimator : MonoBehaviour
{
    private Animator animator;

    private const string animationIntegerName = "Action";

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        //animator.SetInteger(animationIntegerName, GetInstructionNumber());
    }

    /// <summary>
    /// Updates the instruction's animation in the center of the screen
    /// </summary>
    public void UpdateAnimation(Action action)
    {
        animator.SetTrigger("" + (int)action);
        //animator.SetInteger(animationIntegerName, GetInstructionNumber());
    }

    private int GetInstructionNumber()
    {
        var currentInstruction = InstructionManager.Instance.GetCurrentInstruction();
        if (currentInstruction)
        {
            return (int)currentInstruction.action;
        }
        return -1;
    }
}
