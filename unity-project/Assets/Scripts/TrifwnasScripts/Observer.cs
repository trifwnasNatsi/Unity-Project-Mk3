using UnityEngine;
public class Observer : MonoBehaviour
{
    [SerializeField] private bool ignoreOurSkin = true;
    [SerializeField] private bool ignoreTargetSkin = true;

    public float GetDistanceTo(Transform target)
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (ignoreOurSkin)
            distance -= transform.lossyScale.z;
        if (ignoreTargetSkin)
            distance -= target.lossyScale.z;
        return distance;
    }
}