using System.Collections.Generic;
using System;

public interface IBasicAgent
{

    List<BasicBelief> GetBeliefs();

    List<BasicDesire> GetDesires();

    List<BasicPlan> GetPlans();

    void Interact(BasicBelief belief);

    void Interact(BasicDesire desire);

}