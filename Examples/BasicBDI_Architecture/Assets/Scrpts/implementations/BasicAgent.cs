using UnityEngine;
using System.Collections.Generic;

public class BasicAgent : MonoBehaviour, IBasicAgent
{
    [SerializeField]
    string agentName = "agent";

    [SerializeField]
    List<BasicBelief> beliefs;
    [SerializeField]
    List<BasicDesire> desires;
    [SerializeField]
    List<BasicPlan> plans;

    Queue<IBasicPlan> pendingPlans;

    static IReasoner reasoner = BasicReasoner.GetInstance();

    Collider[] colliders = new Collider[50];

    void Start()
    {
        pendingPlans = new Queue<IBasicPlan>();
    }

    void Update()
    { 
        // SENSE
        Physics.OverlapSphereNonAlloc(transform.position, 2f, colliders);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i] != null && colliders[i].GetComponent<IEnvObject>() != null)
            {
                Interact(colliders[i].GetComponent<IEnvObject>().Sense());
            }
        }

        // REASON
        IBasicPlan plan = reasoner.StartReasoning(this);
        if (plan != null)
        {
            pendingPlans.Enqueue(plan);
        }

        // ACT
        if (pendingPlans.Count > 0)
        {
            plan = pendingPlans.Dequeue();
            plan.GetActions().Invoke();
            for (int i = 0; i < desires.Count; i++)
            {
                if (desires[i].GetRepresentation() == plan.GetDesire().GetRepresentation())
                {
                    desires.RemoveAt(i);
                    break;
                }
            }
        }
    }

    #region IBDIAgent implementation

    public List<BasicBelief> GetBeliefs()
    {
        return beliefs;
    }

    public List<BasicDesire> GetDesires()
    {
        return desires;
    }

    public List<BasicPlan> GetPlans()
    {
        return plans;
    }

    public void Interact(BasicBelief belief)
    {
        for (int i = 0; i < beliefs.Count; i++)
        {
            if (beliefs[i].GetRepresentation().Equals(belief.GetRepresentation()))
            {
                beliefs[i] = belief;
                return;
            }
        }
        beliefs.Add(belief);
    }


    public void Interact(BasicDesire desire)
    {
        for (int i = 0; i < desires.Count; i++)
        {
            if (desires[i].GetRepresentation().Equals(desire.GetRepresentation()))
            {
                desires[i] = desire;
                return;
            }
        }
        desires.Add(desire);
    }

    #endregion
}

