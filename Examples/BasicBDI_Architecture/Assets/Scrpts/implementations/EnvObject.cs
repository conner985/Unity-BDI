using UnityEngine;

public class EnvObject : MonoBehaviour, IEnvObject
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