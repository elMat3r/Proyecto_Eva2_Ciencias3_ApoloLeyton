using UnityEngine;

public class Asteroids_Movement : MonoBehaviour
{
    [SerializeField] private float asteroidSpd;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * asteroidSpd, ForceMode.Impulse);
    }
}
