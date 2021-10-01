namespace WindowsFormsApp1
{
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // With .Net Standard
            var name = Standard.StandardLibrary.StandardMethod(this.textBox1.Text);

            // Without .Net Standard
            //var name = $"Hello, {this.textBox1.Text}!";

            MessageBox.Show(name);
        }
    }
}
