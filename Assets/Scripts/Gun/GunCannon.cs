using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCannon : GunControllerBase
{
    [SerializeField] protected GameObject _bullet;

    public override void Fire()
    {
        if (_countdownTime <= 0)
        {
            BulletBase g = ObjectPooling.Instant.GetComp<BulletBase>(_bullet);
            Vector3 dir = (InputManager.Instant._mousePosition - _gun.transform.position).normalized;
            float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            g.transform.rotation = Quaternion.Euler(0f, 0f, rot);
            g.transform.position = _gun.transform.position;
            g.Init(_speed, _damage, _lifeTime, dir);
            g.gameObject.SetActive(true);
            _countdownTime = _timer;
        }
    }
}
