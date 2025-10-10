using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 5f; // pour lisser un peu la rotation

    void Update()
    {
        // Direction complète vers le joueur (on ne bloque plus l’axe Y)
        Vector3 direction = player.position - transform.position;

        if (direction.sqrMagnitude > 0.001f)
        {
            // Calculer la rotation vers le joueur
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            // Appliquer la rotation (smooth)
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
