using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int starCost = 100;
    private SpriteRenderer[] spriteRenderer = null;

    private void Awake()
    {
        spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
    }

    public void AddStars(int amount)
    {
        StarDisplay.AddStars(amount);
    }

    public int GetStarCost()
    {
        return starCost;
    }

    public void SetSortingOrder(int order)
    {
        foreach(SpriteRenderer sprite in spriteRenderer)
        {
            sprite.sortingOrder = order;
        }
    }
}
