using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : Scroller
{
    public override void Move()
    {
      transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
    }
}
