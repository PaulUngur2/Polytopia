using UnityEngine;

[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order = 1)]
public class LightingPreset : ScriptableObject {
    public Gradient ambientColor;
    public Gradient directionalColor;
    public Gradient fogColor;
}