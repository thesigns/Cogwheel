using Cogwheel;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

static class Example {

    static void Main(string[] args) {

        var mode = new VideoMode(800, 600);
        var window = new RenderWindow(mode, "Cogwheel example");
        window.SetVerticalSyncEnabled(true);
        window.SetFramerateLimit(60);
        
        window.Closed += (sender, args) => window.Close();
        window.KeyPressed += (sender, args) => Machine.KeyPressed(sender, args);

        var machine = new Machine();
        machine.State = new StateCircle(window, machine);

        while (window.IsOpen) {
            window.DispatchEvents();
            window.Clear();
            Machine.Update();
            window.Display();
        }

    }
}


class StateCircle: IState {

    RenderWindow window;
    Machine machine;

    public StateCircle(RenderWindow window, Machine machine) {
        this.window = window;
        this.machine = machine;
    }

    public void Enter() {
    }

    public void Update() {
        CircleShape circle = new(200, 100);
        circle.Position = new Vector2f(200, 100);
        circle.FillColor = Color.Yellow;
        window.Draw(circle);
    }

    public void Exit() {
    }

    public void KeyPressed(object? sender, KeyEventArgs args) {
        machine.State = new StateDiamond(window, machine);
    }

}

class StateDiamond : IState {

    RenderWindow window;
    Machine machine;

    public StateDiamond(RenderWindow window, Machine machine) {
        this.window = window;
        this.machine = machine;
    }

    public void Enter() {
    }

    public void Update() {
        CircleShape circle = new(200, 4);
        circle.Position = new Vector2f(200, 100);
        circle.FillColor = Color.Cyan;
        window.Draw(circle);
    }

    public void Exit() {
    }

    public void KeyPressed(object? sender, KeyEventArgs args) {
        machine.State = new StateCircle(window, machine);
    }

}