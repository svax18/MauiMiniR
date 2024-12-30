namespace MauiMiniR
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string operatorMath = "";
        string end;
        double firstNum, secondNum;
        String[] firstArr = new string[99];
        String[] secondArr = new string[99];
        int counterOne;
        int counterTwo;
        string Myresult;
        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }

        void OnClear(object sender, EventArgs e)
        {
            firstNum = 0;

            secondNum = 0;
            currentState = 1;
            this.result.Text = "0";

        }

        void OnNumberSelection(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string btnPressed = button.Text;


            if (this.result.Text == "0" || currentState < 0)
            {
                this.result.Text = string.Empty;
                if (currentState < 0)
                    currentState *= -1;
            }

            //this.result.Text += btnPressed;
            string hello = btnPressed;

            double number;
            if (double.TryParse(hello, out number))
            {
                string one = firstNum.ToString();
                string middle = operatorMath;
                string two = secondNum.ToString();

                if (currentState == 1)
                {
                    firstNum = number;
                    end = firstNum.ToString();
                    firstArr[counterOne] =end.ToString();
                    counterOne+=1;
                    Myresult = String.Join("", firstArr);
                    end = Myresult;


                    counterTwo = 0;
                    firstNum = Convert.ToDouble(Myresult);
                    one =Myresult;
                    this.result.Text = one;
                }
                else
                {
                    secondNum = number;
                    end = secondNum.ToString();
                    //two = secondNum.ToString();
                    secondArr[counterTwo] =end.ToString();
                    counterTwo+=1;
                    //end = string.Concat(one, two);
                    Myresult = String.Join("", secondArr);
                    end = Myresult;

                    firstArr = new string[99];
                    counterOne = 0;
                    secondNum = Convert.ToDouble(Myresult);
                    two = Myresult;
                    this.result.Text = string.Concat(one, middle, two);
                }


                //att göra bygg om så att två nummer kan användas


            }
        }

        void onOperatorSelection(object sender, EventArgs e)
        {
            if (operatorMath =="")
            {
                currentState = -2;
                Button button = (Button)sender;
                string btnPressed = button.Text;
                operatorMath = btnPressed;
                this.result.Text = string.Concat(firstNum, operatorMath);
            }

        }

        void onCalculator(object sender, EventArgs e)
        {
            if (currentState == 2)
            {

                var answer = Calculate.Beräkna(firstNum, secondNum, operatorMath);
                var result = (Math.Round(answer, 5));
                secondArr = new string[99]; 
                this.result.Text = result.ToString();
                firstNum = result;
                currentState = -1;
                operatorMath="";
            }
        }
    }

}
