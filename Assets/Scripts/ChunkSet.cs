using UnityEngine;

[CreateAssetMenu(fileName = "New Chunk Set", menuName = "Chunks/Chunk Set")]
public class ChunkSet : ScriptableObject {
    public string chunkSetName;
    public ChunkData[] chunks;
    [Range(0.0f, 1.0f)] public float chunkSetProbability;
}
