using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    int howMannyCanBeOnME = 0;

    [SerializeField]
    int howMannyEnemysAreOneMe = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Um zu sehen ob das script da ist :D
        Debug.Log("Es ist da!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(howMannyEnemysAreOneMe > 0)
        {
            
        }
    }
}
