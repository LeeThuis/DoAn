using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GunFlamer : GunControllerBase
{
    [SerializeField] protected GameObject _bullet;

    [SerializeField] int numberBullet;
    public override void Fire()
    {
        for (int i = 0; i < numberBullet; i++)
        {
            Vector3 dir = (InputManager.Instant._mousePosition - _gun.transform.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            angle += Random.Range(-20f, 20f);
            dir.x = Mathf.Cos(angle * Mathf.Deg2Rad);
            dir.y = Mathf.Sin(angle * Mathf.Deg2Rad);

            BulletBase g = ObjectPooling.Instant.GetComp<BulletBase>(_bullet);
            float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            g.transform.rotation = Quaternion.Euler(0f, 0f, rot);
            g.transform.position = _gun.transform.position;
            g.Init(_speed, _damage, _lifeTime, dir);
            g.gameObject.SetActive(true);
        }
    }
}
