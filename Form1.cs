namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.CalculationInput.Select(this.CalculationInput.Text.Length, this.CalculationInput.Text.Length);
            this.CalculationInput.ScrollToCaret();
        }

        private void HandleNumberBtns(int number)
        {
            string numberString = number.ToString();
            if (this.CalculationInput.Text == "0")
            {
                this.CalculationInput.Text = numberString;
            } else
            {
                this.CalculationInput.Text += numberString;
            }
        }

        private void SevenBtn_Click(object sender, EventArgs e)
        {
            HandleNumberBtns(7);
        }

        private void EightBtn_Click(object sender, EventArgs e)
        {
            HandleNumberBtns(8);
        }

        private void NineBtn_Click(object sender, EventArgs e)
        {
            HandleNumberBtns(9);
        }

        private void FourBtn_Click(object sender, EventArgs e)
        {
            HandleNumberBtns(4);
        }

        private void FiveBtn_Click(object sender, EventArgs e)
        {
            HandleNumberBtns(5);
        }

        private void SixBtn_Click(object sender, EventArgs e)
        {
            HandleNumberBtns(6);
        }

        private void OneBtn_Click(object sender, EventArgs e)
        {
            HandleNumberBtns(1);
        }

        private void TwoBtn_Click(object sender, EventArgs e)
        {
            HandleNumberBtns(2);
        }

        private void ThreeBtn_Click(object sender, EventArgs e)
        {
            HandleNumberBtns(3);
        }

        private void ZeroBtn_Click(object sender, EventArgs e)
        {
            HandleNumberBtns(0);
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            this.CalculationInput.Text = "0";
        }

        private void BkspBtn_Click(object sender, EventArgs e)
        {
            this.CalculationInput.Text = this.CalculationInput.Text.Substring(0, this.CalculationInput.Text.Length - 1);
        }

        private void DivideBtn_Click(object sender, EventArgs e)
        {
            if ((new string[] { " ÷ ", " × ", " − ", " + " }).Any(op => this.CalculationInput.Text.EndsWith(op)))
            {
                this.CalculationInput.Text = this.CalculationInput.Text.Substring(0, this.CalculationInput.Text.Length - 3);
            }
            this.CalculationInput.Text += " ÷ ";
        }

        private void MultiplyBtn_Click(object sender, EventArgs e)
        {
            if ((new string[] { " ÷ ", " × ", " − ", " + " }).Any(op => this.CalculationInput.Text.EndsWith(op)))
            {
                this.CalculationInput.Text = this.CalculationInput.Text.Substring(0, this.CalculationInput.Text.Length - 3);
            }
            this.CalculationInput.Text += " × ";
        }

        private void SubtractBtn_Click(object sender, EventArgs e)
        {
            if ((new string[] { " ÷ ", " × ", " − ", " + " }).Any(op => this.CalculationInput.Text.EndsWith(op)))
            {
                this.CalculationInput.Text = this.CalculationInput.Text.Substring(0, this.CalculationInput.Text.Length - 3);
            }
            this.CalculationInput.Text += " − ";
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if ((new string[] { " ÷ ", " × ", " − ", " + " }).Any(op => this.CalculationInput.Text.EndsWith(op)))
            {
                this.CalculationInput.Text = this.CalculationInput.Text.Substring(0, this.CalculationInput.Text.Length - 3);
            }
            this.CalculationInput.Text += " + ";
        }

        private void EqualsBtn_Click(object sender, EventArgs e)
        {
            this.CalculationInput.Text = "Calculating...";
        }
    }
}