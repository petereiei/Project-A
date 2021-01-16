using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayer : Character
{
    protected override void Awake()
    {
        base.Awake();

        characterControl = gameObject.GetComponent<CharacterControl>();
    }

    public void Init()
    {
        DeregisterEvent();

        characterAnimator.Init(this);
        characterControl.Init(this);

        onMove += characterAnimator.Move;
        onJump += characterAnimator.Jump;
    }

    public override string GetAnimatorId()
    {
        return "unitychan_dynamic_locomotion";
    }
}
