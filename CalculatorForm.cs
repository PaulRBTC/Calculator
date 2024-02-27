using System.Text.RegularExpressions;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {

        readonly string[] operators = new string[] { "÷", "×", "+", "-" };
        double LastAnswer = 0.0f;

        public CalculatorForm()
        {
            InitializeComponent();

            this.CalculationInput.Select(this.CalculationInput.Text.Length, this.CalculationInput.Text.Length);
            this.CalculationInput.ScrollToCaret();
        }

        private void HandleNumberBtns(int number)
        {
            string numberString = number.ToString();
            if (this.CalculationInput.Text == "0" || this.CalculationInput.Text.StartsWith("="))
            {
                this.CalculationInput.Text = numberString;
            } else
            {
                this.CalculationInput.Text += numberString;
            }
        }

        private void HandleOperationBtn(string op)
        {
            if (this.CalculationInput.Text.StartsWith("="))
            {
                this.CalculationInput.Text = this.LastAnswer.ToString() + $" {op} ";
                return;
            }

            if (operators.Any(op1 => this.CalculationInput.Text.EndsWith($" {op1} ")))
            {
                this.CalculationInput.Text = this.CalculationInput.Text[..^3];
            }

            this.CalculationInput.Text += $" {op} ";
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
            if (this.CalculationInput.Text.Length > 0)
            {
                if (operators.Any(op => this.CalculationInput.Text.EndsWith(op))) this.CalculationInput.Text = this.CalculationInput.Text[..^2];
                else if (operators.Any(op => this.CalculationInput.Text.EndsWith($" {op} "))) this.CalculationInput.Text = this.CalculationInput.Text[..^3];
                else this.CalculationInput.Text = this.CalculationInput.Text[..^1];

                if (this.CalculationInput.Text.Length == 0) this.CalculationInput.Text = "0";
            }
        }

        private void DivideBtn_Click(object sender, EventArgs e)
        {
            HandleOperationBtn(operators[0]);   
        }

        private void MultiplyBtn_Click(object sender, EventArgs e)
        {
            HandleOperationBtn(operators[1]);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            HandleOperationBtn(operators[2]);
        }

        private void SubtractBtn_Click(object sender, EventArgs e)
        {
            HandleOperationBtn(operators[3]);
        }

        private void EqualsBtn_Click(object sender, EventArgs e)
        {
            string equation = this.CalculationInput.Text;
            equation = Regex.Replace(equation, @"\s+", ""); //remove all spaces from equation
            equation = Regex.Replace(equation, operators[0], "/"); //set divide operator to be "computer-friendly"
            equation = Regex.Replace(equation, operators[1], "*"); //set multiply operator to be "computer-friendly"
            
            Operation operation = new Operation();
            operation.Parse(equation);

            double answer = operation.Solve();

            this.LastAnswer = answer;
            this.CalculationInput.Text = $"= {answer}";
        }

        private void DecButton_Click(object sender, EventArgs e)
        {
            if (this.CalculationInput.Text.StartsWith("=")) this.CalculationInput.Text = "0.";
            else this.CalculationInput.Text += ".";
        }

        private void AnsButton_Click(object sender, EventArgs e)
        {
            if (this.LastAnswer == 0.0f) return;

            if (this.CalculationInput.Text.StartsWith("=") || this.CalculationInput.Text == "0")
            {
                this.CalculationInput.Text = this.LastAnswer.ToString();
            }
            else
            {
                this.CalculationInput.Text += this.LastAnswer;
            }
        }
    }
}