using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BuffEffect : MonoBehaviour
{

    [SerializeField]
    List<BuffClass> possibleBuffs = new List<BuffClass>();


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
        BuffsThatIGet buffsThatIGet = other.GetComponent<BuffsThatIGet>();
        if(buffsThatIGet != null)
        {
            foreach(BuffClass buff in possibleBuffs)
            {
                buffsThatIGet.AddBuff(buff.BuffName(), buff.BuffAmount());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        BuffsThatIGet buffsThatIGet = other.GetComponent<BuffsThatIGet>();
        if (buffsThatIGet != null)
        {
            foreach (BuffClass buff in possibleBuffs)
            {
                buffsThatIGet.RemoveBuff(buff.BuffName(), buff.BuffAmount());
            }
        }

    }
}
