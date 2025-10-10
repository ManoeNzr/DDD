using UnityEngine;

public class CoinRecolter : MonoBehaviour
{
    [Header("R�glages d�attraction")]
    [Tooltip("Distance max � laquelle les pi�ces sont attir�es")]
    public float distanceMax = 5f;

    [Tooltip("Vitesse � laquelle les pi�ces s'approchent")]
    public float attractionSpeed = 5f;

    [Header("R�f�rence du joueur")]
    public Transform player;

    [Header("Statistiques du joueur")]
    public static int nombreDePieces = 0;

    private void Update()
    {
        // V�rifie que le joueur est bien d�fini
        if (player == null) return;

        // Trouve toutes les pi�ces pr�sentes dans la sc�ne
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        foreach (GameObject coin in coins)
        {
            float distance = Vector3.Distance(player.position, coin.transform.position);

            // Si la pi�ce est dans la zone d�attraction
            if (distance < distanceMax)
            {
                // Approche smooth vers le joueur
                coin.transform.position = Vector3.MoveTowards(
                    coin.transform.position,
                    player.position,
                    attractionSpeed * Time.deltaTime * (1 + (distanceMax - distance))
                    );

            }

            // Si la pi�ce touche le joueur
            if (distance < 0.25f)
            {
                nombreDePieces++;
                Destroy(coin);
            }
        }
    }
}
