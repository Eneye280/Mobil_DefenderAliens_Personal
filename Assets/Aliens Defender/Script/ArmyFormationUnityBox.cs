using System.Collections.Generic;
using UnityEngine;

public class ArmyFormationUnityBox : MonoBehaviour
{
    [SerializeField] private int unitWidth;
    [SerializeField] private int unitDepth;
    [SerializeField] private float spread;
    [SerializeField] private float nthOffset;
    [SerializeField] private float noise;
    [SerializeField] private bool hollow;

    public IEnumerable<Vector3> EvaluatePoins()
    {
        var middleOffset = new Vector3(unitWidth * 0.5f, 0, unitDepth * 0.5f);

        for (var x = 0; x < unitWidth; x++)
        {
            for (var z = 0; z < unitDepth; z++)
            {
                if (hollow && x != 0 && x != unitWidth - 1 && z != 0 && z != unitDepth - 1) continue;
                var pos = new Vector3(x + (z % 2 == 0 ? 0 : nthOffset), 0, z);

                pos -= middleOffset;

                pos += GetNoise(pos);

                pos *= spread;

                yield return pos;
            }
        }
    }

    private Vector3 GetNoise(Vector3 pos)
    {
        var _noise = Mathf.PerlinNoise(pos.x * noise, pos.z * noise);
        return new Vector3(_noise,0,_noise);
    }
}
