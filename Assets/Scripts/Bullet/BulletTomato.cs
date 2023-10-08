using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTomato : BulletBase
{
    [SerializeField] Animator anim;

    protected override void Boom(GameObject target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
            target.GetComponent<IGetHit>().GetHit(base._damage);
        }
        StartCoroutine(Trigger());
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == null)
            return;

        anim.SetTrigger("Tomato");
        this.Boom(collision.gameObject);
    }

    IEnumerator Trigger()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
