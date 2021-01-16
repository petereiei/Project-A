using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public CharacterAnimator characterAnimator;
    public CharacterControl characterControl;

    public Action<Vector2> onMove;
    public Action<bool> onJump;

    public abstract string GetAnimatorId();

    protected virtual void Awake()
    {
        characterAnimator = GetComponentInChildren<CharacterAnimator>();
    }

    protected void DeregisterEvent()
    {
        onMove = null;
        onJump = null;
    }
}
