using UnityEngine;

namespace MyEngine
{
    // 게임오브젝트를 Horizontal 방향으로 움직이도록함 
	public class HScroll : MonoBehaviour
	{
        private Rigidbody2D _rb2d;

        public void setRigidbody(float speed)
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _rb2d.bodyType = RigidbodyType2D.Kinematic;
            _rb2d.velocity = new Vector2(-speed, 0f);
        }

        public void setStop()
        {
            _rb2d.velocity = Vector2.zero;
        }

    }
}


