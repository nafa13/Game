using UnityEngine;

public class ProximityLight : MonoBehaviour
{
    public Transform player;
    public float radiusDeteksi = 15f; 
    
    private Light myLight;
    private Color warnaAsli; 

    void Start()
    {
        myLight = GetComponent<Light>();
        warnaAsli = myLight.color; 
    }

    void Update()
    {
        // 1. CEK WAKTU: Apakah saat ini sedang SIANG?
        if (DayNightToggle.isDay == true)
        {
            // Matikan bohlam karena ada matahari
            myLight.enabled = false;
            return; // Hentikan pengecekan jarak agar hemat memori
        }

        // 2. CEK JARAK: Jika MALAM, jalankan sensor karakter
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= radiusDeteksi)
        {
            myLight.color = Color.red;
            myLight.enabled = true; // Bohlam menyala merah
        }
        else
        {
            myLight.color = warnaAsli;
            myLight.enabled = true; // Bohlam menyala kuning normal
        }
    }
}