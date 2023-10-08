using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    [SerializeField]
    Dictionary<GameObject, List<GameObject>> _pool = new Dictionary<GameObject, List<GameObject>>();

    private void Awake()
    {
       
    }

    public virtual GameObject GetObject(GameObject prefab)
    {
        List<GameObject> listObj = new List<GameObject>();
        if(_pool.ContainsKey(prefab))
            listObj = _pool[prefab];
        else
        {
            _pool.Add(prefab, listObj);
        }

        foreach (GameObject g in listObj)
        {
            if (g.activeSelf)
                continue;
            return g;
        }

        GameObject g2 = Instantiate(prefab,this.transform.position,Quaternion.identity);
        listObj.Add(g2);

        return g2;
    }

    public virtual T GetComp<T>(GameObject prefab) where T:MonoBehaviour
    {
        return this.GetObject(prefab).GetComponent<T>();
    }
}
