using System;

public interface IReasoner
{
    IBasicPlan StartReasoning(IBasicAgent agent);
}