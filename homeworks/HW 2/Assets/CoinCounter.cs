using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private int coinCount = 0;
    private bool isAnektorCollected = false;

    void Awake()
    {
        if (FindObjectsOfType<CoinCounter>().Length > 1)
        {
            Destroy(gameObject); // Eğer zaten bir CoinCounter varsa, yenisini sil
            return;
        }

        DontDestroyOnLoad(gameObject); // CoinCounter sahne değişince kaybolmasın
    }

    public void SetAnektorCollected()
    {
        isAnektorCollected = true;
    }

    public bool GetAnektorCollected()
    {
        return isAnektorCollected;
    }

    public void IncrementCoinCount()
    {
        coinCount++;
        Debug.Log("Coin count: " + coinCount);
    }

    public int GetCoinCount()
    {
        return coinCount;
    }
}
