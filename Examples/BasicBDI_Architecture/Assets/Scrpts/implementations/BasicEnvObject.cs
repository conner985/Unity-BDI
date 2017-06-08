using UnityEngine;

public class BasicEnvObject : MonoBehaviour, IEnvObject
{
    [SerializeField]
    BasicBelief belief;

    #region IEnvObject implementation

    public BasicBelief Sense()
    {
        return belief;
    }

    #endregion
    
}