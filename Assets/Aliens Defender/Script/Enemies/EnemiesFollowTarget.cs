using UnityEngine;
using UnityEngine.AI;

public class EnemiesFollowTarget : MonoBehaviour
{
    private EnemiesTarget enemiesTarget;

    [SerializeField] private NavMeshAgent navMeshAgent;

    private void Start()
    {
        enemiesTarget = FindObjectOfType<EnemiesTarget>();

        AddDestination();
    }

    private void AddDestination()
    {
        navMeshAgent.SetDestination(enemiesTarget.AddDestionation()); 
    }
}
