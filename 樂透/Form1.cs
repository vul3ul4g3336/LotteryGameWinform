using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 樂透
{

    public partial class Form1 : Form
    {
        LotteryService service = new LotteryService();
        List<Button> ChooseNum = new List<Button>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 49; i++)
            {

                Button button = new Button();
                button.Size = new System.Drawing.Size(50, 34);
                button.Text = $"{i + 1}";
                button.Click += Num_Click;
                flowLayoutPanel1.Controls.Add(button);
            }


        }

        private void Num_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var result = service.ChooseNumbers(btn.Text);
            if (!result.Item1)
            {
                MessageBox.Show(result.Item2);
                return;
            }
            btn.Enabled = false;
            textBox1.Text = service.GetSelectNumber();
            ChooseNum.Add(btn);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!service.ConfirmNum())
            {
                MessageBox.Show("須選6個號碼");
                return;
            }
            String OpeningNum = service.GetOpeningNum();
            textBox2.Text = OpeningNum;


            (string awardNumber, string result) = service.LotteryDraw();
            if (awardNumber.Length > 0)
                label4.Text = awardNumber;
            textBox4.Text = result;


        }

        private void button2_Click(object sender, EventArgs e)
        {

            var result = service.DeleteNum();
            if (result.Item1)
            {
                EnableNum(result.Item2);
                textBox1.Text = service.GetSelectNumber();
            }
        }
        private void EnableNum(string Num)
        {

            Button button = ChooseNum.FirstOrDefault(x => x.Text == Num);
            button.Enabled = true;
            ChooseNum.Remove(button);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
