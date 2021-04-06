
using System.Numerics;
using Vector2 = UnityEngine.Vector2;

namespace AriumFramework.Plugins
{
    public class PlayerMovement : Interaction<PlayerController>
    {
        public  PlayerMovement(Vector2 direction,float force )
        {
            SetAction(controller => controller.Move(direction.x *force, direction.y));
        }
        
    }
}