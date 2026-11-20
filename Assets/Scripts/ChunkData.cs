using UnityEngine;

[CreateAssetMenu(fileName = "New Chunk", menuName = "Chunks/Chunk")]
public class ChunkData : ScriptableObject {
    public string chunkName;
    public GameObject chunk;
}
