using System;
using System.Collections;
using System.Collections.Generic;
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

    [Header("Queue")]
    public float maxTime;
    private Queue<KeyCode> myQueue = new Queue<KeyCode>();

    [Header("Others")]
    [SerializeField] private Transform playerPosition;
    public float x, y;
    [SerializeField] SceneManager_Script sceneManager;
    void Update()
    {
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
        QueueList();
    }
    public void VacuumSystem()
    {
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
        Collider[] hitsColliders = Physics.OverlapSphere(center, ratio, layerMask);
        for (int i = 0; i < hitsColliders.Length; i++)
        {
            Rigidbody rb = hitsColliders[i].attachedRigidbody;
            Vector3 dir = hitsColliders[i].transform.position - playerPosition.position;
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
    void QueueList()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myQueue.Enqueue(KeyCode.UpArrow);
            WordCreation();
            Invoke("EliminateFromList", maxTime);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myQueue.Enqueue(KeyCode.RightArrow);
            WordCreation();
            Invoke("EliminateFromList", maxTime);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myQueue.Enqueue(KeyCode.DownArrow);
            WordCreation();
            Invoke("EliminateFromList", maxTime);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myQueue.Enqueue(KeyCode.LeftArrow);
            WordCreation();
            Invoke("EliminateFromList", maxTime);
        }
    }
    void EliminateFromList()
    {
        myQueue.Dequeue();
    }
    private void WordCreation()
    {
        string newWord = null;
        foreach (KeyCode key in myQueue)
        {
            newWord += key.ToString();
        }
        print(newWord);
        if (newWord == "UpArrowRightArrowDownArrowLeftArrow")
        {
            Debug.Log("Se logro");
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

}
