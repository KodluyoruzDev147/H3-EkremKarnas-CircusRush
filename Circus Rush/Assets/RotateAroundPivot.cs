using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RotateAroundPivot : MonoBehaviour
{

    public List<Transform> pinList = new List<Transform>();
    public Transform satellite; // Objects rotating around the center
    /* ZTK was here
     * Kodlamada isimlendirme standartları çok önemlidir.
     * Birisinin mülakat ödevini kontrol ettiğim zaman 
     * isimlendirme yapılırken aynı özelliklerde iki farklı değişkenin birisi küçük birisi bütük harfle başlanmış şekilde görürsem
     * Bu iki farklı ihtimale işaret eder...
     * Ya isimlendirme standartlarına önem vermeden yazma alışkanlığı bulunuyor (Bu çok kötü bir durum)
     * Ya da kodun bu kısmı projeyi yapan kişi tarafından yazılmamış, yani dışarıdan hazır alınmış kod (Bu çok daha kötü bir durum)
     * 
     * Önemsizmiş gibi görünse de sadece bir harf farkından bile çok fazla anlam çıkabiliyor.
     * Bu standartlara çok dikkat etmeni öneririm.
     */
    public static int Satellitecount = 1;
    public static float distanceFromCenter = 0.3f;
    public int rotationSpeed = 5;
   
    private void PlaceSatellitesAround() // Instantiating objects equally between spaced each other
    {
        for (int i = 0; i < Satellitecount; i++)
        {
            var angle = i * (360f / Satellitecount);
            var direction = Quaternion.Euler(0, 0, angle) * Vector3.up;
            var position = transform.position + direction * distanceFromCenter;
            Transform pin = Instantiate(satellite, position, Quaternion.Euler(180f, 90f, 0f), transform);
            pinList.Add(pin);
        }
    }
    public void CollectPin() // Destroy previous list, SatelliteCount++, Instantiate new list
    {
        transform.parent.position = transform.parent.position + new Vector3(0f, 0.05f, 0f);

        if (Satellitecount == pinList.Count)
        {
            Satellitecount++;
        }

         DestroyList();

        PlaceSatellitesAround();
        Satellitecount++;

        distanceFromCenter += 0.05f;
    }
    public void DropPin() // Destroy previous list, SatelliteCount--, Instantiate new list
    {
        if(pinList.Count < 1)
        return;

        transform.parent.position = transform.parent.position + new Vector3(0f, -0.05f, 0f);
        
        if (Satellitecount > pinList.Count)
        {
            Satellitecount--;
        }
        Satellitecount--;

        DestroyList();


        PlaceSatellitesAround();
        distanceFromCenter -= 0.05f;
    }
    private void Rotate() // Rotate objects arounds axis
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    void Update()
    {
        Rotate();
    }

    void DestroyList() // Destroy and remove all object in the list
    {
        for (int i = pinList.Count; i > 0; i--)
        {
            Transform pin = pinList[pinList.Count - 1];
            Destroy(pin.gameObject);
            pinList.RemoveAt(pinList.Count - 1);
        }
    }
}