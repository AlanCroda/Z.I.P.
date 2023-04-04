using UnityEngine;

[CreateAssetMenu(menuName = "Particle Effects Holder/ Particle Effects")]
public class EffectsSO : ScriptableObject
{
    [Header("Particle Effects")]
    [SerializeField] public ParticleEffect[] effects;
}

[System.Serializable]
public class ParticleEffect {
    [SerializeField] public string Name;
    [SerializeField] public ParticleSystem pfx;
}
