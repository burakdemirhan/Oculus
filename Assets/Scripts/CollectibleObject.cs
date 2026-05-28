using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    public string objectId;
    public PuzzleManager puzzleManager;

    private bool collected = false;

    public void Collect()
    {
        if (collected) return;

        collected = true;
        puzzleManager.CollectObject(objectId);

        Debug.Log("Collected: " + objectId);
    }
}