using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private SoundClips sounds = null;
    private static Defender defenderPrefab = null;
    private Camera mainCamera = null;
    private GameObject defendersParent = null;
    private LayerMask enemiesLayer;

    private void Awake()
    {
        mainCamera = Camera.main;
        defendersParent = new GameObject("Defenders");
        enemiesLayer = 1 << LayerMask.NameToLayer("Enemies");

        defenderPrefab = null;
    }

    private void OnMouseDown()
    {
        if (defenderPrefab && !LevelController.gameOver)
        {
            AttemptToPlaceDefenderAt(GetPositionClicked());
        }
    }

    private Vector2 GetPositionClicked()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = mainCamera.ScreenToWorldPoint(mousePos);

        return worldPos;
    }

    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        // Round the floats to match grid ints
        worldPos.x = Mathf.RoundToInt(worldPos.x);
        worldPos.y = Mathf.RoundToInt(worldPos.y);

        return worldPos;
    }

    private void AttemptToPlaceDefenderAt(Vector2 worldPos)
    {
        // Get the stars cost
        int defenderCost = defenderPrefab.GetStarCost();

        // Do I have enough stars to buy the defender?
        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            // Place in the grid to place the defender
            Vector2 spawnPos = SnapToGrid(worldPos);

            // Are there no enemies in the square?
            if(IsAreaCleanOfEnemies(spawnPos))
            {
                // Subtract the cost and Spawn
                StarDisplay.SpendStars(defenderCost);
                SpawnDefender(spawnPos);

                //Sound
                AudioSource.PlayClipAtPoint(sounds.GetClip(0), transform.localPosition, PlayerPrefsController.GetMasterVolume());
            }
        }
    }

    private bool IsAreaCleanOfEnemies(Vector2 spawnPos)
    {
        Collider2D hitCollider = Physics2D.OverlapBox(spawnPos, new Vector2(0.7f, 0.7f), 0f, enemiesLayer);
        
        if (!hitCollider)
        {
            return true;
        }
        
        return false;
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        Defender defender = Instantiate(defenderPrefab, worldPos, Quaternion.identity) as Defender;
        defender.SetSortingOrder(6 - (int)worldPos.y);
        defender.transform.parent = defendersParent.transform;
    }

    public static void SetSelectedDefender(Defender defender)
    {
        defenderPrefab = defender;
    }
}