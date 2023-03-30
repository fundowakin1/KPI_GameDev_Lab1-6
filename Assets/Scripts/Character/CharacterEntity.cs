using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterEntity : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed;

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _frontFace;
        [SerializeField] private Sprite _backFace;
        [SerializeField] private Sprite _sideFace;
        [SerializeField] private bool _facedRight;

        [SerializeField] private Animator _animator;

        private Direction _currentDirection;
        private CharacterAnimator _characterAnimator;

        // Start is called before the first frame update
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();   
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _currentDirection = Direction.Down;
            _characterAnimator = new CharacterAnimator(_animator);
        }

        public void Move(float horizontalDirection, float verticalDirection)
        {
            var velocity = _rigidbody.velocity;
            velocity.x = horizontalDirection * _speed;
            velocity.y = verticalDirection * _speed;
            _rigidbody.velocity = velocity;

            _characterAnimator.Animate(horizontalDirection, verticalDirection);
        }

        public void Face(float horizontalDirection, float verticalDirection)
        {
            //go up
            if(_currentDirection != Direction.Up && verticalDirection > 0)
            {
                _spriteRenderer.sprite = _backFace;
                _currentDirection = Direction.Up;
            }

            //go down
            if(_currentDirection != Direction.Down && verticalDirection < 0)
            {
                _spriteRenderer.sprite = _frontFace;
                _currentDirection = Direction.Down;
            }
                    
    
            //go left
            if(_currentDirection != Direction.Left && horizontalDirection < 0)
            {
                _spriteRenderer.sprite = _sideFace;
                if(_facedRight)
                {
                    FlipHorizontally();
                }
                
                _currentDirection = Direction.Left;
            }

            //go right
            if(_currentDirection != Direction.Right && horizontalDirection > 0)
            {
                _spriteRenderer.sprite = _sideFace;
                if(!_facedRight)
                {
                    FlipHorizontally();
                }

                _currentDirection = Direction.Right;
            }
        }

        private void FlipHorizontally()
        {
            transform.Rotate(0, 180, 0);
            _facedRight = !_facedRight;
        }
    }
}