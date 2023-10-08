using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyManager : Singleton<EnemyManager>
{
    
    [SerializeField] float _minTimeSpawn, _maxTimeSpawn;
    [SerializeField] float _timer = 2f;
    [SerializeField] GameObject _enemyPrefab;

    Coroutine coroutine;
    // Start is called before the first frame update
    public void Init()
    {
        coroutine = StartCoroutine(enemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator enemySpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timer);
            EnemySpawner();
        }
    }

    private void EnemySpawner()
    {

        Vector2 pos = GameManager.Instant.BaseController.transform.position;
        pos.x += (Random.Range(-20f, 20f));
        pos.y += (Random.Range(-20f, 20f));

        EnemyController e = ObjectPooling.Instant.GetComp<EnemyController>(_enemyPrefab);
        e.transform.position = pos;
        e.Init(100,50);
        e._healthBar.UpdateHealthBar(100);
        e.gameObject.SetActive(true);
        
    }

    private void OnDisable()
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
}
