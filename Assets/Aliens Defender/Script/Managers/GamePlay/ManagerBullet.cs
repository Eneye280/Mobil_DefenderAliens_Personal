using UnityEngine;

public class ManagerBullet : MonoBehaviour
{
    private ManagerHealth managerHealth;

    [Header("Values")]
    [Range(0, 100)]
    [SerializeField] private float speed;
    [Range(0,100)]
    [SerializeField] private float damage;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemie"))
        {
            managerHealth = other.GetComponent<ManagerHealth>();
            managerHealth.healthMax -= damage;
            managerHealth.CheckHealth();

            gameObject.SetActive(false);
        }
    }
}
