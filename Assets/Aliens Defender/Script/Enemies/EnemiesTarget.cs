using UnityEngine;

public class EnemiesTarget : MonoBehaviour
{
    [SerializeField] private Transform[] targets;

    internal Vector3 AddDestionation()
    {
        var destination = targets[Random.Range(0, targets.Length)].position;
        return destination;
    }
}
