using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFour : Scroller
{
    public override void Move()
    {
      transform.position += new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
    }
}
