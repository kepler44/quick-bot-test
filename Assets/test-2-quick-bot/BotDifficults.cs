using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BotInputs
{
    public float x;

    public bool jump;

    public bool force;
}

public class BotDifficults
{
    public BotInputs ReadInputs(GameObject gameObject)
    {
        var x = 0f;

        var coll =
            Physics2D
                .OverlapBoxAll(gameObject.transform.position,
                new Vector2(15, 15),
                default,
                1 >> 7);
        for (int i = 0; i < coll.Length; i++)
        {
            if (coll[i].gameObject == gameObject) continue;
            x = coll[i].transform.position.x - gameObject.transform.position.x;
            x = Mathf.Sign(x);
        }

        return new BotInputs { x = x };
    }
}
