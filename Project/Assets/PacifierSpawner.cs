using UnityEngine;

public class PacifierSpawner : MonoBehaviour
{
    public GameObject pacifierPrefab; // Prefab emzik modeli
    public Transform[] spawnPoints; // Odanın köşeleri
    public int maxPacifiersPerPoint = 15; // Her noktadan maksimum spawn sayısı

  
    public void SpawnAllPacifiers()
    {
        // Her spawn noktasından aynı anda nesne oluştur
        foreach (Transform spawnPoint in spawnPoints)
        {
            for (int i = 0; i < maxPacifiersPerPoint; i++)
            {
                // Prefab'ı spawnla
                Instantiate(pacifierPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
