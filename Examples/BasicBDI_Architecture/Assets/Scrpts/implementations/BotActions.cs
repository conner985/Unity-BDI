using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(Animator), typeof(BasicAgent), typeof(NavMeshAgent))]
public class BotActions : MonoBehaviour
{
    Animator anim;
    BasicAgent agent;
    BasicAgent masterAgent;
    NavMeshAgent nav;

    [SerializeField]
    GameObject master;
    [SerializeField]
    GameObject beer;
    [SerializeField]
    GameObject yesText;

    void Start()
    {
        anim = GetComponent<Animator>();   
        agent = GetComponent<BasicAgent>();
        masterAgent = master.GetComponent<BasicAgent>();
        nav = GetComponent<NavMeshAgent>();
    }

    public void GoToFridge()
    {
        yesText.transform.localRotation = Quaternion.identity;  
        yesText.SetActive(true);
        agent.Interact(new BasicDesire("openFridge")); 
        nav.SetDestination(GameObject.Find("FridgePoint").transform.position);
        anim.SetTrigger("Walk");

        StartCoroutine(WaitALittle());
    }

    IEnumerator WaitALittle()
    {
        yield return new WaitForSeconds(1f);
        yesText.SetActive(false);
    }

    public void TakeBeer()
    {
        StartCoroutine(OpenFridge());
    }

    IEnumerator OpenFridge()
    {
        anim.SetTrigger("Open");
        var state = anim.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(11f);
        beer.SetActive(true);
        anim.SetTrigger("Walk");
        agent.Interact(new BasicBelief("haveBeer", true));
        agent.Interact(new BasicDesire("bringMasterBeer"));
    }

    public void GoToMaster()
    {
        agent.Interact(new BasicDesire("giveMasterBeer")); 
        nav.SetDestination(GameObject.Find("DeliveryPoint").transform.position);
        anim.SetTrigger("Walk");
    }

    public void GiveMasterBeer()
    {
        StartCoroutine(GiveBeer());
    }

    IEnumerator GiveBeer()
    {
        anim.SetTrigger("Give");
        yield return new WaitForSeconds(1.5f);
        anim.SetTrigger("Idle");
        beer.SetActive(false);
        masterAgent.Interact(new BasicBelief("haveBeer", true));
        agent.Interact(new BasicBelief("haveBeer", false));
        agent.Interact(new BasicBelief("masterThirsty", false));
    }
}
