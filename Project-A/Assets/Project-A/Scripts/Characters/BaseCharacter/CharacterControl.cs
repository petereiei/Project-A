using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    protected Rigidbody rigidBody;
    protected Character character;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Init(Character character)
    {
        this.character = character;
    }
}
