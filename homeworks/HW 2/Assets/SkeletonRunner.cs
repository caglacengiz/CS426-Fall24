using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkeletonRunner : MonoBehaviour
{
    public GameObject skeleton;  // Hareket edecek iskelet objesi
    public GameObject target;    // Hedef obje
    private float startX;        // Başlangıç noktası (X ekseni)
    private float endX;          // Bitiş noktası (X ekseni)
    public float speed = 1.0f;   // Hareket hızı
    private bool movingToEnd = true; // Hareket yönü kontrolü

    void Start()
    {
        startX = skeleton.transform.position.x; // Başlangıç X ekseni
        endX = target.transform.position.x;     // Bitiş X ekseni
        StartCoroutine(MoveBackAndForth()); // Coroutine başlat
    }

    IEnumerator MoveBackAndForth()
    {
        while (true)
        {
            float targetX = movingToEnd ? endX : startX; // X eksenindeki hedef noktası
            
            // Hedefe ulaşana kadar hareket et
            while (Mathf.Abs(skeleton.transform.position.x - targetX) > 0.1f)
            {
                Vector3 newPosition = skeleton.transform.position;
                newPosition.x = Mathf.MoveTowards(
                    skeleton.transform.position.x, 
                    targetX, 
                    speed * Time.deltaTime
                );

                skeleton.transform.position = newPosition; // Sadece X eksenini güncelle

                yield return null; // Bir frame bekle
            }

            // Hedefe ulaştığında yönü tersine çevir
            movingToEnd = !movingToEnd;
            skeleton.transform.Rotate(0, 180, 0); // Yönünü ters çevir

            // Küçük bir bekleme süresi ekleyelim (isteğe bağlı)
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Çarpışmaları algılayan fonksiyon
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player lost! Skeleton hit.");
            SceneManager.LoadScene("LoseScene"); // Direkt kaybetme sahnesine geç
        }
    }

}
