using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : Singleton<Observer>
{
    #region KEYS
    public static string GAME_START = "GameStart";
    public static string END_GAME = "EndGame";
    #endregion

    Dictionary<string, List<Action<object>>> _listActions = new Dictionary<string, List<Action<object>>>();

    private void Start()
    {
        DontDestroyOnLoad(this);
    }



    public void AddListener(string key, Action<object> callBack)
    {
        List<Action<object>> tmpActions = new List<Action<object>>();
        if (_listActions.ContainsKey(key))
        {
            tmpActions = _listActions[key];
        }
        else
        {
            _listActions.Add(key, tmpActions);
        }

        tmpActions.Add(callBack);
    }

    public void Notify(string key, object data = null)
    {

        if (!_listActions.ContainsKey(key))
        {
            return;
        }

        foreach (Action<object> action in _listActions[key])
        {
            action?.Invoke(data);
        }

    }

    public void RemoveListener(string key, Action<object> callBack)
    {

        if (!_listActions.ContainsKey(key))
            return;

        _listActions[key].Remove(callBack);
    }
}