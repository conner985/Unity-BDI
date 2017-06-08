using UnityEngine;
using System;

public class BasicReasoner : IReasoner
{
    static IReasoner _instance;

    #region IReasoner implementation

    public static IReasoner GetInstance()
    {
        if (_instance == null)
        {
            _instance = new BasicReasoner();
        }
        return _instance;
    }

    public IBasicPlan StartReasoning(IBasicAgent agent)
    {
        for (int i = 0; i < agent.GetPlans().Count; i++)
        {
            // check if it has that deisre
            bool desireFound = false;
            for (int j = 0; j < agent.GetDesires().Count; j++)
            {
                if (agent.GetDesires()[j].GetRepresentation().Equals(agent.GetPlans()[i].GetDesire().GetRepresentation()))
                {
                    desireFound = true;
                    break;
                }
            }
            if (desireFound)
            {
                // check if it has those beliefs
                int countBeliefs = 0;
                for (int j = 0; j < agent.GetPlans()[i].GetBeliefs().Count; j++)
                {
                    bool beliefFound = false;
                    for (int k = 0; k < agent.GetBeliefs().Count; k++)
                    {
                        if (agent.GetPlans()[i].GetBeliefs()[j].GetRepresentation() == agent.GetBeliefs()[k].GetRepresentation() &&
                            agent.GetPlans()[i].GetBeliefs()[j].GetValue() == agent.GetBeliefs()[k].GetValue())
                        {
                            beliefFound = true;
                            countBeliefs++;
                            break;
                        }
                    }
                    if (!beliefFound)
                    {
                        break;
                    }
                }
                if (countBeliefs == agent.GetPlans()[i].GetBeliefs().Count)
                {
                    return agent.GetPlans()[i];
                }
            }
        }
        return null;
    }

    #endregion


}