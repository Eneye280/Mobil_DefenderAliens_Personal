using UnityEngine.AI;
using UnityEngine;
using System.Collections.Generic;

public class UnitMovement : MonoBehaviour
{
    private Camera myCamera;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        myCamera = Camera.main;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }
    }
}
