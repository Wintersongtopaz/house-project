using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleBehaviour : MonoBehaviour
{
    [Tooltip("A float value determining the maximum amount this GameObject will rumble up/down in meters")]
    [Range(0.0f, 0.1f)]
    [SerializeField] private float amplitude = 0.04f;
    [Tooltip("A float value determining how quickly this GameObject will rumble up/down")]
    [Range(20f,40f)]
    [SerializeField] private float frequency = 30f;

    private Vector3 initialLocationPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialLocationPosition = transform.localPosition;   
    }

    // Update is called once per frame
    void Update()
    {
        float displacement = (Mathf.Sin(Time.time * frequency) * amplitude);
        transform.localPosition = initialLocationPosition + displacement * Vector3.up;
    }
}
