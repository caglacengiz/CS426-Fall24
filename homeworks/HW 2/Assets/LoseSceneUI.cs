using UnityEngine;
using TMPro; // TextMeshPro için gerekli!
using UnityEngine.SceneManagement;

public class LoseSceneUI : MonoBehaviour
{
    public TextMeshProUGUI coinText; // Text yerine TextMeshProUGUI kullan

    void Start()
    {
        // Eğer coinText Inspector'da atanmadıysa, otomatik olarak bul
        if (coinText == null)
        {
            coinText = GameObject.Find("CoinText")?.GetComponent<TextMeshProUGUI>();

            if (coinText == null)
            {
                Debug.LogError("LoseSceneUI: CoinText UI nesnesi bulunamadı!");
                return;
            }
        }

        // CoinCounter'ı bul ve UI'ye değer yaz
        CoinCounter coinCounter = FindObjectOfType<CoinCounter>();

        if (coinCounter != null)
        {
            Debug.Log("LoseScene açıldı! CoinCounter bulundu, toplam coin: " + coinCounter.GetCoinCount());
            coinText.text = "Coins Collected: " + coinCounter.GetCoinCount();
        }
        else
        {
            Debug.LogError("LoseSceneUI: CoinCounter bulunamadı!");
            coinText.text = "Coins Collected: 0";
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("SampleScene"); // Oyuna geri dön
    }
}
