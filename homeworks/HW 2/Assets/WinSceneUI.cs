using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinSceneUI : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    void Start()
    {
        if (coinText == null)
        {
            coinText = GameObject.Find("CoinText")?.GetComponent<TextMeshProUGUI>();

            if (coinText == null)
            {
                Debug.LogError("WinSceneUI: CoinText UI nesnesi bulunamadı!");
                return;
            }
        }

        CoinCounter coinCounter = FindObjectOfType<CoinCounter>();

        if (coinCounter != null)
        {
            Debug.Log("WinScene açıldı! CoinCounter bulundu, toplam coin: " + coinCounter.GetCoinCount());
            coinText.text = "Coins Collected: " + coinCounter.GetCoinCount();
        }
        else
        {
            Debug.LogError("WinSceneUI: CoinCounter bulunamadı!");
            coinText.text = "Coins Collected: 0";
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("SampleScene"); // Oyuna geri dön
    }
}
