using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 180f; 

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
