using UnityEngine;

public class BlackHole_Function : MonoBehaviour
{
    [SerializeField] private float viscocity;
    [SerializeField] private Rigidbody rb;
    public void BlackHolePhysics()
    {
        rb.AddForce(-rb.linearVelocity * viscocity);
    }
}
