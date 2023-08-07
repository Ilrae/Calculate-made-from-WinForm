using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharpWin
{
    public enum Operators { Add,Sub,Multi,Div }

    public partial class Calculator : Form
    {
        public float Result = 0;
        public bool isNewNum = true;
        public Operators Opt = Operators.Add;

        public Calculator()
        {
            InitializeComponent();
        }

        public int Add(int number1,int number2)
        {
            int sum = number1 + number2;
            return sum;
        }

        public float Add(float number1,float number2)
        {
            float sum = number1 + number2;
            return sum;
        }

        public float Sub(float number1, float number2)
        {
            float sub = number1 - number2;
            return sub;
        }

        public float Multi(float number1, float number2)
        {
            float mul = number1 * number2;
            return mul;
        }

        public float Div(float number1, float number2)
        {
            float mul = number1 / number2;
            return mul;
        }

        private void NumButton1_Click(object sender, EventArgs e)
        {
            Button numButton = (Button)sender;
            SetNum(numButton.Text);
        }

        public void SetNum(string num)
        {
            if (isNewNum)
            {
                NumScreen.Text = num;
                isNewNum = false;
            }
            else if (NumScreen.Text == "0")
            {
                NumScreen.Text = num;
            }
            else
            {
                NumScreen.Text = NumScreen.Text + num;
            }
        }

        private void NumPlus_Click(object sender, EventArgs e)
        {
            if (isNewNum == false)
            {
                int num = int.Parse(NumScreen.Text);
                if (Opt == Operators.Add)
                    Result = Add(Result , num);
                else if (Opt == Operators.Sub)
                    Result = Sub(Result, num);
                else if (Opt == Operators.Multi)
                    Result = Multi(Result, num);
                else if (Opt == Operators.Div)
                    Result = Div(Result, num);

                NumScreen.Text = Result.ToString();
                isNewNum = true;
            }

            Button optButton = (Button)sender;
            
            switch(optButton.Text)
            {
                case "+":
                    Opt = Operators.Add;
                    return;
                case "-":
                    Opt = Operators.Sub;
                    return;
                case "*":
                    Opt = Operators.Multi;
                    return;
                case "/":
                    Opt = Operators.Div;
                    return;
            }
        }

        private void NumClear_Click(object sender, EventArgs e)
        {
            Result = 0;
            isNewNum = true;
            Opt = Operators.Add;

            NumScreen.Text = "0";
        }
    }
}
