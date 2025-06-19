using UnityEngine;

public class BlackHole_Function : MonoBehaviour
{
    [SerializeField] private float upthrust;
    [SerializeField] private float viscocity;
    [SerializeField] private Rigidbody rb;
    public void BlackHolePhysics()
    {
        rb.AddForce(Vector3.up * upthrust);

        rb.AddForce(rb.linearVelocity * viscocity);
    }
}
