﻿using System.Collections.Immutable;
using System.Data;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;

namespace Calculator
{
    public partial class Form1 : Form
    {

        readonly string[] operators = new string[] { "÷", "×", "+", "-" };
        float LastAnswer = 0.0f;

        public Form1()
        {
            InitializeComponent();

            this.CalculationInput.Select(this.CalculationInput.Text.Length, this.CalculationInput.Text.Length);
            this.CalculationInput.ScrollToCaret();

            //AllocConsole();
        }

        /*[DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();*/

        private int IndexOf(string[] array, string elem)
        {
            return array.Select((elem, index) => new { elem, index })
                .First(p => p.elem.Trim() == elem).index;
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
            if (operators.Any(op => this.CalculationInput.Text.EndsWith(op))) this.CalculationInput.Text = this.CalculationInput.Text[..^3];
            else this.CalculationInput.Text = this.CalculationInput.Text[..^1];
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
            string input = this.CalculationInput.Text
                .Replace("÷", "/")
                .Replace("×", "*");
            float answer = float.Parse(new DataTable().Compute(input, null).ToString() ?? "0");

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

            if (this.CalculationInput.Text.StartsWith("=")) this.CalculationInput.Text = this.LastAnswer.ToString();
            else if (this.CalculationInput.Text == "0") this.CalculationInput.Text = this.LastAnswer.ToString();
            else this.CalculationInput.Text += this.LastAnswer;
        }
    }
}