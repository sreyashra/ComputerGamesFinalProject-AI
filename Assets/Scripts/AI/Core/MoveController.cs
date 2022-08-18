using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Core
{
    public class MoveController : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        // Start is called before the first frame update
        void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void MoveTo(Vector3 position)
        {
            _navMeshAgent.destination = position;
        }
    }
}
