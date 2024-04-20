namespace MoonStat
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String url = url_input.Text;
            MessageBox.Show(url);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
