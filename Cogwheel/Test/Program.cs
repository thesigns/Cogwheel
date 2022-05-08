namespace Test {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var form = new Form1();

            Application.Run(form);

            form.button1.Click += (obj, args) => {
                form.button1.Text = "Dupa";

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
            };
            
        }
    }
}