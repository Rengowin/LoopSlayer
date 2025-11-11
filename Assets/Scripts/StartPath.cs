using UnityEngine;

public class StartPath : MonoBehaviour
{
   //überlegen ob Singelton machen
    private int timesLooped = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int TimesLooped { get => timesLooped; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        timesLooped++;
        Debug.Log("Anzahl der durchläufe: " + timesLooped);
    }
}