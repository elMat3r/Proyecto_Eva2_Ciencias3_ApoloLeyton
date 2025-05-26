using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    [SerializeField] private float moveSpd;
    [SerializeField] private float rotationSpd;
    [SerializeField] private float radio;
    [SerializeField] private float overlapRadio;
    [SerializeField] private float maxDistance;
    [SerializeField] private float atractForce;
    [SerializeField] private float pushForce;
    [SerializeField] private Transform playerPosition;

    public float x, y;
    public LayerMask layerMask;
    void Update()
    {
        //----Movimiento----//
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, 0, y * Time.deltaTime * rotationSpd);
        transform.Translate(x * Time.deltaTime * moveSpd, 0, 0);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            RepulsionSystem(playerPosition.position, radio);
        }
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
    public void RepulsionSystem(Vector3 center, float ratio)
    {
        Collider[] hitsColliders = Physics.OverlapSphere(center, ratio);
        for (int i = 0; i < hitsColliders.Length; i++)
        {
            Rigidbody rb = hitsColliders[i].attachedRigidbody;
            //hitsColliders[i].transform.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f);
            Vector3 dir = hitsColliders[i].transform.position - playerPosition.position;
            rb.AddForce(dir.normalized * 1 / dir.magnitude * pushForce, ForceMode.Impulse);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
