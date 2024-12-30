using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_JUMPING = "IsJumping";
    private const string IS_GLIDING = "IsGliding";
    private const string IS_SUBMARINE = "IsSubmarine";

    [SerializeField] private TriggerToSailing triggerToSailing;
    [SerializeField] private PlayerInput playerInput;

    private Animator shipAnimator;

    private void Awake()
    {
        shipAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        shipAnimator.SetBool(IS_JUMPING, triggerToSailing.IsJumping());
        shipAnimator.SetBool(IS_GLIDING, MovementSystemDifferentModes.Instance.IsGliding());
    }
}
