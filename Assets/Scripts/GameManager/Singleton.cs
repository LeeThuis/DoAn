using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instant = null;
    public static T Instant
    {
        get
        {
            if(_instant == null)
            {
                if(FindObjectOfType<T>() != null)
                    _instant = FindObjectOfType<T>();
                else
                    new GameObject().AddComponent<T>().name = "Singleton_" + typeof(T).ToString();
            }

            return _instant;
        }
    }
    private void Awake()
    {
        if (_instant != null && _instant.GetInstanceID() != this.GetComponent<T>().GetInstanceID())
        {
            Debug.LogError("Singleton already exit " + _instant.gameObject.name);
            Destroy(this.GetComponent<T>());
        }
        else
            _instant = this.GetComponent<T>();

    }
}
