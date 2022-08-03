using System;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    internal static event Action OnDeselecAllUnit;
    internal static event Action<GameObject> OnShiftClickSelect;
    internal static event Action<GameObject> OnClickSelect;

    [SerializeField] private Camera myCamera;
    [SerializeField] private GameObject indicatorMovementUnit;

    [Header("Layer's")]
    [SerializeField] private LayerMask clickableLayer;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        myCamera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
            {
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    OnShiftClickSelect?.Invoke(hit.collider.gameObject);
                }
                else
                {
                    OnClickSelect?.Invoke(hit.collider.gameObject);
                }
            }
            else
            {
                if(!Input.GetKey(KeyCode.LeftShift))
                {
                    OnDeselecAllUnit?.Invoke();
                }
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                indicatorMovementUnit.transform.position = hit.point;
                indicatorMovementUnit.SetActive(false);
                indicatorMovementUnit.SetActive(true);
            }
        }
    }


}
