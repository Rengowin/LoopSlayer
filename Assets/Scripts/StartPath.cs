using UnityEngine;

public class StartPath : MonoBehaviour
{
    private int timesLooped = 0;
    public int TimesLooped { get => timesLooped; }

    private void OnTriggerEnter(Collider other)
    {
        timesLooped++;
        BattelControler.Instance.Player.Heal();
    }
}