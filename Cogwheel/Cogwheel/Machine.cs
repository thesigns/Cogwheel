using SFML.Window;

namespace Cogwheel {
    public class Machine {

        private static readonly List<WeakReference> machines = new();

        private IState state;
        public IState State {
            get => state;
            set {
                Console.WriteLine("Exit " + state);
                state.Exit();
                state = value;
                Console.WriteLine("Enter " + state);
                state.Enter();
            }
        }

        public Machine(IState initialState) {
            WeakReference wr = new WeakReference(null);
            wr.Target = this;
            machines.Add(wr);
            state = initialState;
            state.Enter();
        }

        public Machine() : this(new NullState()) {
        }

        public static void Update() {
            for (int i = machines.Count - 1; i >= 0; i--) {
                Machine? m = (Machine?)machines[i].Target;
                if (m == null) {
                    machines.RemoveAt(i);
                } else {
                    m.State.Update();
                }
            }
        }

        public static void KeyPressed(object? sender, KeyEventArgs args) {
            for (int i = machines.Count - 1; i >= 0; i--) {
                Machine? m = (Machine?)machines[i].Target;
                if (m == null) {
                    machines.RemoveAt(i);
                } else {
                    m.State.KeyPressed(sender, args);
                }
            }
        }

        private class NullState : IState {
            public void Enter() { }
            public void Update() { }
            public void Exit() { }
            public void KeyPressed(object? sender, KeyEventArgs args) { }
        }

    }
}
