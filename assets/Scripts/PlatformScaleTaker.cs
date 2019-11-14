using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScaleTaker : MonoBehaviour
{
    private static PlatformScaleTaker _instance;
    public static PlatformScaleTaker Instance { get { return _instance; } }

    [SerializeField] GameObject platform;

     float xPos;
     float yPos;
     float zPos;


    private void Awake()
    {
        if (Instance == null) { _instance = this; }

        platform = GameObject.Find("Platform");

        StartCoroutine(Destroyer());
    }

    private void Start()
    {
        xPos = platform.transform.localScale.x;
        yPos = platform.transform.localScale.y;
        zPos = platform.transform.localScale.z;
    }

    // Metod çağrılırken değerleri al ve formülü uygulayıp Vector3 değeri döndür, objeler doğru yerlere yerleştirilsin.
    
    // Formül mantığı : Platform objesinin scale değerlerini alıyoruz ki ne kadarını kullanabileceğimizi bilelim.
    // Örneğin: 100,10,100 büyüklüğünde ise random obje yerleştirmek için -50 ile 50 değerine çıkabiliriz maksinmum. 
    // Çünkü orjin noktası 0 platfromun yarısı - değerlerde.
    
    // Kodun amacı: Platform büyüklüğü değişse bile objeler, tavuklar ve engeller belli oranda yerleştirilsin. 
    public Vector3 ScaleFormule(float frequency,float posFixValue,float heightFromPlatform)
    {
        float randomXPos = Random.Range(-xPos / frequency + posFixValue, xPos / frequency - posFixValue);
        float randomYPos = heightFromPlatform;
        float randomZPos = Random.Range(-zPos / frequency + posFixValue, zPos / frequency - posFixValue);

        Vector3 randomPos = new Vector3(randomXPos, randomYPos, randomZPos);

        return randomPos;
    }
    // Belli bir süre sonra bu objeyi sil ki ram'de yer kaplamasın boş yere 
    // (Singleton olduğu için silinmeyecek ama sadece bölüm başında lazım.)
    // (Singleton olmasının nedeni de 4 farklı scriptten ulaşılacak, bildiğim en kolay yol bu.)
    IEnumerator Destroyer() { yield return new WaitForSeconds(5f); Destroy(gameObject); }
  
}
