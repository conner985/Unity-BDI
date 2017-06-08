using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator), typeof(BasicAgent))]
public class MasterActions : MonoBehaviour
{
    Animator anim;
    BasicAgent agent;
    BasicAgent botAgent;

    [SerializeField]
    GameObject bot;
    [SerializeField]
    GameObject beer;
    [SerializeField]
    GameObject beerText;

    void Start()
    {
        anim = GetComponent<Animator>();   
        agent = GetComponent<BasicAgent>();
        botAgent = bot.GetComponent<BasicAgent>();
    }

    public void CallTheBot()
    {
        beerText.SetActive(true);
        botAgent.Interact(new BasicBelief("masterThirsty", true));
        botAgent.Interact(new BasicDesire("goFetchBeer"));

        agent.Interact(new BasicDesire("drink"));
    }

    public void Drink()
    {
        beerText.SetActive(false);
        StartCoroutine(DrinkAWhile());
    }

    IEnumerator DrinkAWhile()
    {
        beer.SetActive(true);
        anim.SetTrigger("Drink");
        yield return new WaitForSeconds(10f);
        beer.SetActive(false);
        agent.Interact(new BasicBelief("haveBeer", false));
        agent.Interact(new BasicDesire("thirsty"));
    }
}