using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_JUMPING = "IsJumping";

    [SerializeField] private TriggerToSailing triggerToSailing;

    private Animator shipAnimator;

    private void Awake()
    {
        shipAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        shipAnimator.SetBool(IS_JUMPING, triggerToSailing.IsJumping());
    }
}
