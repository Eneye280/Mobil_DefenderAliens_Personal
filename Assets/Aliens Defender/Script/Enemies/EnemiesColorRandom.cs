using UnityEngine;

public class EnemiesColorRandom : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material[] materialEnemie;

    private void Start()
    {
        Invoke(nameof(RandomColor), .1f);
    }

    private void RandomColor()
    {
        var randomColor = Random.Range(0, materialEnemie.Length);
        AddMaterialToRender(randomColor);
    }

    private void AddMaterialToRender(int index)
    {
        meshRenderer.material = materialEnemie[index];
    }
}
