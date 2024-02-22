using UnityEngine;
using UnityEngine.Events;

public class CollectibleBehaviour : MonoBehaviour
{
    /*
        Private Fields.
    */
    private bool active = true; // Used to track whether or not the collectible is active.

    /*
        Private Fields exposed to editor.
    */
    [Tooltip("Instantiates this particle system prefab when player collects object.")]
    [SerializeField] private GameObject particlePrefab;
    [Tooltip("Only GameObjects with this tag will be able to collect this object")]
    [SerializeField] private string validTag = "none";
    [Tooltip("The range of time before this object reappears after being collected")]
    [SerializeField] private Vector2 reappearTime = new Vector2(2.5f,5f);
    [Tooltip("Whether to print debug logs to console")]
    [SerializeField] private bool debugLog = false;

    /*
        Events
    */
    [Tooltip("Event triggered when this collectible is collected")]
    public UnityEvent OnCollect = new UnityEvent(); // Invoked upon valid trigger enter.

    /*
        Add local listeners to OnCollect event.
    */
    private void Awake()
    {
        OnCollect.AddListener(SpawnParticles);
        OnCollect.AddListener(ToggleActive);
        OnCollect.AddListener(StartReappearTime);
    }

    /*
        When another valid collider enters this trigger invoke OnCollect.
    */
    private void OnTriggerEnter(Collider other)
    {
        if (!active) return;

        // Only invoke if other collider has correct tag and collectible is active.
        if (other.tag == validTag && active)
        {
            OnCollect.Invoke();

            if (debugLog) Debug.Log("On Trigger Enter");
        }
    }

    /*
        Invoke Toggle active after random amount of time in reappear time range.
    */
    private void StartReappearTime()
    {
        Invoke("ToggleActive", Random.Range(reappearTime.x, reappearTime.y));
    }

    /*
        Invert value of active and set active state of child
        GameObjects and Components accordingly.
    */
    private void ToggleActive()
    {
        active = !active;

        SetChildrenActiveState(active);
    }

    /*
        Iterate through children to set active state. Keeps parent (this)
        GameObject active but toggles active state of all children. The purpose
        is to allow the GameObject to "reappear" on it's own without creating 
        another instance or using other scripts.
    */
    private void SetChildrenActiveState(bool value)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(value);
        }
    }

    /*
        Instantiates the particle prefab at this GameObject's position and rotation.
    */
    private void SpawnParticles()
    {
        if (particlePrefab) Instantiate(particlePrefab, transform.position, transform.rotation);
    }
}
