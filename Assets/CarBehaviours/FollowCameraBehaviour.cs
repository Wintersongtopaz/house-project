using UnityEngine;

public class FollowCameraBehaviour : MonoBehaviour
{
    [Tooltip("A GameObject reference value determining which GameObject the Camera will follow")]
    [SerializeField] private GameObject target;
    
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if (target) offset = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        if (target)
        {
            transform.position = target.transform.position + offset;
        }
    }
}
