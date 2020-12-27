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
        characterAnimator.Init(this);
        characterControl.Init(this);
    }

    public override string GetAnimatorId()
    {
        return "UnityChan";
    }
}
