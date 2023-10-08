using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCannon : BulletBase
{
    protected override void Boom(GameObject target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
            target.GetComponent<IGetHit>().GetHit(base._damage);
        }
        this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.Boom(collision.gameObject);
    }
}
