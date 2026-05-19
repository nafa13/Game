using UnityEngine;

public class PintuOtomatis : MonoBehaviour
{
    public Transform engselPintu; // Objek pintu yang akan diputar
    public float sudutBuka = 90f; // Berapa derajat pintunya terbuka
    public float kecepatan = 2f;  // Kecepatan gerak pintu

    private Quaternion rotasiAwal;
    private Quaternion rotasiTujuan;
    private bool sedangTerbuka = false;

    void Start()
    {
        // Menyimpan posisi tertutup saat game dimulai
        rotasiAwal = engselPintu.localRotation;
        // Menghitung posisi terbuka (rotasi awal + sudut buka)
        rotasiTujuan = rotasiAwal * Quaternion.Euler(0, sudutBuka, 0);
    }

    void Update()
    {
        // Menggerakkan pintu secara halus (Smooth)
        if (sedangTerbuka)
        {
            engselPintu.localRotation = Quaternion.Slerp(engselPintu.localRotation, rotasiTujuan, Time.deltaTime * kecepatan);
        }
        else
        {
            engselPintu.localRotation = Quaternion.Slerp(engselPintu.localRotation, rotasiAwal, Time.deltaTime * kecepatan);
        }
    }

    // Mendeteksi jika Player masuk area sensor
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sedangTerbuka = true;
        }
    }

    // Mendeteksi jika Player keluar area sensor
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sedangTerbuka = false;
        }
    }
}