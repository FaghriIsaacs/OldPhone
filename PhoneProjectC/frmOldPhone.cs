using System;
using System.Windows.Forms;

namespace PhoneProjectC
{
    public partial class frmOldPhone : Form
    {
        String strCharacter;
        int second = 0;

        public frmOldPhone()
        {
            InitializeComponent();
        }

        public static string OldPhonePad(string strOutput)
        {
            return strOutput;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //Execution of code is driven mostly by timer as this is dependent on
            //how long you wait for User to decide on next character and which button he chooses
            second += 1;
            if (second >= 1)
            { Timer1.Stop(); }
            //Check which character User busy with at this point and to be used
            GetChar(Int16.Parse(txtNumberPressed.Text), Int16.Parse(txtInstances.Text));
            //Execute by setting variable (output1 textbox) at this stage 
            txtOutput1.Text += OldPhonePad(strCharacter);
            //Now start over by resetting defaults, and wait for next inputs from User
            ResetDefaults();
        }

        private void frmOldPhone_Load(object sender, EventArgs e)
        {
            Timer1.Interval = 1000;//interval set at 1 second as per requirement for pause
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //This button assumes User is happy to Submit his message.  Once clicked, the message will be sent as final like a mobile phone operates currently
            txtOutput1.Text += OldPhonePad(strCharacter);
            ResetDefaults();//Reset which button was clicked, and restart the string buildup of characters
            txtOutput2.Text += txtOutput1.Text;//Curretnly retaining existing Output Screen, but can merely reset if neccessary
            txtOutput1.Text = "";//Start over to build new variable string after Submitting to screen
        }

       

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            //This controls backspace of variable string buildup, not Output Screen.  Once you submit on Output Screen you cant Edit, like a mobile would do
            string strOutput1;
            strOutput1 = txtOutput1.Text;
        if(strOutput1.Length > 0)
            { 
                txtOutput1.Text = strOutput1.Substring(0, strOutput1.Length - 1);
             }  
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtOutput1.Text += " ";
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            Timer1.Start();// 'Timer starts functioning
            SetButtonClicked("0");
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            Timer1.Start();// 'Timer starts functioning
            SetButtonClicked("1");
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            Timer1.Start();// 'Timer starts functioning
            SetButtonClicked("2");
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            Timer1.Start();// 'Timer starts functioning
            SetButtonClicked("3");
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            Timer1.Start();// 'Timer starts functioning
            SetButtonClicked("4");
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            Timer1.Start();// 'Timer starts functioning
            SetButtonClicked("5");
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            Timer1.Start();// 'Timer starts functioning
            SetButtonClicked("6");
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            Timer1.Start();// 'Timer starts functioning
            SetButtonClicked("7");
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            Timer1.Start();// 'Timer starts functioning
            SetButtonClicked("8");
        }

        protected void GetChar(Int16 intButton, Int16 intChar)
        {
            string[,] values = new string[9, 4] {
                           {"&", "'", "(", ""},
                           { "a", "b", "c", ""},
                           { "d", "e", "f", ""},
                           { "g", "h", "i", ""},
                           { "j", "k", "l", ""},
                           { "m", "n", "o", ""},
                           { "p", "q", "r", "s"},
                           { "t", "u", "v", ""},
                           { "w", "x", "y", "z"}
            };

            //Get bounds of the array.
            int bound0 = values.GetUpperBound(0);
            int bound1 = values.GetUpperBound(1);
            bound0 += 1;
            bound1 += 1;
            //Loop over all elements.
            for (int i = 0; i < bound0; i++)
            {
                for (int j = 0; j < bound1; j++)
                {
                    //Get element for button character selection.
                    if (i == intButton && j == intChar)
                    {
                        //string strChar = values[i, j];
                        strCharacter = values[i, j];
                    }
                }
            }
        }

        protected void ResetDefaults()
        {
            txtInstances.Text = "";
            txtNumberPressed.Text = "0";
            strCharacter = "";
        }

        protected void SetButtonClicked(string strButtonPressed)
        {
            int num;
            //Record which button was pressed, and control instances 
            txtNumberPressed.Text = strButtonPressed;// 'button pressed. Should be one less than name, for index

            if (txtInstances.Text.Length == 0)
            { txtInstances.Text = "0"; }
            else
            {
                if (Int16.Parse(txtInstances.Text) < 3)
                {
                    num = Int16.Parse(txtInstances.Text);
                    num += 1;
                    txtInstances.Text = num.ToString();
                }
            }
        }
    }
}
