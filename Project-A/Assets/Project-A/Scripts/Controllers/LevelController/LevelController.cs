using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoSingleton<LevelController>
{
    private GameObject area;

    private void Start()
    {
        if (area == null)
        {
            area = new GameObject();
            area.name = "AreaObjects";
        }

        GetCharcter();
    }

    private void GetCharcter()
    {
        CharacterPlayer charcterPlayer = Instantiate(Resources.Load<CharacterPlayer>("Prefabs/Character/BaseCharcter/Character"));
        charcterPlayer.transform.SetParent(area.transform);
        charcterPlayer.transform.position = new Vector3(500, 0, 500);
        charcterPlayer.transform.localScale = Vector3.one;

        charcterPlayer.Init();
    }
}
