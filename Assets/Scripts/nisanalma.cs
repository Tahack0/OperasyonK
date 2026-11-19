using UnityEngine;

public class nisanalma : MonoBehaviour
{
    public Vector3 Normal;
    public Vector3 Nisan;
    public float speed;
    public Camera main;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, Nisan, speed * Time.deltaTime);
            main.fieldOfView = 45f;
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, Normal, speed * Time.deltaTime);
            main.fieldOfView = 60f;
        }
    } }

public class MouseSensitivity : MonoBehaviour
{
    public float normalSensitivity = 100f;
    public float aimingSensitivity = 80f; // Niþan alýrken düþecek hassasiyet
    private float currentSensitivity;
    public Transform playerBody;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentSensitivity = normalSensitivity; // Baþlangýç hassasiyeti
    }

    void Update()
    {
        // Niþan alma kontrolü
        if (Input.GetKey(KeyCode.Mouse1))
        {
            currentSensitivity = aimingSensitivity; // Niþan alma sýrasýnda hassasiyet düþüyor
        }
        else
        {
            currentSensitivity = normalSensitivity; // Normal hassasiyet
        }

        // Fare hareketleri
        float mouseX = Input.GetAxis("Mouse X") * currentSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * currentSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}