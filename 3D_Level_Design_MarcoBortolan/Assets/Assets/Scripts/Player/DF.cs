using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DF : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float focusSpeed = 5f; // Speed at which the focus adjusts

    private Volume volume;
    private DepthOfField depthOfField;

    void Start()
    {
        // Get the Volume component
        volume = GetComponent<Volume>();

        if (volume == null || !volume.profile.TryGet(out depthOfField))
        {
            Debug.LogError("No Depth of Field settings found on Volume!");
            enabled = false;
        }
    }

    void Update()
    {
        if (player == null || depthOfField == null)
        {
            return;
        }

        // Calculate the distance between the camera and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Smoothly adjust the focal distance
        depthOfField.focusDistance.Override(Mathf.Lerp(depthOfField.focusDistance.value, distanceToPlayer, Time.deltaTime * focusSpeed));
    }
}
