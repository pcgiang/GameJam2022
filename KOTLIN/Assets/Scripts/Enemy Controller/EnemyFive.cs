using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFive : Scroller
{
  public override void Move()
    {
      transform.position -= new Vector3(beatTempo * Time.deltaTime, beatTempo * Time.deltaTime, 0f);
    }
}
