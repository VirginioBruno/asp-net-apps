using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyFirstAppXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            OnLoad();
        }

        public void OnLoad()
        {
            LoadOperationType();
        }

        public void LoadOperationType()
        {
            cboType.ItemsSource = new List<OperationType>()
            {
                new OperationType { Id = 1, Operation = "Sum"},
                new OperationType { Id = 2, Operation = "Subtract"},
                new OperationType { Id = 3, Operation = "Divide"},
                new OperationType { Id = 4, Operation = "Multiple"}
            };
        }

        public async void CalculateValues(object sender, EventArgs e) 
        {
            var response = ValidateOperation();

            if (string.IsNullOrEmpty(response))
            {
                int operation = cboType.SelectedIndex + 1;
                double result;

                if (operation == 1)
                    result = Convert.ToDouble(FirstValue.Text) + Convert.ToDouble(SecondValue.Text);
                else if (operation == 2)
                    result = Convert.ToDouble(FirstValue.Text) - Convert.ToDouble(SecondValue.Text);
                else if (operation == 3)
                    result = Convert.ToDouble(FirstValue.Text) / Convert.ToDouble(SecondValue.Text);
                else
                    result = Convert.ToDouble(FirstValue.Text) * Convert.ToDouble(SecondValue.Text);

                CalculateValue.Text = $"Result: {result.ToString("0.####")}";
            }
            else
            {
                await DisplayAlert("Alert", response, "OK");
            }
        }

        public void ClearValues(object sender, EventArgs e)
        {
            FirstValue.Text = null;
            SecondValue.Text = null;
            cboType.SelectedItem = null;
            CalculateValue.Text = null;
        }

        public string ValidateOperation()
        {
            if (FirstValue.Text == null || SecondValue.Text == null)
                return "The values must be filled.";

            if (cboType.SelectedItem == null)
                return "The operation must be filled.";

            if (SecondValue.Text == "0" && cboType.SelectedIndex == 2)
                return "It is not possible to divide by zero.";

            return string.Empty;
        }
    }
}

public class OperationType
{
    public int Id { get; set; }
    public string Operation { get; set; }
}
