using UnityEngine;

public class ClockwiseRotator : MonoBehaviour
{
    private const float rotationPerSec = 12.8f;

    private void Update()
    {   
        transform.Rotate(Vector3.up, rotationPerSec * Time.deltaTime);
    }
}