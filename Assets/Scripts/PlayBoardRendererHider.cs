using UnityEngine;

public class PlayBoardRendererHider : MonoBehaviour
{
    public void SetVisible(bool visible)
    {
        // Dynamisch ALLE Renderer holen (inkl. nachträglich gespawnter Gegner)
        Renderer[] renderers = GetComponentsInChildren<Renderer>(true);

        foreach (var r in renderers)
        {
            if (r != null)
                r.enabled = visible;
        }
    }
}
