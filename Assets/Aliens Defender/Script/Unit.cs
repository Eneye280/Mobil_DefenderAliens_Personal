using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    internal static event Action<GameObject> OnAddUnitToList;
    internal static event Action<GameObject> OnRemoveUnitToList;

    private void Start()
    {
        OnAddUnitToList?.Invoke(this.gameObject);
    }

    private void OnDestroy()
    {
        OnRemoveUnitToList?.Invoke(this.gameObject);
    }
}
