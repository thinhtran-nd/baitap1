namespace bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object? sender, EventArgs e)
        {
            // Validate price
            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out var price) || price < 0)
            {
                MessageBox.Show("Vui lòng nhập Đơn giá hợp lệ (số dương).", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            // Validate quantity
            if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !int.TryParse(txtQuantity.Text, out var quantity) || quantity < 0)
            {
                MessageBox.Show("Vui lòng nhập Số lượng khách hợp lệ (số nguyên không âm).", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return;
            }

            // Validate discount
            if (string.IsNullOrWhiteSpace(txtDiscount.Text) || !decimal.TryParse(txtDiscount.Text, out var discount) || discount < 0 || discount > 100)
            {
                MessageBox.Show("Vui lòng nhập Mã giảm giá hợp lệ (từ 0 đến 100).", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscount.Focus();
                return;
            }

            // Calculation: total = (price * quantity) * (100 - discount) / 100
            var subtotal = price * quantity;
            var factor = (100 - discount) / 100m;
            var total = subtotal * factor;

            lblTotal.Text = $"Tổng tiền thanh toán: {total:N2}";
        }

        private void btnReset_Click(object? sender, EventArgs e)
        {
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            lblTotal.Text = "Tổng tiền thanh toán: 0";
            txtPrice.Focus();
        }
    }
}
