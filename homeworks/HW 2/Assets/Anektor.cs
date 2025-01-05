using UnityEngine;

public class Anektor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Eğer oyuncu anahtara temas ettiyse
        {
            CoinCounter coinCounter = FindObjectOfType<CoinCounter>();

            if (coinCounter != null)
            {
                coinCounter.SetAnektorCollected(); // Anektor alındı
                Debug.Log("Anektor alındı!");
                Destroy(gameObject); // Anahtar yok ediliyor
            }
            else
            {
                Debug.LogError("Anektor: CoinCounter bulunamadı!");
            }
        }
    }
}
