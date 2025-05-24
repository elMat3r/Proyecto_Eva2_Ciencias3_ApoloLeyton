using UnityEngine;

public class Asteroids_Movement : MonoBehaviour
{
    [SerializeField] private float asteroidSpd;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;

    private float t = 0f;
    private void Update()
    {
        //Mathf.Repeat hace un loop del valor t, por lo que nunca sera
        //mas largo que el Lenght y nunca mas pequeño que 0

        t = Mathf.Repeat(Time.time * asteroidSpd, 1f); //Time.time se utiliza para que el movimiento
                                                       //dependa del tiempo transcurrido y no por los frames
        transform.position = Vector3.Lerp(startPos, endPos, t);
    }
}
