using System.Diagnostics;
using System.Text;

namespace UmmahShop
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> cart = new Dictionary<string, int>();

        

        public Form1()
        {
            InitializeComponent();

            FillCombobox(DefaultQuantity(), cbxQuantity);
            FillCombobox(DefaultColor(), cbxColor);

            rchTxtReadOnly.Text = "Cart is empty";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbxQuantity.SelectedIndex == 0 || cbxColor.SelectedIndex == 0)
            {
                lblError.Text = "Error in selection";
                lblError.Visible = true;
            }
            else
            {
                lblError.Visible = false;
                lblTotal.Visible = false;

                var selectedQty = int.Parse(cbxQuantity.SelectedItem.ToString());

                var selectedColor = cbxColor.SelectedItem.ToString();

                if (cart.ContainsKey(selectedColor))
                {
                    //var colorQuantity = cart[selectedColor];
                    //var finalCount = colorQuantity + selectedQty;
                    //cart[selectedColor] = finalCount;
                    cart[selectedColor] = selectedQty;
                }
                else
                {
                    cart.Add(selectedColor, selectedQty);
                }
                AddCart();
            }

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            var price = Calculate.CalculatePrice(Calculate.DiscountBuckets(cart));
            lblTotal.Text = "Total Price: \u00A3" + price.ToString();
            lblTotal.Visible = true;
        }

        private void AddCart()
        {
            string str = string.Empty;
            str = "Thobe Color\tQuantity" + '\n';

            foreach (var item in cart)
            {
                str = str + item.Key + '\t' + '\t' + "    " + item.Value + '\n';
            }
            rchTxtReadOnly.Text = str;

        }

        private void FillCombobox(List<string> list, ComboBox comboBox)
        {
            var index = 0;
            comboBox.Items.Insert(index, "Select");
            foreach (var item in list)
            {
                comboBox.Items.Insert(++index, item);
            }
            comboBox.SelectedIndex = 0;
        }

        private List<string> DefaultQuantity()
        {
            List<string> qtyList = new List<string>();
            qtyList.Add("1");
            qtyList.Add("2");
            qtyList.Add("3");
            qtyList.Add("4");
            qtyList.Add("5");
            qtyList.Add("6");
            qtyList.Add("7");
            qtyList.Add("8");
            qtyList.Add("9");
            qtyList.Add("10");
            return qtyList;
        }

        private List<string> DefaultColor()
        {
            List<string> colorList = new List<string>();
            colorList.Add("Black");
            colorList.Add("White");
            colorList.Add("Grey");
            colorList.Add("Green");
            colorList.Add("Blue");
            return colorList;
        }

    }
}