using UnityEngine;

[CreateAssetMenu(menuName ="InputSO/Movement")]
public class InputSO : ScriptableObject
{
    [SerializeField] public Vector2[] vectors;
    [SerializeField] public float[] floats;
    [SerializeField] public bool[] bools;
}
