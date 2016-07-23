using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random randomizer = new Random();

        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;

        // this integer keeps track of the remaining time
        int timeLeft;

        public void StartTheQuiz()
        {
            if (easyButton.Checked) // easy problem
            {
                addend1 = randomizer.Next(11);
                addend2 = randomizer.Next(11);

                minuend = randomizer.Next(1, 21);
                subtrahend = randomizer.Next(1, minuend);

                multiplicand = randomizer.Next(2, 6);
                multiplier = randomizer.Next(2, 6);

                divisor = randomizer.Next(2, 6);
                int temp = randomizer.Next(2, 6);
                dividend = divisor * temp;
            }
            else if (hardButton.Checked) // hard problem
            {
                addend1 = randomizer.Next(501);
                addend2 = randomizer.Next(501);

                minuend = randomizer.Next(1, 1001);
                subtrahend = randomizer.Next(1, minuend);

                multiplicand = randomizer.Next(2, 32);
                multiplier = randomizer.Next(2, 32);

                divisor = randomizer.Next(2, 32);
                int temp = randomizer.Next(2, 32);
                dividend = divisor * temp;
            }
            else // medium problems (default)
            { 
                addend1 = randomizer.Next(51);
                addend2 = randomizer.Next(51);

                minuend = randomizer.Next(1, 101);
                subtrahend = randomizer.Next(1, minuend);

                multiplicand = randomizer.Next(2, 11);
                multiplier = randomizer.Next(2, 11);

                divisor = randomizer.Next(2, 11);
                int temp = randomizer.Next(2, 11);
                dividend = divisor * temp;
            }

            // display problems
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Start the timer
            if (timeButton1.Checked)
                timeLeft = 15;
            else if (timeButton3.Checked)
                timeLeft = 60;
            else
                timeLeft = 30;

            timeLabel.Text = timeLeft.ToString() + " seconds";
            timer1.Start();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("Awesome! You got all the answers correct!", "Congratulation!");
                startButton.Enabled = true;
                timeLabel.BackColor = Color.Transparent;
            }
            else if (timeLeft > 0)
            {
                timeLeft -= 1;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft < 10)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("Sorry, time's up.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
                timeLabel.BackColor = Color.Transparent;
            }
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
