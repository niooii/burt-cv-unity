using UnityEngine;
using UnityEngine.UIElements;

public class SimpleFlyCam : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float shiftSpeed = 25.0f;
    [SerializeField]
    private float mouseSensitivity = 1f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        xRotation = transform.eulerAngles.x;
        yRotation = transform.eulerAngles.y;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 20 * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 20 * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY; 

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        Vector3 move_vec = GetMovementInput();

        if (move_vec.sqrMagnitude > 0)
        {
            transform.Translate(move_vec.normalized * (Input.GetKey(KeyCode.LeftShift) ? shiftSpeed : speed) * Time.deltaTime);
        }
    }

    private Vector3 GetMovementInput()
    { 
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            p_Velocity += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            p_Velocity += new Vector3(0, -1, 0);
        }
        return p_Velocity;
    }
}