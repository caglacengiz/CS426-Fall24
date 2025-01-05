using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Oyuncu kapıya çarptı mı?
        {
            CoinCounter coinCounter = FindObjectOfType<CoinCounter>();

            if (coinCounter != null && coinCounter.GetAnektorCollected())
            {
                Debug.Log("Kapıya anahtarla ulaşıldı! WinScene'e gidiliyor...");
                SceneManager.LoadScene("WinScene"); // Kazanma sahnesine geç
            }
            else
            {
                Debug.Log("Kapıya anahtarsız ulaşıldı! Geri dönmelisin.");
            }
        }
    }
}
