using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Input;

namespace Assets.Scripts.Character
{
    public class CharacterBrain
    {
        private readonly CharacterEntity _character;
        private readonly List<IInputReader> _inputList;
        public CharacterBrain(CharacterEntity characterEntity, List<IInputReader> inputList)
        {
            _character = characterEntity;
            _inputList = inputList;
        }

        public void OnFixedUpdate()
        {
            _character.Move(GetHorizontalDirection(), GetVerticalDirection());
            _character.Face(GetHorizontalDirection(), GetVerticalDirection());
        }

        private float GetHorizontalDirection()
        {
            return _inputList.FirstOrDefault(x => x.HorizontalDirection != 0)?.HorizontalDirection ?? 0;
        }

        private float GetVerticalDirection()
        {
            return _inputList.FirstOrDefault(x => x.VerticalDirection != 0)?.VerticalDirection ?? 0;
        }
    }
}
