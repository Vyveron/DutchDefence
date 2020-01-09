using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Path
{
    private static UnityEvent _onCreated = new UnityEvent();

    public static List<Vector2> VectorPath { get; private set; }
    public static bool isCreated = false;


    public static void SetPath(List<Vector2> path)
    {
        if (path == null)
            return;

        isCreated = true;
        VectorPath = path;
        _onCreated.Invoke();
        _onCreated.RemoveAllListeners();
    }
    public static void AddRequestOnCreate(UnityAction callback)
    {
        if (callback != null)
        {
            _onCreated.AddListener(callback);
        }
    }
}
