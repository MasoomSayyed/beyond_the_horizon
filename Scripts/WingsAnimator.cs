using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsAnimator : MonoBehaviour
{
    private const string IS_GLIDING = "IsGliding";

    [SerializeField] private Animator wingsAnimator;

    private void Update()
    {
        wingsAnimator.SetBool(IS_GLIDING, MovementSystemDifferentModes.Instance.IsGliding());
    }
}
