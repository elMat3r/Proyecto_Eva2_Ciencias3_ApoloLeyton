using UnityEngine;

public class BlackHole_Function : MonoBehaviour
{
    //[SerializeField] private float upthrust;
    [SerializeField] private float viscocity;
    [SerializeField] private Rigidbody rb;
    public void BlackHolePhysics()
    {
        //rb.AddForce(transform.position * upthrust);
        rb.AddForce(-rb.linearVelocity * viscocity);
    }
}
