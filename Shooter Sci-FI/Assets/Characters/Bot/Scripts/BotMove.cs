using UnityEngine;
using UnityEngine.AI;

public class BotMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    public Transform Target { get { return target; } set { target = value; } }
    private NavMeshAgent _botNMA;

    private void Start()
    {
        _botNMA = GetComponent<NavMeshAgent>();
        Target = GetComponent<TargetMoveBot>().GetTarget();
    }

    private void Update()
    {
        _botNMA.destination = Target.position;
    }
}
