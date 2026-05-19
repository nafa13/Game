using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        // Menyembunyikan kursor mouse saat game dimulai
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Mengatur rotasi atas/bawah (Sumbu X)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Mencegah kamera terbalik

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // Memutar badan player ke kiri/kanan (Sumbu Y)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}