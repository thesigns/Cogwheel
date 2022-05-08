using SFML.Window;

namespace Cogwheel {

    public interface IState {
        public void Enter();
        public void Update();
        public void Exit();
        public void KeyPressed(object? sender, KeyEventArgs args);
    }

}
