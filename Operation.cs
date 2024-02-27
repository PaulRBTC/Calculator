using System.Text.RegularExpressions;

namespace Calculator
{
    public class Operation
    {
        public Operation? LeftNumber { get; set; }
        public string? Operator { get; set; }
        public Operation? RightNumber { get; set; }

        private readonly Regex additionSubtraction = new Regex("[+-]", RegexOptions.RightToLeft);
        private readonly Regex multiplicationDivision = new Regex("[*/]", RegexOptions.RightToLeft);

        private double result;

        public void Parse(string equation)
        {
            var operatorLocation = additionSubtraction.Match(equation);
            if (!operatorLocation.Success)
            {
                operatorLocation = multiplicationDivision.Match(equation);
            }

            if (operatorLocation.Success)
            {
                Operator = operatorLocation.Value;

                LeftNumber = new Operation();
                LeftNumber.Parse(equation[..operatorLocation.Index]);

                RightNumber = new Operation();
                RightNumber.Parse(equation[(operatorLocation.Index + 1)..]);
            } 
            else
            {
                Operator = "v";
                result = double.Parse(equation);
            }
        }

        public double Solve()
        {
            if (LeftNumber is not null && RightNumber is not null)
            {
                switch (Operator)
                {
                    case "v":
                        break;
                    case "+":
                        result = LeftNumber.Solve() + RightNumber.Solve();
                        break;
                    case "-":
                        result = LeftNumber.Solve() - RightNumber.Solve();
                        break;
                    case "*":
                        result = LeftNumber.Solve() * RightNumber.Solve();
                        break;
                    case "/":
                        result = LeftNumber.Solve() / RightNumber.Solve();
                        break;
                    default:
                        throw new Exception("Call Parse first.");
                }                
            }

            return result;
        }
    }
}
