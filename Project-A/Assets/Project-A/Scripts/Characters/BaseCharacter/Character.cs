using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    public CharacterAnimator characterAnimator;
    public CharacterControl characterControl;

    public UnityEvent<Vector3> onMove;

    public abstract string GetAnimatorId();

    protected virtual void Awake()
    {
        characterAnimator = GetComponentInChildren<CharacterAnimator>();
    }

    protected void DeregisterEvent()
    {
        onMove = null;
    }
}
