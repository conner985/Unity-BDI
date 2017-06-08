using UnityEngine;

[System.Serializable]
public class BasicDesire : IDesire
{
    [SerializeField]
    string rep;

    public BasicDesire(string rep)
    {
        this.rep = rep;
    }

    #region IDesire implementation

    public string GetRepresentation()
    {
        return rep;
    }

    #endregion
    
}