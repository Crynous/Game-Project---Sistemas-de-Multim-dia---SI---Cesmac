using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Arraste o objeto do player aqui no Inspector
    public Vector3 offset;   // Se quiser manter uma distância (pode ser 0,0,0)
    public float smoothSpeed = 0.125f; // Suavidade da movimentação da câmera

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z); // Mantém o Z da câmera
    }
}
