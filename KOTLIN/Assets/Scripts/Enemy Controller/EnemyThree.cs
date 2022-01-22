using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThree : Scroller
{
    public override void Move()
    {
      transform.position += new Vector3(0f, beatTempo * Time.deltaTime, 0f);
    }
}
