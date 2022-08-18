using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.UtilityTheory;

namespace AI.Core
{
    public class AIController : MonoBehaviour
    {
        public MoveController MoveController { get; set; }
        public AIBrain AIBrain { get; set; }
        public Action[] actionsAvailable;
    }
}
