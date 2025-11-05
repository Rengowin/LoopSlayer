using UnityEngine;

public class StartPath : MonoBehaviour
{
   
    private int timesLooped = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int TimesLooped() => timesLooped;
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
