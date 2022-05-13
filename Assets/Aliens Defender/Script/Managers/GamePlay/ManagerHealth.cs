using UnityEngine;

public class ManagerHealth : MonoBehaviour
{
    internal enum TypeObject
    {
        enemie, player
    }
    internal TypeObject typeObject;

    [SerializeField] internal float healthMax;

    internal void CheckHealth()
    {
        if(healthMax <= 0)
        {
            Destroy();
        }
    }

    private void Destroy() => gameObject.SetActive(false);

}
