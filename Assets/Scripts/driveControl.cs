using UnityEngine;

public class driveControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D frontWheel;
    [SerializeField] private Rigidbody2D backWheel;
    [SerializeField] private Rigidbody2D bikeBody;

    [SerializeField] private float speed = 150f;
    [SerializeField] private float tiltSpeed = 100f;
    private float moveInput;
    private float tiltInput;

    private bool canControl = false; 

    void Update()
    {
        if (!canControl) return;

        moveInput = Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0;
        tiltInput = Input.GetKey(KeyCode.A) ? 1 : Input.GetKey(KeyCode.D) ? -1 : 0;
    }

    private void FixedUpdate()
    {
        if (!canControl) return;

        frontWheel.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        backWheel.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        bikeBody.AddTorque(tiltInput * tiltSpeed * Time.fixedDeltaTime);
        Debug.Log($"MoveInput: {moveInput}, TiltInput: {tiltInput}");
    }

    public void EnableControls()
    {
        canControl = true;
    }

    public void DisableControls()
    {
        canControl = false;
    }
}
