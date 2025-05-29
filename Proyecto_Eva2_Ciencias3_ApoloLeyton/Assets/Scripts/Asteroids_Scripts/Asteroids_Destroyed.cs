using Unity.VisualScripting;
using UnityEngine;

public class Asteroids_Destroyed : MonoBehaviour
{
    public GameObject[] subAsteroids;
    public int asteroidsNumbers;
    private Collider objectCollider;

    private bool isDestroy = false;
    private void Awake()
    {
        objectCollider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isDestroy) return;
        if (other.CompareTag("Bullet"))
        {
            isDestroy = true;
            Destroy(gameObject);
            Destroy(other.gameObject);
            for (var i = 0; i < asteroidsNumbers; i++)
            {
                Instantiate(subAsteroids[Random.Range(0, subAsteroids.Length - 1)], GetBounds(objectCollider), Quaternion.identity);
            }
        }
    }
    private Vector3 GetBounds(Collider collider)
    {
        //A partir de los limites del collider va a seleccionar
        //una posicion random entre el eje x e y.
        float x = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        float y = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
        return new Vector3(x, y, transform.position.z);
    }
}
