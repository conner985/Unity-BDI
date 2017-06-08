using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class BasicPlan : IBasicPlan
{
    [SerializeField]
    BasicDesire desire;
    [SerializeField]
    List<BasicBelief> beliefs;
    [SerializeField]
    UnityEvent actions;

    public BasicPlan(BasicDesire desire, List<BasicBelief> beliefs, UnityEvent actions)
    {
        this.desire = desire;
        this.beliefs = beliefs;
        this.actions = actions;
    }

    #region IStandardPlan implementation

    public BasicDesire GetDesire()
    {
        return desire;
    }

    public List<BasicBelief> GetBeliefs()
    {
        return beliefs;
    }

    public UnityEvent GetActions()
    {
        return actions;
    }

    #endregion

    #region IPlan implementation

    public string GetRepresentation()
    {
        return desire.GetRepresentation() + ":" + beliefs + ":" + actions;
    }

    #endregion
}