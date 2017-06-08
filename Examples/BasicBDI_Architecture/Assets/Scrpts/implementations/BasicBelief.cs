using UnityEngine;

[System.Serializable]
public class BasicBelief : IBasicBelief
{
    [SerializeField]
    string rep;

    [SerializeField]
    bool val;

    public BasicBelief(string rep, bool val)
    {
        this.rep = rep;
        this.val = val;
    }

    #region IBasicBelief implementation

    public bool GetValue()
    {
        return val;
    }

    #endregion

    #region IBelief implementation

    public string GetRepresentation()
    {
        return rep;
    }

    #endregion
    
}