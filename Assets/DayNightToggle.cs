using UnityEngine;

public class DayNightToggle : MonoBehaviour
{
    [Header("Referensi Objek")]
    public Light sunLight;       
    public Material daySkybox;   
    public Material nightSkybox; 

    // RAHASIANYA DI SINI: public static membuat variabel ini bisa dibaca script lain
    public static bool isDay = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F7))
        {
            isDay = !isDay;

            sunLight.intensity = isDay ? 1f : 0.1f;
            RenderSettings.skybox = isDay ? daySkybox : nightSkybox;
            DynamicGI.UpdateEnvironment(); 
        }
    }
}