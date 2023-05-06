using UnityEngine;

[ExecuteInEditMode]
public class LightingManager : MonoBehaviour {
    public Light directionalLight;
    public LightingPreset preset;

    [Range(0,24)] 
    public float timeOfDay = 12;
    public int timeSpeed = 2;

    private void Update() {
        if (Application.isPlaying) {
            timeOfDay += Time.deltaTime/ timeSpeed;
            timeOfDay %= 24 ; // Clamp between 0-24
            UpdateLighting(timeOfDay / (24));
        } else {
            UpdateLighting(timeOfDay / (24));
        }
    }

    private void UpdateLighting(float timePercent) {
        RenderSettings.ambientLight = preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.fogColor.Evaluate(timePercent);

        directionalLight.color = preset.directionalColor.Evaluate(timePercent);
        directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360) -90, 170, 0));
    }
}
