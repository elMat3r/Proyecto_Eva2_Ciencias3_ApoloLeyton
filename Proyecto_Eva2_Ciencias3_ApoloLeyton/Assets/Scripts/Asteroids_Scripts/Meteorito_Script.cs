using UnityEngine;

public class Meteorito_Script : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
