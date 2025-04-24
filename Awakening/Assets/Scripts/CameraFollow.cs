using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Arraste o objeto do player aqui no Inspector ou deixe vazio
    public Vector3 offset;   // Se quiser manter uma distância (pode ser 0,0,0)
    public float smoothSpeed = 0.125f; // Suavidade da movimentação da câmera

    void LateUpdate()
    {
        // Verifica e atualiza o player se necessário
        if (player == null)
        {
            GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
            if (foundPlayer != null)
                player = foundPlayer.transform;
        }

        // Se ainda não achou, sai
        if (player == null) return;

        // Movimentação suave da câmera
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z); // Mantém o Z da câmera
    }
}
