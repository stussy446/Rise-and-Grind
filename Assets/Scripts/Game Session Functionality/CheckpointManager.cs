using UnityEngine;
using System.Linq;

public class CheckpointManager : MonoBehaviour
{
    Checkpoint[] checkpoints;

    // Start is called before the first frame update
    void Start()
    {
        checkpoints = GetComponentsInChildren<Checkpoint>(); 
    }

    public Checkpoint GetLastCheckpointPassed()
    {
        return checkpoints.Last(t => t.Passed);
    }
}
