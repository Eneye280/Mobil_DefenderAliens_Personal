using UnityEngine;
using UnityEngine.AI;

public class EnemiesFollowTarget : MonoBehaviour
{
    private EnemiesTarget enemiesTarget;

    [Header("Values")]
    [Range(-10, 10)]
    [SerializeField] private float minSpeed, maxSpeed;

    private float speedEnemies;

    [Header("IA")]
    [SerializeField] private NavMeshAgent navMeshAgent;

    private void Start()
    {
        enemiesTarget = FindObjectOfType<EnemiesTarget>();

        speedEnemies = Random.Range(minSpeed, maxSpeed);
        navMeshAgent.speed = speedEnemies;

        AddDestination();
    }

    private void AddDestination()
    {
        navMeshAgent.SetDestination(enemiesTarget.AddDestionation());
    }
}
