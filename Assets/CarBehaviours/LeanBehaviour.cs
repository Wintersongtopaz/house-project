using UnityEngine;

public class LeanBehaviour : MonoBehaviour
{
    [Tooltip("A float value determining the maximum degrees the GameObject can lean to the left or right")]
    [Range(15f,45f)]
    [SerializeField] private float maxAngle = 15f;
    [Tooltip("A reference value used to get information from a CarBehaviour script.")]
    [SerializeField] private CarBehaviour carBehaviour;

    // Update is called once per frame
    void Update()
    {
        if (!carBehaviour) return;
            
        Vector3 localRotation = transform.localRotation.eulerAngles;
        localRotation.z = Mathf.Clamp(carBehaviour.turnAmount * maxAngle, -maxAngle, maxAngle);
        transform.localRotation = Quaternion.Euler(localRotation);

    }
}
