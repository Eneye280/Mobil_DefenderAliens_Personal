using UnityEngine;
using UnityEngine.AI;

public class MovementIA : MonoBehaviour
{
    [SerializeField] private Camera myCamera;
    [SerializeField] private NavMeshAgent navMeshAgent;

    private void Update()
    {
        MovementWithMouse();
    }

    private void MovementWithMouse()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                navMeshAgent.SetDestination(hit.transform.position);
            } 
        }
    }
}
