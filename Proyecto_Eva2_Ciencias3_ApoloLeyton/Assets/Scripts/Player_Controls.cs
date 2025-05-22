using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    [SerializeField] private float moveSpd;
    [SerializeField] private float rotationSpd;
    [SerializeField] private float radio;
    [SerializeField] private float maxDistance;
    [SerializeField] private float atractForce;

    public float x, y;
    public LayerMask layerMask;
    void Update()
    {
        //----Movimiento----//
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, 0, y * Time.deltaTime * rotationSpd);
        transform.Translate(x * Time.deltaTime * moveSpd, 0, 0);

        VacuumSystem();
    }
    public void VacuumSystem()
    {
        //----SphereCast----//

        if (Input.GetKey(KeyCode.Space))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit[] hits = Physics.SphereCastAll(ray, radio, maxDistance, layerMask);
            foreach (RaycastHit hit in hits)
            {
                Rigidbody rb = hit.collider.attachedRigidbody;
                if (rb != null)
                {
                    Vector3 dir = hit.transform.position - transform.position;
                    rb.AddForce(-dir.normalized * atractForce, ForceMode.Force);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
