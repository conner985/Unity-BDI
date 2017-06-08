using System.Collections.Generic;
using UnityEngine.Events;

public interface IBasicPlan : IPlan
{

    BasicDesire GetDesire();

    List<BasicBelief> GetBeliefs();

    UnityEvent GetActions();

}