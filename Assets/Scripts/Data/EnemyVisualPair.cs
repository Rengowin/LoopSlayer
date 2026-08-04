using UnityEngine;

public class EnemyVisualPair
{
    public Enemy enemy;
    public GameObject visual;
    public GameObject uiObject;

    public EnemyVisualPair(Enemy enemy, GameObject visual)
    {
        this.enemy = enemy;
        this.visual = visual;
    }

    public void DestroyVisual()
    {
        if (visual != null)
            GameObject.Destroy(visual);
    }

}
