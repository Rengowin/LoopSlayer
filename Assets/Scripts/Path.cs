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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contactPoint in collision.contacts)
        {
            Debug.Log("Test");
        }
        if (collision.relativeVelocity.magnitude > 0)
        {
            Debug.Log("Ja");
        }
    }
}
