using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSensivity = 3f;

    [SerializeField]
    private float jumpForce = 100f;

    private PlayerMotor playerMotor;

    void Start()
    {
        playerMotor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        Vector3 velocity = new Vector3(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, speed * Input.GetAxis("Vertical") * Time.deltaTime);
        playerMotor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensivity;
        playerMotor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = xRot * lookSensivity;
        playerMotor.RotateCamera(-cameraRotationX);

        Vector3 jumpForceLocal = Vector3.zero;
        if(Input.GetButton("Jump"))
        {
            jumpForceLocal = Vector3.up * jumpForce;
        }

        playerMotor.Jump(jumpForceLocal);
    }
}
