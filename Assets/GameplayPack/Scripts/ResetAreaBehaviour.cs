using UnityEngine;
using UnityEngine.Events;

public enum TriggerBehaviour
{
    OnEnter, OnExit
}

public class ResetAreaBehaviour : MonoBehaviour
{
    /*
        Private Fields exposed to editor
    */
    [Tooltip("Valid tag to reset on trigger exit")]
    [SerializeField] private string validTag = "none";
    [Tooltip("Position to reset exiting object to")]
    [SerializeField] private Vector3 resetPosition = new Vector3();
    [Tooltip("When to trigger reset behaviour. On Enter will trigger when an object enters the collider. On Exit will trigger when an object exits the collider.")]
    [SerializeField] private TriggerBehaviour triggerBehaviour = TriggerBehaviour.OnExit;
    [Tooltip("Whether to print debug logs to console")]
    [SerializeField] private bool debugLog = false;

    /*
        Events
    */
    [Tooltip("Called when an object is reset to reset position")]
    public UnityEvent<GameObject> OnReset = new UnityEvent<GameObject>();

    /*
        Add local listener to OnReset event.
    */
    private void Awake()
    {
        OnReset.AddListener(ResetGameObjectPosition);
    }

    /*
        Sent entering collider back to reset position.
    */
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == validTag && triggerBehaviour == TriggerBehaviour.OnEnter)
        {
            OnReset.Invoke(other.gameObject);

            if (debugLog) Debug.Log("On Trigger Enter");
        }
    }
    
    /*
        Send exiting collider back to reset position.
    */
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == validTag && triggerBehaviour == TriggerBehaviour.OnExit)
        {
            OnReset.Invoke(other.gameObject);

            if (debugLog) Debug.Log("On Trigger Exit");
        } 
    }

    /*
        Set target GameObject position to reset position.
    */
    private void ResetGameObjectPosition(GameObject target)
    {
        if (target) target.transform.position = resetPosition;
    }
}
