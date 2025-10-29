using UnityEngine;


public class BuffEffect : MonoBehaviour
{

    [SerializeField]
    string buffName;
    [SerializeField]
    float buffAmount;

    [SerializeField]
    GameObject Player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Saw somethink Enter!");        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Saw somethink Exit!");
    }
}
