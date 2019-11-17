using System.Windows.Forms;

namespace Gui
{
    // Creates a window for selecting how many players and how many decks to be in the game
    public class NewGameDialog
    {
        public static int[] ShowDialog()
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Start new game",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = "How many decks?" };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 350 };
            Label textLabel2 = new Label() { Left = 20, Top = 80, Width = 350, Text = "How many players?" };
            TextBox textBox2 = new TextBox() { Left = 20, Top = 105, Width = 350 };
            Button confirmation = new Button() { Text = "Ok", Left = 270, Width = 100, Top = 140, DialogResult = DialogResult.OK };

            confirmation.Click += (sender, e) => prompt.Close(); // lambda expression

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textLabel2);
            prompt.Controls.Add(textBox2);
            prompt.AcceptButton = confirmation;
            int[] returnValues = new int[2];

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                if ((!int.TryParse(textBox.Text, out returnValues[0])) || (!int.TryParse(textBox2.Text, out returnValues[1]))
                    || ((returnValues[0] <= 0) || (returnValues[1] <= 0)))
                {
                    MessageBox.Show("Input positive numbers");
                    returnValues = null;
                }
   
            }
            return returnValues;
        }
    }
}
