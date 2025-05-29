using UnityEngine;

public class Camera_Teleport : MonoBehaviour
{
    private Transform transformObject;
    private void Awake()
    {
        transformObject = GetComponent<Transform>();
    }
    private void Update()
    {
        Vector3 positionViewPort = Camera.main.WorldToViewportPoint(transformObject.position);
        if (positionViewPort.x > 1)
        {
            positionViewPort.x = 0;
        }
        else if (positionViewPort.y > 1)
        {
            positionViewPort.y = 0;
        }
        else if (positionViewPort.x < 0)
        {
            positionViewPort.x = 1;
        }
        else if (positionViewPort.y < 0)
        {
            positionViewPort.y = 1;
        }
        else return;
        //Evita que se modifique la posicion cuando esta no es necesaria
        transformObject.position = Camera.main.ViewportToWorldPoint(positionViewPort);
    }
}
