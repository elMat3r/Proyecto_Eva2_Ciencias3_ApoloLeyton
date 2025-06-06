using System.Collections;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpd;
    [SerializeField] private float rotationSpd;

    [Header("Spherecast")]
    [SerializeField] private float radio;
    [SerializeField] private float maxDistance;
    [SerializeField] private float coneLimit;
    [SerializeField] private float atractForce;
    public LayerMask meteorLayerMask;

    [Header("Overlap")]
    [SerializeField] private float overlapRadio;
    [SerializeField] private float pushForce;
    public LayerMask asteroidLayerMask;

    [Header("Proyectiles")]
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpd;

    [Header("Others")]
    [SerializeField] private Transform playerPosition;
    public float x, y;
    [SerializeField] SceneManager_Script sceneManager;
    void Update()
    {
        //----Movimiento----//
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, 0, y * Time.deltaTime * rotationSpd);
        transform.Translate(x * Time.deltaTime * moveSpd, 0, 0);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            RepulsionSystem(playerPosition.position, radio, asteroidLayerMask);
        }
        VacuumSystem();
        Shoot();
    }
    public void VacuumSystem()
    {
        //----SphereCast----//

        if (Input.GetKey(KeyCode.Space))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit[] hits = Physics.SphereCastAll(ray, radio, maxDistance, meteorLayerMask);
            foreach (RaycastHit hit in hits)
            {
                Rigidbody rb = hit.collider.attachedRigidbody;
                if (rb != null)
                {
                    Vector3 dir = hit.transform.position - transform.position;
                    float coneAngle = Vector3.Angle(transform.right, dir);
                    if(coneAngle <= coneLimit)
                    {
                        rb.AddForce(-dir.normalized * atractForce, ForceMode.Force);
                    }
                }
            }
        }
    }
    public void RepulsionSystem(Vector3 center, float ratio, LayerMask layerMask)
    {
        //-------Overlap------//

        Collider[] hitsColliders = Physics.OverlapSphere(center, ratio, layerMask);
        for (int i = 0; i < hitsColliders.Length; i++)
        {
            Rigidbody rb = hitsColliders[i].attachedRigidbody;
            //hitsColliders[i].transform.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f);
            Vector3 dir = hitsColliders[i].transform.position - playerPosition.position;
            //rb.AddForce(dir.normalized * 1 / dir.magnitude * pushForce, ForceMode.Impulse);
            rb.AddForce(dir.normalized * pushForce, ForceMode.Impulse);
        }
    }
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            var bullet = Instantiate(bulletPrefab, spawnBullet.position, spawnBullet.rotation);
            bullet.GetComponent<Rigidbody>().linearVelocity = spawnBullet.right * bulletSpd;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroide Grande") || other.CompareTag("Asteroide Mediano"))
        {
            Destroy(gameObject);
            sceneManager.Lose();
        }
    }
    private void OnDestroy()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }

    //IEnumerator Shooting()
    //{
    //    if (Input.GetKeyDown(KeyCode.X))
    //    {
    //        var bullet = Instantiate(bulletPrefab, spawnBullet.position, spawnBullet.rotation);
    //        bullet.GetComponent<Rigidbody>().linearVelocity = spawnBullet.right * bulletSpd;
    //        yield return new WaitForSeconds(1);
    //    }
    //}
}
