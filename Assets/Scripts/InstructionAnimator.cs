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

        //animator.SetTrigger("" + (int)action);
        //soundeffect.pitch = Random.Range(0.75f, 1.0f);
        ////if (!soundeffect.isPlaying)
        //{
        //    soundeffect.Play();
        //}
        //int x = Random.Range(1, 5);
        //switch (x)
        //{
        //    case 0:
        //    case 1:

        //        Debug.Log(x);
        //        target.SetActive(true);
        //        target2.SetActive(false);
        //        break;

        //    case 2:
        //        target.SetActive(true);
        //        target2.SetActive(false);
        //        Debug.Log(x);
        //        break;
        //    case 3:
        //        target.SetActive(false);
        //        target2.SetActive(true);
        //        Debug.Log(x);
        //        break;
        //    case 4:
        //        target.SetActive(false);
        //        target2.SetActive(true);
        //        Debug.Log(x);
        //        break;
        //    default: //print();
        //        target.SetActive(false);
        //        target2.SetActive(true);
        //        Debug.Log(x);

        //        break;
        //}



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
