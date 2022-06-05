using UnityEngine;

namespace MyEngine
{
    // HScroll.cs 를 이용해 Horizontal 방향으로 움직이는 게임오브젝트가 
    // 화면 밖으로 벗어나면 원위치시켜 반복하도록함
    // HRepeat 상속받기만 하면 반복진행 되도록 
    [RequireComponent(typeof(BoxCollider2D))]
	public class HRepeat : MonoBehaviour
	{
        private BoxCollider2D _box;
        private float _horizontalLength;

        private void Awake()
        {
            setBoxCollider();   
        }

        private void Update()
        {
            updateObject();
        }

        public void setBoxCollider()
        {
            _box = GetComponent<BoxCollider2D>();
            _horizontalLength = _box.size.x;           
        }

        public void updateObject()
        {
            if (transform.position.x < -_horizontalLength)
                ResetPosition();
        }

        private void ResetPosition()
        {
            Vector2 addPos = new Vector2(2 * _horizontalLength, 0f);
            transform.position = (Vector2)transform.position + addPos;
        }

    }
}

