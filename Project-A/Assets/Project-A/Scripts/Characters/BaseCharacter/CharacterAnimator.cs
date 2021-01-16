using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private const string CHARACTER_MODEL_PATH = "Prefabs/Character/Models/";

    protected Character character;
    private Animator animator;

    public void Init(Character character)
    {
        this.character = character;
        GetModelCharacter();
    }

    private void GetModelCharacter()
    {
        string modeId = character.GetAnimatorId();

        GameObject model = Instantiate(Resources.Load<GameObject>(CHARACTER_MODEL_PATH + modeId));
        model.transform.SetParent(transform);
        model.transform.position = transform.position;
        model.transform.localScale = Vector3.one;

        animator = model.GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 direction)
    {
        Debug.Log($"X: {direction.x}  Y: {direction.y}");
        animator.SetFloat("Speed", direction.y);
        animator.SetFloat("Direction", direction.x);

    }

    public void Jump(bool jump)
    {
        Debug.Log($"Jump: {jump}");
        animator.SetBool("Jump", jump);
    }
}
