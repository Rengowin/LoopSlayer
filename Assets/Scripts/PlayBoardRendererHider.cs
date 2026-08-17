using UnityEngine;

public class PlayBoardRendererHider : MonoBehaviour
{
    public void SetVisible(bool visible)
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>(true);

        foreach (var r in renderers)
        {
            if (r != null)
                r.enabled = visible;
        }
    }
}
