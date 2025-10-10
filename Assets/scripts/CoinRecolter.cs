using UnityEngine;

public class CoinRecolter : MonoBehaviour
{
    [Header("Réglages d’attraction")]
    [Tooltip("Distance max à laquelle les pièces sont attirées")]
    public float distanceMax = 5f;

    [Tooltip("Vitesse à laquelle les pièces s'approchent")]
    public float attractionSpeed = 5f;

    [Header("Référence du joueur")]
    public Transform player;

    [Header("Statistiques du joueur")]
    public static int nombreDePieces = 0;

    private void Update()
    {
        // Vérifie que le joueur est bien défini
        if (player == null) return;

        // Trouve toutes les pièces présentes dans la scène
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        foreach (GameObject coin in coins)
        {
            float distance = Vector3.Distance(player.position, coin.transform.position);

            // Si la pièce est dans la zone d’attraction
            if (distance < distanceMax)
            {
                // Approche smooth vers le joueur
                coin.transform.position = Vector3.MoveTowards(
                    coin.transform.position,
                    player.position,
                    attractionSpeed * Time.deltaTime * (1 + (distanceMax - distance))
                    );

            }

            // Si la pièce touche le joueur
            if (distance < 0.25f)
            {
                nombreDePieces++;
                Destroy(coin);
            }
        }
    }
}
