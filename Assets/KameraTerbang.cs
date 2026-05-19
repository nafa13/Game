using UnityEngine;

public class KameraTerbang : MonoBehaviour
{
    public float kecepatanTerbang = 10f;
    public float sensitivitasMouse = 2f;

    private float rotasiX = 0f;
    private float rotasiY = 0f;

    void Start()
    {
        // Kunci kursor mouse di tengah layar saat play
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        // 1. Nengok Kiri-Kanan & Atas-Bawah (Mouse)
        rotasiX -= Input.GetAxis("Mouse Y") * sensitivitasMouse;
        rotasiY += Input.GetAxis("Mouse X") * sensitivitasMouse;
        rotasiX = Mathf.Clamp(rotasiX, -90f, 90f); // Biar kepala gak muter 360 derajat

        transform.rotation = Quaternion.Euler(rotasiX, rotasiY, 0);

        // 2. Maju Mundur Kiri Kanan (WASD)
        float gerakX = Input.GetAxis("Horizontal");
        float gerakZ = Input.GetAxis("Vertical");
        float gerakY = 0f;

        // 3. Naik Turun ala Drone (Tombol E untuk naik, Q untuk turun)
        if (Input.GetKey(KeyCode.E)) gerakY = 1f;
        if (Input.GetKey(KeyCode.Q)) gerakY = -1f;

        // Terapkan pergerakan
        Vector3 arahGerak = transform.right * gerakX + transform.forward * gerakZ + transform.up * gerakY;
        transform.position += arahGerak * kecepatanTerbang * Time.deltaTime;
    }
}