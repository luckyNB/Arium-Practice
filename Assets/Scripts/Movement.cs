
using UnityEngine;

namespace DefaultNamespace
{
    public class Movement : MonoBehaviour
    {
        public PlayerController Player;  
        void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Player.Move(moveHorizontal, moveVertical);
        }
    }
}